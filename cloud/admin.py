from django.contrib import admin
from cloud.models import *

# Register your models here.
admin.site.register(Device, DeviceAdmin)
admin.site.register(Log, LogAdmin)
admin.site.register(Request, RequestAdmin)
admin.site.register(Status, StatusAdmin)
