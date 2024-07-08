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

    public static ApiSettings GetApiSettings()
    {
        ApiSettings apiSettings = new();
        configurationRoot.GetSection(nameof(ApiSettings)).Bind(apiSettings);
        return apiSettings;
    }

    public static UiTestsUrls GetUiTestsUrls()
    {
        UiTestsUrls uiTestsUrls = new();
        configurationRoot.GetSection(nameof(UiTestsUrls)).Bind(uiTestsUrls);
        return uiTestsUrls;
    }
}
