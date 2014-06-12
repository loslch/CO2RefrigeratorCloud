from django.shortcuts import render
from django.http import HttpResponse, HttpResponseRedirect, Http404
from django.views.decorators.csrf import csrf_exempt
from django.contrib import messages
import json as Json


def index(request):
    if not request.user.is_authenticated():
        return HttpResponseRedirect('/login')

    return HttpResponseRedirect('/dashboard')


def dashboard(request):
    if not request.user.is_authenticated():
        return HttpResponseRedirect('/login')

    messages.success(request, "Welcome to CO<sub>2</sub> Incubator Cloud Management!")

    return render(request, 'dashboard.html', {

    })


def register(request):
    if not request.user.is_authenticated():
        return HttpResponseRedirect('/login')

    from cloud.models import User, Device, DeviceForm

    if request.method == 'POST':  # If the form has been submitted...
        # ContactForm was defined in the previous section
        form = DeviceForm(request.POST)  # A form bound to the POST data
        if form.is_valid():  # All validation rules pass
            # Process the data in form.cleaned_data
            p_device_id = form.cleaned_data['device_id']
            p_user = form.cleaned_data['user']

            try:
                d = Device.objects.get(device_id=p_device_id)
                if d.user != None:
                    messages.error(request, 'Error: Device ID already registered by another user.')
                    return HttpResponseRedirect('/register')
            except Device.DoesNotExist:
                messages.error(request, "Error: Device is doesn't exist.")
                return HttpResponseRedirect('/register')

            try:
                u = User.objects.get(username=p_user)
            except User.DoesNotExist:
                messages.error(request, 'Error: Uh-oh, something went wrong.')
                return HttpResponseRedirect('/register')

            d = Device()
            d.device_id = p_device_id
            d.user = u
            d.save()

            messages.success(request, 'Success: Your registration has been succeeded.')
            return HttpResponseRedirect('/register')
    else:
        return render(request, 'register.html', {
        })


def device(request, p_device_id):
    if not request.user.is_authenticated():
        return HttpResponseRedirect('/login')

    from cloud.models import Device, Log, Request, Status

    try:
        d = Device.objects.get(device_id=p_device_id)
    except Device.DoesNotExist:
        messages.error(request, "Error: Device is doesn't exist.")
        return HttpResponseRedirect('/dashboard')

    if d.user != request.user:
        messages.error(request, 'Error: Uh-oh, something went wrong.')
        return HttpResponseRedirect('/dashboard')

    status = Status.objects.get(device_id=p_device_id)
    logs = Log.objects.filter(device_id=p_device_id).order_by('-log_time')
    requests = Request.objects.filter(device_id=p_device_id, isSended=False).order_by('-req_time')

    return render(request, 'device.html', {
        'device': p_device_id,
        'status': status,
        'logs': logs,
        'requests': requests,
    })
    

def getJsonData(post_data):
    d = Json.loads(post_data)
    
    try:
        c = d['device_id']
        # Convert all keys to lowercase
        return dict((k.lower(), v) for k, v in d.iteritems())
    except KeyError:
        return False


@csrf_exempt
def api_log(request):
    response_data = {}
    if request.method == 'POST':
        from cloud.models import Device, Log, Status
        
        json = getJsonData(request.body)
        if json == False:
            response_data['status'] = '400'
            return HttpResponse(Json.dumps(response_data), content_type="application/json")

        # create device and status instance if doesn't exist
        device, c = Device.objects.get_or_create(device_id=json['device_id'])
        status, c = Status.objects.get_or_create(device_id=device)

        # set status
        for key in {'co2', 'o2', 'temperature', 'humidity'}:
            if json.has_key(key) == True:
                code = compile("status.%s = json['%s']" % (key, key), '<string>', 'exec')
                exec code
        status.power = True
        status.save()

        # set log
        l = Log()
        l.device_id = device
        l.log = json['log']
        l.log_time = json['log_time']
        l.save()
        
        response_data['status'] = '200'
        return HttpResponse(Json.dumps(response_data), content_type="application/json")

    else:
        response_data['status'] = '400'
        return HttpResponse(Json.dumps(response_data), content_type="application/json")


@csrf_exempt
def api_request(request):
    from cloud.models import Device, Request, Status

    response_data = {}
    if request.method == 'GET':
        p_device_id = request.GET['device_id']
        # create device and status instance if doesn't exist
        device, c = Device.objects.get_or_create(device_id=p_device_id)
        status, c = Status.objects.get_or_create(device_id=device)

        try:
            r = Request.objects.order_by('req_time').filter(device_id=device, isSended=False)[0]
            r.isSended = True
            r.save()

            response_data['request'] = r.request
            response_data['value'] = r.value
            response_data['req_time'] = r.req_time.strftime("%Y-%m-%d %H:%M:%S")

        except Request.DoesNotExist:
            pass
        except:
            response_data['status'] = '400'
            return HttpResponse(Json.dumps(response_data), content_type="application/json")


        response_data['status'] = '200'
        return HttpResponse(Json.dumps(response_data), content_type="application/json")

    elif request.method == 'POST':
        json = getJsonData(request.body)
        if json == False:
            response_data['status'] = '400'
            return HttpResponse(Json.dumps(response_data), content_type="application/json")

        try:
            d = Device.objects.get(device_id=json['device_id'])
        except:
            response_data['status'] = '400'
            return HttpResponse(Json.dumps(response_data), content_type="application/json")

        r = Request()
        r.device_id = d
        for key in {'request', 'value'}:
            if json.has_key(key) == False:
                response_data['status'] = '400'
                return HttpResponse(Json.dumps(response_data), content_type="application/json")
            code = compile("r.%s = json['%s']" % (key, key), '<string>', 'exec')
            exec code
        r.save()

        response_data['status'] = '200'
        return HttpResponse(Json.dumps(response_data), content_type="application/json")

    elif request.method == 'DELETE':
        json = getJsonData(request.body)
        if json == False:
            response_data['status'] = '400'
            return HttpResponse(Json.dumps(response_data), content_type="application/json")

        try:
            d = Device.objects.get(device_id=json['device_id'])
            r = Request.objects.filter(device_id=d, pk=json['request_id'])
            r.delete()
        except:
            response_data['status'] = '400'
            return HttpResponse(Json.dumps(response_data), content_type="application/json")

        response_data['status'] = '200'
        return HttpResponse(Json.dumps(response_data), content_type="application/json")

    else:
        raise Http404


@csrf_exempt
def api_device(request):
    from cloud.models import Device

    response_data = {}
    if request.method == 'DELETE':
        json = getJsonData(request.body)
        if json == False:
            response_data['status'] = '400'
            return HttpResponse(Json.dumps(response_data), content_type="application/json")

        try:
            d = Device.objects.get(device_id=json['device_id'])
            d.user = None
            d.save()
        except:
            response_data['status'] = '400'
            return HttpResponse(Json.dumps(response_data), content_type="application/json")

        response_data['status'] = '200'
        return HttpResponse(Json.dumps(response_data), content_type="application/json")

    else:
        raise Http404