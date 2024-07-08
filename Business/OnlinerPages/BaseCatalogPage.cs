using Core.WebElement;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using static System.Net.Mime.MediaTypeNames;
using WebElement = Core.WebElement.WebElement;

namespace Business.OnlinerPages;

public abstract class BaseCatalogPage : BasePage
{
    #region Locators
    private readonly By comparisonButtonLocator = By.XPath("//div[contains(@class, 'compare')]//a");
    private readonly By nextPageButtonLocator = By.ClassName("catalog-pagination__main");
    private readonly By amountOfProductsFoundLocator = By.XPath("//span[contains(@class, 'sub_main')]");
    private readonly By foundProductsLocator = By.XPath("//div[contains(@class, 'unit_primary')]");
    private readonly By pageNumberLocator = By.XPath("//div[contains(@class, 'dropdown-value')]");

    private By ProductTitleWithTextAndNumberLocator(uint number, string text) => By.XPath($"//div[contains(@class, 'unit_primary')][{number}]//a[contains(@class, 'catalog-form__link_font-weight_semibold') and contains(text(), '{text}')]");
    private By DisableFilterButtonLocator(string value) => By.XPath($"//div[@class='catalog-form__sorting']//div[contains(text(), '{value}')]");
    #endregion

    protected BaseCatalogPage()
    {
        ComparisonButton = new WebElement(comparisonButtonLocator, "Comparison button");
        NextPageButton = new WebElement(nextPageButtonLocator, "Next page button");
        AmountOfProductsFound = new WebElement(amountOfProductsFoundLocator, "Amount of products found");
        PageNumber = new WebElement(pageNumberLocator, "Page number");
    }

    #region Elements
    public IWebElementCustom ComparisonButton { get; }
    public IWebElementCustom NextPageButton { get; }
    public IWebElementCustom AmountOfProductsFound { get; }
    public IWebElementCustom PageNumber { get; }
    public int AmountOfProductsOnThePage() => Core.WebDriver.WebDriver.GetDriver().FindElements(foundProductsLocator).Count;

    public IWebElementCustom GetDisableFilterButton(string filterValue) => new WebElement(DisableFilterButtonLocator(filterValue), $"Disable filter button: {filterValue}");
    #endregion

    public void ClickCompareButton()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(comparisonButtonLocator));
        ComparisonButton.Click();
    }

    public ICollection<string> GetProductsTitlesWithText(string text)
    {
        var productsAmount = AmountOfProductsOnThePage();
        List<string> result = new(productsAmount);
        for (uint i = 1; i <= productsAmount; i++)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(ProductTitleWithTextAndNumberLocator(i, text)));
            result.Add(Core.WebDriver.WebDriver.GetDriver().FindElement(ProductTitleWithTextAndNumberLocator(i, text)).Text);
        }
        return result;
    }

    public ICollection<ProductItemPage> GetProductItemPages()
    {
        var productsAmount = AmountOfProductsOnThePage();
        List<ProductItemPage> result = new(productsAmount);
        for (uint i = 1; i <= productsAmount; i++)
        {
            result.Add(new ProductItemPage(i));
        }
        return result;
    }
}