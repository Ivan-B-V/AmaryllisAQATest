using Core.Utilities;
using Core.WebDriver;
using OpenQA.Selenium.Support.UI;

namespace Business.OnlinerPages;

public abstract class BasePage
{
    protected WebDriverWait wait = new(WebDriver.GetDriver(), ConfigurationReader.GetAppSettings().WaitTime);

    protected BasePage() { }
}