using Core.WebElement;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WebElement = Core.WebElement.WebElement;

namespace Business.OnlinerPages;

public class ProductItemPage : BasePage
{
    private readonly uint number;
    
    #region Locators
    private By ProductTitleLocator => By.XPath($"//div[contains(@class, 'unit_primary')][{number}]//a[contains(@class, 'catalog-form__link_font-weight_semibold')]");
    private By ProductComparisonCheckboxLocator => By.XPath($"//div[contains(@class, 'unit_primary')][{number}]//label[@title='К сравнению']");
    #endregion

    public ProductItemPage(uint number)
    {
        this.number = number;
        Title = new WebElement(ProductTitleLocator, $"Product number:{number} title.");
        ComparisonCheckbox = new WebElement(ProductComparisonCheckboxLocator, $"Product number: {number} comparison checkbox.");
    }

    #region Elements
    public IWebElementCustom Title { get; } 
    public IWebElementCustom ComparisonCheckbox { get; }
    #endregion

    public string GetTitle()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(ProductTitleLocator));
        return Title.Text();
    }

    public ProductItemPage SelectToCompare()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(ProductComparisonCheckboxLocator));
        ComparisonCheckbox.Click();
        return this;
    }
}