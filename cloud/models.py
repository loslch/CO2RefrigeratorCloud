from django.db import models
from django.contrib.auth.models import User
from django.contrib import admin
from django import forms

# class User(AbstractBaseUser):
#     username = models.CharField(max_length=40, unique=True)
#
#     USERNAME_FIELD = 'username'
#
#     def __unicode__(self):
#         return u'%s' % (self.get_username())

class Device(models.Model):
    device_id = models.CharField(max_length=50, primary_key=True)
    user = models.ForeignKey(User, null=True, blank=True)

    def __unicode__(self):
        return u'%s' % (self.device_id)

class DeviceForm(forms.Form):
    device_id = forms.CharField(max_length=50)
    user = forms.CharField()

class DeviceAdmin(admin.ModelAdmin):
    list_display = ('device_id', 'user')

class Status(models.Model):
    device_id = models.OneToOneField(Device)
    power = models.NullBooleanField(default=True, null=True)
    co2 = models.FloatField(null=True)
    o2 = models.FloatField(null=True)
    temperature = models.FloatField(null=True)
    humidity = models.FloatField(null=True)

    def __unicode__(self):
        return u'%s' % (self.device_id)

class StatusAdmin(admin.ModelAdmin):
    list_display = ('device_id', 'co2', 'o2', 'temperature', 'humidity', 'power')

class Log(models.Model):
    device_id = models.ForeignKey(Device)
    log = models.TextField(blank=False, null=False)
    log_time = models.DateTimeField(auto_now=True, null=True)

    def __unicode__(self):
        return u'%s, %s' % (self.device_id, self.log)

class LogAdmin(admin.ModelAdmin):
    list_display = ('device_id', 'log', 'log_time')

class Request(models.Model):
    device_id = models.ForeignKey(Device)
    request = models.CharField(max_length=30)
    value = models.FloatField()
    req_time = models.DateTimeField(auto_now=True, null=True)
    isSended = models.BooleanField(default=False)

    def __unicode__(self):
        return u'%s, %s' % (self.device_id, self.request)

class RequestAdmin(admin.ModelAdmin):
    list_display = ('device_id', 'request', 'value', 'req_time', 'isSended')