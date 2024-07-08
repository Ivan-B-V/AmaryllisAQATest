using Core.WebDriver;
using NUnit.Framework;

namespace Tests.UITests;

public class BaseTest
{
    [SetUp]
    public void BaseSetUp()
    {
        WebDriver.GetDriver();
    }

    [TearDown]
    public void BaseTearDown()
    {
        WebDriver.CloseDriver();
    }
}
