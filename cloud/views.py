from django.shortcuts import render_to_response
from django.http import HttpResponse, HttpResponseRedirect
from django.contrib.auth import authenticate, login
from django.template import RequestContext

def home(request):
    return render_to_response('home.html')

def cj(request):
    return HttpResponse('hello world cj')

def users(request, username):
    message = "Hello %s!" % username
    return HttpResponse(message)