using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace BlazorTest.Selenium
{
	public class Driver
	{
        public IWebDriver GetDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            return new ChromeDriver();
        }

	}
}

