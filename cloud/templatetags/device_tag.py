from django import template
from cloud.models import Device
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