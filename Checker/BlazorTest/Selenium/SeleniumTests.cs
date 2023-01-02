using System;
using OpenQA.Selenium;

namespace BlazorTest.Selenium
{
	public class SeleniumTests : IDisposable
	{
        private readonly IWebDriver driver;

        public SeleniumTests()
		{
			driver = new Driver().GetDriver();
            driver.Navigate().GoToUrl(new Uri("http://google.com"));
        }


        [Fact]
        public void Test1()
        {
            //driver.FindElement(By.CssSelector)

            driver.FindElement(By.CssSelector("#L2AGLb > div")).Click();
            driver.FindElement(By.CssSelector("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.FPdoLc.lJ9FBc > center > input.RNmpXc")).Click();


            Assert.True(false);
        }
        
        public void Dispose()
        {
            driver.Quit();
        }
    }
}

