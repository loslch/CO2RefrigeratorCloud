from django import template
from django.db.models import Avg
from cloud.models import Device, Status
register = template.Library()


@register.filter
def is_display_devices_menu(u):
    devices = Device.objects.filter(user=u)
    if len(devices) > 0:
        return True
    else:
        return False


@register.filter
def get_my_devices(u):
    devices = Device.objects.filter(user=u)
    return devices


@register.filter
def get_my_devices_and_status(u):
    my_devices = Device.objects.filter(user=u)
    device_and_status = my_devices.select_related('status')
    return device_and_status


@register.filter
def get_avg_co2(u):
    my_devices = Device.objects.filter(user=u)
    device_and_status = my_devices.select_related('status')
    sum = 0
    for item in device_and_status:
        sum += item.status.co2
    return (sum/device_and_status.__len__())


@register.filter
def get_avg_o2(u):
    my_devices = Device.objects.filter(user=u)
    device_and_status = my_devices.select_related('status')
    sum = 0
    for item in device_and_status:
        sum += item.status.o2
    return (sum/device_and_status.__len__())


@register.filter
def get_avg_temperature(u):
    my_devices = Device.objects.filter(user=u)
    device_and_status = my_devices.select_related('status')
    sum = 0
    for item in device_and_status:
        sum += item.status.temperature
    return (sum/device_and_status.__len__())


@register.filter
def get_avg_humidity(u):
    my_devices = Device.objects.filter(user=u)
    device_and_status = my_devices.select_related('status')
    sum = 0
    for item in device_and_status:
        sum += item.status.humidity
    return (sum/device_and_status.__len__())