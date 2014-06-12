from django.conf.urls import patterns, url, include

from django.contrib import admin
admin.autodiscover()

urlpatterns = patterns('',
    # Django Admin
    url(r'^admin/', include(admin.site.urls)),

    # Login
    url(r'', include('django.contrib.auth.urls')),
    url(r'^accounts/', include('registration.backends.simple.urls')),

    # Management
    url(r'^$', 'cloud.views.index', name="index"),
    url(r'^dashboard/$', 'cloud.views.dashboard'),
    url(r'^register/$', 'cloud.views.register'),
    url(r'^device/(?P<p_device_id>\w+)$', 'cloud.views.device'),
    # url(r'^device/(?P<p_device_id>\w+)$/log/$', 'cloud.views.showlog'),

    # API of Devices
    url(r'^api/log/$', 'cloud.views.api_log'),
    url(r'^api/request/$', 'cloud.views.api_request'),
    url(r'^api/device/$', 'cloud.views.api_device'),

)
