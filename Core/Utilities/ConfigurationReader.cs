using Core.Models;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities;

public static class ConfigurationReader
{
    private static readonly IConfigurationRoot configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();

    public static AppSettings GetAppSettings()
    { 
        AppSettings appSettings = new();
        configurationRoot.GetSection(nameof(AppSettings)).Bind(appSettings);
        return appSettings;
    }
}
