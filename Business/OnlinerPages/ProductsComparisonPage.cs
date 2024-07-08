using Core.WebElement;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WebElement = Core.WebElement.WebElement;

namespace Business.OnlinerPages;

public class ProductsComparisonPage : BasePage
{
    #region Locators
    private By PageTitleLocator => By.ClassName("b-offers-title"); //"//div[@class='catalog-top']//h1"
    #endregion

    public ProductsComparisonPage()
    {
        PageTitle = new WebElement(PageTitleLocator, "Comparison page title");
    }

    #region Elements
    public IWebElementCustom PageTitle { get; }
    #endregion

    public string GetPageTitleText()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(PageTitleLocator));
        return PageTitle.Text();
    }
}