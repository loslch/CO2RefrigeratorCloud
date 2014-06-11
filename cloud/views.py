from django.shortcuts import render, render_to_response
from django.http import HttpResponse, HttpResponseRedirect
from django.contrib import messages
# from cloud.models import DeviceForm


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

    from cloud.models import User, Device, DeviceForm

    try:
        d = Device.objects.get(device_id=p_device_id)
    except Device.DoesNotExist:
        messages.error(request, "Error: Device is doesn't exist.")
        return HttpResponseRedirect('/dashboard')

    if d.user != request.user:
        messages.error(request, 'Error: Uh-oh, something went wrong.')
        return HttpResponseRedirect('/dashboard')

    return render(request, 'device.html', {
        'device': p_device_id
    })


# def device(request):
# from cloud.models import Device
#     if request.method == 'POST': # If the form has been submitted...
#         # ContactForm was defined in the previous section
#         form = DeviceForm(request.POST) # A form bound to the POST data
#         if form.is_valid(): # All validation rules pass
#             # Process the data in form.cleaned_data
#             device_id = form.cleaned_data['device_id']
#             temperature = form.cleaned_data['temperature']
#
#             d = Device()
#             d.device_id = device_id
#             d.temperature = temperature
#             d.save()
#             return HttpResponseRedirect('/device/') # Redirect after POST
#     else:
#         from django.forms.models import modelformset_factory
#         DeviceFormSet = modelformset_factory(Device)
#         devices = DeviceFormSet()
#         form = DeviceForm() # An unbound form
#
#     return render(request, 'device.html', {
#         'form': form,
#         'devices': devices,
#     })
#
#
# def log(request, device):
#     from cloud.models import Device, Log
#     if request.method == 'POST': # If the form has been submitted...
#         form = DeviceForm(request.POST) # A form bound to the POST data
#
#         d = Device.objects.get(device_id=device)
#         if d == None:
#             d = Device()
#             d.device_id = device
#             d.temperature = 0
#             d.save()
#
#         l = Log()
#         l.device_id = d.device_id
#         l.log = form.cleaned_data['log']
#         l.log_time = form.cleaned_data['log_time']
#         l.save()
#         return HttpResponse('200')
#     else:
#         return HttpResponse('404')
#
#
