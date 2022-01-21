using BaseApi.Configurations;
using Npgsql;
using System;

namespace BaseApi.Database
{
    public static class DBConfigurations
    {
        public static string Host => Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        public static string Username => Environment.GetEnvironmentVariable("DB_USERNAME") ?? "base-api";
        public static string Password => Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "base-api";
        public static string Database => Environment.GetEnvironmentVariable("DB_DATABASE") ?? AppConfigurations.ServiceName;
        public static int Port => int.Parse(Environment.GetEnvironmentVariable("DB_PORT") ?? "5432");        
        public static string Ssl => Environment.GetEnvironmentVariable("DB_SSL_MODE") ?? "Disable";

        public static string GetConnectionString()
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = Host,
                Username = Username,
                Password = Password,
                Port = Port,
                Database = $"{Database}",
                ApplicationName = AppConfigurations.ServiceName,                
                SslMode = Enum.Parse<SslMode>(Ssl)
            };

            return connectionStringBuilder.ConnectionString;
        }
    }
}