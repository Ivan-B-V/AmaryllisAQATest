using Core.Enums;
using Core.Models;
using Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Core.WebDriver;

public static class WebDriverFactory
{
    private static readonly AppSettings appSettings = ConfigurationReader.GetAppSettings();
    private static readonly List<string> driverOptions = ["--start-maximized"];

    public static IWebDriver GetWebDriver()
    {
        return appSettings.BrowserType switch
        {
            BrowserTypes.Chrome => SetUpChromeDriver(),
            BrowserTypes.Edge => SetUpChromeDriver(),
            BrowserTypes.Firefox => SetUpChromeDriver(),
            _ => SetUpChromeDriver()
        };
    }

    private static ChromeDriver SetUpChromeDriver()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        ChromeOptions options = new();
        options.AddArguments(driverOptions);
        return new ChromeDriver(options);
    }
}