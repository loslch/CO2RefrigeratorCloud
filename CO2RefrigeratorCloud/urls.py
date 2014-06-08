from django.conf.urls import patterns, url, include

# from django.contrib import admin
# admin.autodiscover()

urlpatterns = patterns('',
    url(r'^$', 'cloud.views.home', name="index"),
    url(r'^cj/$', 'cloud.views.cj'),

    # url(r'^admin/', include(admin.site.urls)),
    url(r'', include('django.contrib.auth.urls')),
    url(r'^accounts/', include('registration.backends.simple.urls')),
    url(r'^users/(?P<username>\w+)', 'cloud.views.users')
)
