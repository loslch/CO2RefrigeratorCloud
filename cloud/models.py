from django.db import models
from django.contrib.auth.models import User
from django import forms

# class User(models.Model):
#     user = models.OneToOneField(User)
#
#     def __unicode__(self):
#         return u'%s' % (self.user.email)

class Device(models.Model):
    device_id = models.CharField(max_length=50, primary_key=True)
    temperature = models.FloatField()

    def __unicode__(self):
        return u'%s' % (self.device_id)

class UserDevice(models.Model):
    user = models.ForeignKey(User)
    device_id = models.ForeignKey(Device)

    def __unicode__(self):
        return u'%s, %s' % (self.user, self.device_id)

class Log(models.Model):
    device_id = models.ForeignKey(Device)
    log = models.TextField()
    log_time = models.DateTimeField()

    def __unicode__(self):
        return u'%s, %s' % (self.device_id, self.log_time)

class Request(models.Model):
    device_id = models.ForeignKey(Device)
    request = models.CharField(max_length=30)

    def __unicode__(self):
        return u'%s, %s' % (self.device_id, self.request)


class DeviceForm(forms.Form):
    device_id = forms.CharField(max_length=50)
    temperature = forms.FloatField()