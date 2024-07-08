using Core.Models;
using OpenQA.Selenium;
using WebElement = Core.WebElement.WebElement;

namespace Business.OnlinerPages;

public class CpuCatalogPage : BaseCatalogPage
{
    #region Locators
    private By ManufacturerCheckboxLocator(string manufacturer) => By.XPath($"//div[contains(@class, 'checkbox-sign') and contains(text(), '{manufacturer}')]/../../div[@class='i-checkbox__faux']");
    #endregion

    public CpuCatalogPage() { }

    #region Elements
    public WebElement GetManufacturerCheckbox(string manufacturer) => new(ManufacturerCheckboxLocator(manufacturer), $"{manufacturer} checkbox");

    #endregion

    public CpuCatalogPage ApplyFilter(CpuFilter filter)
    {
        GetManufacturerCheckbox(filter.Manufacturer.ToString()).Click();
        return this;
    }
}