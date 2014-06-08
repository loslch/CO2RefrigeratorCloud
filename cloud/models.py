from django.db import models

# Create your models here.

class User(models.Model):
    email = models.EmailField(primary_key=True)
    password = models.CharField(max_length=30)

class Device(models.Model):
    device_id = models.CharField(max_length=50, primary_key=True)
    temperature = models.FloatField()

class UserDevices(models.Model):
    user = models.ForeignKey(User)
    device_id = models.ForeignKey(Device)

class logs(models.Model):
    device_id = models.ForeignKey(Device)
    log = models.TextField()
    log_time = models.DateTimeField()

class Requests(models.Model):
    device_id = models.ForeignKey(Device)
    request = models.CharField(max_length=30)
