from django.shortcuts import render, render_to_response
from django.http import HttpResponse, HttpResponseRedirect
from django.contrib.auth import authenticate, login
from django.template import RequestContext
from cloud.models import DeviceForm

def home(request):
    return render_to_response('registration/view_data.html')

def cj(request):
    return HttpResponse('hello world cj')

def users(request, username):
    message = "Hello %s!" % username
    return HttpResponse(message)

def user_test(request):
    from cloud.models import User
    u = User.objects.get(user_id=id)
    u=User()
    u.user_id = id
    return render(request,{'user_id':id})

     

def device(request):
    from cloud.models import Device
    if request.method == 'POST': # If the form has been submitted...
        # ContactForm was defined in the previous section
        form = DeviceForm(request.POST) # A form bound to the POST data
        if form.is_valid(): # All validation rules pass
            # Process the data in form.cleaned_data
            device_id = form.cleaned_data['device_id']
            temperature = form.cleaned_data['temperature']

            d = Device()
            d.device_id = device_id
            d.temperature = temperature
            d.save()
            return HttpResponseRedirect('/device/') # Redirect after POST
    else:
        from django.forms.models import modelformset_factory
        DeviceFormSet = modelformset_factory(Device)
        devices = DeviceFormSet()
        form = DeviceForm() # An unbound form

    return render(request, 'device.html', {
        'form': form,
        'devices': devices,
    })

def log(request, device):
    from cloud.models import Device, Log
    if request.method == 'POST': # If the form has been submitted...
        form = DeviceForm(request.POST) # A form bound to the POST data

        d = Device.objects.get(device_id=device)
        if d == None:
            d = Device()
            d.device_id = device
            d.temperature = 0
            d.save()

        l = Log()
        l.device_id = d.device_id
        l.log = form.cleaned_data['log']
        l.log_time = form.cleaned_data['log_time']
        l.save()
        return HttpResponse('200')
    else:
        return HttpResponse('404')

# def view_data(request):
#     return HttpResponse('view_data.html')
#
#
# def createRecipe_form(request):
#     c = {}
#     c.update(csrf(request))
#     return render_to_response('create.html',c)
#
# def create_recipe(request):
#     if request.method == 'POST':
#         form=RecipeForm(request.POST)
#         if form.is_valid():
#             title=form.cleaned_data['recipe_name']
#             return HttpResponseRedirect('display.html')
#         else:
#             form=RecipeForm()
#             return  render(request, 'create.html', {
#         'form': form,
#     })