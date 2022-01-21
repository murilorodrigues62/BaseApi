using System;

namespace BaseApi.Configurations
{
    public class AppConfigurations
    {
        public static string ServiceName => Environment.GetEnvironmentVariable("SERVICE_NAME") ?? "base-api";
    }
}
