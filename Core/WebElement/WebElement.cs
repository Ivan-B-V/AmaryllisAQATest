using Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Core.WebElement;
using WebDriver = WebDriver.WebDriver;

public sealed class WebElement : IWebElementCustom
{
    private readonly WebDriverWait wait;
    public By By { get; private set; }
    public string Name { get; private set; }

    public WebElement(By by, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
        }
        wait = new WebDriverWait(WebDriver.GetDriver(), ConfigurationReader.GetAppSettings().WaitTime);
        Name = name;
        By = by;
    }

    public IWebElement Element => GetElement();

    public IWebElement GetElement()
    {
        var elements = WebDriver.GetDriver().FindElements(By);

        if (elements.Count == 0)
        {
            throw new NotFoundException($"There are no element with such by: {By}");
        }
        else
        {
            return elements.First();
        }
    }

    public void Click()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(By));
        Element.Click();
    }

    public void SendKeys(string keys)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(By));
        Element.SendKeys(keys);
    }

    public void Clear()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(By));
        Element.Clear();
    }

    public void Submit()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(By));
        Element.Submit();
    }

    public string Text()
    {
        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By));
        return Element.Text;
    }
}