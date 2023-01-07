using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;
using SeleniumExtras.WaitHelpers;

namespace BlazorTest.Selenium;

public class SeleniumTests : IDisposable
{
    private readonly IWebDriver driver;

    public SeleniumTests()
    {
        driver = new Driver().GetDriver();
        driver.Navigate().GoToUrl(new Uri("http://localhost:49835/"));



    }

    [Fact]
    public void Test1()
    {
        //driver.FindElement(By.CssSelector)
        //driver.FindElement(By.CssSelector)


        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        var div = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("createGame")));

        driver.FindElement(By.Id("createGame")).Click();

        ((IJavaScriptExecutor)driver).ExecuteScript($"window.open('{driver.Url}');");
        driver.SwitchTo().Window(driver.WindowHandles.Last());
        var div2 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("joinTable")));

        driver.FindElement(By.Id("joinTable")).Click();

        driver.SwitchTo().Window(driver.WindowHandles.First());


        driver.FindElement(By.Id("cellId5-0")).Click();


        Assert.True(false);
    }

    public void Dispose()
    {
        driver.Quit();
    }
}

