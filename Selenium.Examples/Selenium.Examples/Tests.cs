using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using Selenium.Examples.Performance;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
namespace Selenium.Examples
{
    public class Tests
    {
        private IWebDriver _driver;

        public void Setup()
        {
            //ChromeOptions chromeOptions;
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = "C:\\Selenium Drivers\\chromedriver.exe";
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "C:\\Selenium Drivers\\chromedriver.exe");

            //options.AddExtensions("\path\to\extension.crx");
            //options.BinaryLocation = "\path\to\chrome";
            _driver = (IWebDriver)new ChromeDriver("C:\\Selenium Drivers");
          //  _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            Console.WriteLine("Done Waiting");
        }

        public void GetPageLoadTime()
        {
            _driver.Navigate()
                .GoToUrl("http://www.deanhume.com/home/about");
            Console.WriteLine("Waiting");
            // Get the webTimings for our performance measurements
            Dictionary<string, object> webTimings =_driver.WebTimings();
            Console.WriteLine("Done waiting");

            if (webTimings.Count == 0)
            {
                Assert.Fail();
                Console.WriteLine("Fail");
            }
        }



        public void FixtureTearDown()
        {
            if (_driver != null) _driver.Close();
            Console.WriteLine("TearDown");
        }

        static int Main(string [] args)
        {
            //Tests test = new Tests();
            Console.WriteLine("I am in Main");
           // test.Setup();
            //test.GetPageLoadTime();
            //test.FixtureTearDown();
            //Console.Read();
            IWebDriver webDriver = (IWebDriver)new ChromeDriver("C:\\Selenium Drivers");
            webDriver.Navigate().GoToUrl("http://www.facebook.com");

            IList<IWebElement> links = (IList<IWebElement>)webDriver.FindElements(By.TagName("img"));
            Console.WriteLine(links);
            foreach (IWebElement link in links)
            {
                string text = link.GetAttribute("src");
                Console.WriteLine(text);
            }

            IList<IWebElement> link2 = (IList<IWebElement>)webDriver.FindElements(By.TagName("form"));
            Console.WriteLine("Form Actions: ");
            foreach (IWebElement link in link2)
            {
                string text = link.GetAttribute("action");
                Console.WriteLine(text);
            }


            Console.Read();
            webDriver.Quit();
            return 0;

        }
    }
}
