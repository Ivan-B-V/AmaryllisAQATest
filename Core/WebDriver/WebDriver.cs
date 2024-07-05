using OpenQA.Selenium;

namespace Core.WebDriver;

public class WebDriver
{
    private static readonly ThreadLocal<IWebDriver> driverThreadLocal = new();

    private WebDriver() { }

    public static IWebDriver GetDriver()
    {
        driverThreadLocal.Value ??= WebDriverFactory.GetWebDriver();
        return driverThreadLocal.Value ?? throw new NullReferenceException("Couldnt create driver.");
    }

    public static void CloseDriver()
    {
        driverThreadLocal.Value?.Quit();
    }
}