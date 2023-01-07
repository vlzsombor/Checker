using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;
using SeleniumExtras.WaitHelpers;
using Checker.Client.Data;

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
    public void TestKillFunction()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        var div = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("createGame")));

        driver.FindElement(By.Id("createGame")).Click();

        ((IJavaScriptExecutor)driver).ExecuteScript($"window.open('{driver.Url}');");
        driver.SwitchTo().Window(driver.WindowHandles.Last());
        var div2 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("joinTable")));

        driver.FindElement(By.Id("joinTable")).Click();

        driver.SwitchTo().Window(driver.WindowHandles.First());
        driver.FindElement(By.Id("cellId5-0")).Click();
        driver.FindElement(By.Id("cellId4-1")).Click();

        driver.SwitchTo().Window(driver.WindowHandles.Last());
        driver.FindElement(By.Id("cellId2-3")).Click();
        driver.FindElement(By.Id("cellId3-2")).Click();


        driver.SwitchTo().Window(driver.WindowHandles.First());
        driver.FindElement(By.Id("cellId4-1")).Click();
        driver.FindElement(By.Id("cellId2-3")).Click();
        var black = driver.FindElements(By.ClassName("black"));
        Assert.Equal(11, black.Count());
        Assert.Equal(12, driver.FindElements(By.ClassName("white")).Count());
    }

    [Fact]
    public void TestKingFunction()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        var div = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("createGame")));

        driver.FindElement(By.Id("createGame")).Click();

        ((IJavaScriptExecutor)driver).ExecuteScript($"window.open('{driver.Url}');");
        driver.SwitchTo().Window(driver.WindowHandles.Last());
        var div2 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("joinTable")));

        driver.FindElement(By.Id("joinTable")).Click();

        driver.SwitchTo().Window(driver.WindowHandles.First());
        driver.FindElement(By.Id("cellId5-0")).Click();
        driver.FindElement(By.Id("cellId4-1")).Click();

        driver.SwitchTo().Window(driver.WindowHandles.Last());
        driver.FindElement(By.Id("cellId2-3")).Click();
        driver.FindElement(By.Id("cellId3-2")).Click();


        driver.SwitchTo().Window(driver.WindowHandles.First());
        driver.FindElement(By.Id("cellId4-1")).Click();
        driver.FindElement(By.Id("cellId2-3")).Click();


        driver.SwitchTo().Window(driver.WindowHandles.Last());
        driver.FindElement(By.Id("cellId2-5")).Click();
        driver.FindElement(By.Id("cellId3-6")).Click();


        driver.SwitchTo().Window(driver.WindowHandles.First());
        driver.FindElement(By.Id("cellId6-1")).Click();
        driver.FindElement(By.Id("cellId5-0")).Click();

        driver.SwitchTo().Window(driver.WindowHandles.Last());
        driver.FindElement(By.Id("cellId1-6")).Click();
        driver.FindElement(By.Id("cellId2-5")).Click();

        driver.SwitchTo().Window(driver.WindowHandles.First());
        driver.FindElement(By.Id("cellId5-0")).Click();
        driver.FindElement(By.Id("cellId4-1")).Click();


        driver.SwitchTo().Window(driver.WindowHandles.Last());
        driver.FindElement(By.Id("cellId0-5")).Click();
        driver.FindElement(By.Id("cellId1-6")).Click();


        driver.SwitchTo().Window(driver.WindowHandles.First());
        driver.FindElement(By.Id("cellId2-3")).Click();
        driver.FindElement(By.Id("cellId0-5")).Click();

        var row = driver.FindElement(By.Id("cellId0-5"));
        var span = row.FindElement(By.TagName("span"));
        Assert.NotNull(span);
    }


    public void Dispose()
    {
        driver.Quit();
    }
}

