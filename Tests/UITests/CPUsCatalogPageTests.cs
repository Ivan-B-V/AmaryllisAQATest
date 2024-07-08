using AngleSharp;
using Business.OnlinerPages;
using Core.Enums;
using Core.Models;
using Core.Utilities;
using Core.WebDriver;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Tests.UITests;

[TestFixture]
public class CPUsCatalogPageTests : BaseTest
{
    [SetUp]
    public void TestsSetUp()
    {
        WebDriver.GetDriver()
                 .Navigate()
                 .GoToUrl(ConfigurationReader.GetUiTestsUrls().CpuCatalogPageUrl);
    }

    [Test]
    [TestCase(30)]
    public void DefaultCountOfProductsOnPageTest(int expectedPrductsCount)
    {
        var countOfFoundProducts = new CpuCatalogPage().AmountOfProductsOnThePage();

        Assert.That(expectedPrductsCount == countOfFoundProducts, $"Count of found products pre page is {countOfFoundProducts}");
    }

    [Test]
    public void OpenNextPageTest()
    {
        var page = new CpuCatalogPage();
        var previousPageNumber = Int32.Parse(page.PageNumber.Text());
        page.NextPageButton.Click();
        var currentPageNumber = Int32.Parse(page.PageNumber.Text());
        Assert.That(previousPageNumber + 1 == currentPageNumber, $"Previous page is {previousPageNumber}, current is {currentPageNumber}");
    }

    [Test]
    public void ManufacturerFilterTest()
    {
        var testFilter = new CpuFilter
        {
            Manufacturer = CPUsManufacturers.Intel
        };

        var page = new CpuCatalogPage().ApplyFilter(testFilter);
        var titles = page.GetProductsTitlesWithText(testFilter.Manufacturer.ToString());
        
        bool isAllTitlesContainsText = false;
        foreach (var title in titles) 
        {
           isAllTitlesContainsText = title.Contains(testFilter.Manufacturer.ToString());
        }
        Assert.That(isAllTitlesContainsText, $"Not all products filtered with manufacturer: {testFilter.Manufacturer}.");
    }

    [Test]
    public void DisableFilterButtonAppearsTest()
    {
        var testFilter = new CpuFilter
        {
            Manufacturer = CPUsManufacturers.Intel
        };

        var page = new CpuCatalogPage().ApplyFilter(testFilter);
        var textFromElement = page.GetDisableFilterButton(CPUsManufacturers.Intel.ToString()).Text();
        Assert.That(textFromElement.Equals(testFilter.Manufacturer.ToString()));
    }


    [Test]
    public void ComparisonButtonTest()
    {
        var catalogPage = new CpuCatalogPage();
        var productsItemPages = catalogPage.GetProductItemPages();
        int middleNumber = productsItemPages.Count / 2;
        productsItemPages.First().SelectToCompare();
        productsItemPages.ElementAt(middleNumber).SelectToCompare();
        productsItemPages.Last().SelectToCompare();

        catalogPage.ClickCompareButton();
        var comparisonPage = new ProductsComparisonPage();

        Assert.That(comparisonPage.GetPageTitleText() is not null);
    }
}