using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumTests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://localhost:7114/";
            IWebElement advancedbtn = driver.FindElement(By.Id("details-button"));
            IWebElement link = driver.FindElement(By.Id("proceed-link"));

            advancedbtn.Click();
            link.Click();
        }

        [TestCase("20", "rural", "5")]
        //[TestCase("35", "rural", "2.5")]
        //[TestCase("60", "rural", "1.25")]

        //[TestCase("20", "urban", "6")]
        //[TestCase("35", "urban", "5")]
        //[TestCase("60", "urban", "2.5")]

        //[TestCase("0", "rural", "0")]
        //[TestCase("18", "rural", "5")]
        //[TestCase("30", "rural", "5")]
        //[TestCase("31", "rural", "2.5")]

        //[TestCase("0", "urban", "0")]
        //[TestCase("18", "urban", "6")]
        //[TestCase("36", "urban", "5")]

        //[TestCase("-1", "rural", "0")]
        //[TestCase("25", "town", "0")]

        public void Test(string age, string location, string answer)
        {
            IWebElement iAge = driver.FindElement(By.Id("iAge"));
            iAge.SendKeys(age);

            IWebElement iLocation = driver.FindElement(By.Id("iLocation"));
            iLocation.SendKeys(location);

            IWebElement oResult = driver.FindElement(By.Id("oResult"));

            IWebElement btn = driver.FindElement(By.Id("btn"));
            btn.Click();

            Assert.That(oResult.GetAttribute("innerHTML").ToString(), Is.EqualTo(answer));
        }

        [OneTimeTearDown]
        public void Close()
        {
            //driver.Close();
        }
    }
}



