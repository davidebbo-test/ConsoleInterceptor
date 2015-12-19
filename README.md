# ConsoleInterceptor

Intercept console output and save to file for Azure Web App logging from HttpPlatformHandler

To use it:

- Download `ConsoleInterceptor.exe` from the latest [releases](https://github.com/davidebbo-test/ConsoleInterceptor/releases). Or build it yourself if you prefer.
- Using [Kudu Console](https://github.com/projectkudu/kudu/wiki/Kudu-console), drag it into `d:\home\site` in you Azure Web App
- In your web.config's `httpPlatform` section, change `processPath` to use it, e.g.

```xml
<httpPlatform processPath="d:\home\site\ConsoleInterceptor D:\home\site\wwwroot\azureapp.exe" startupTimeLimit="60">
</httpPlatform>
```

And that's it. Now you should see logs come up under `D:\home\LogFiles\application`, and og streaming should work.
