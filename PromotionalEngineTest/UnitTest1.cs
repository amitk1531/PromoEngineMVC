using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.IO;

namespace PromotionalEngineTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test Method for Checking the Calculated Value with expected value
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://localhost:5204/PromotionEngine/Index");

            IWebElement elementA = driver.FindElement(By.Id("A"));
            IWebElement elementB = driver.FindElement(By.Id("B"));
            IWebElement elementC = driver.FindElement(By.Id("C"));
            IWebElement elementD = driver.FindElement(By.Id("D"));
            
            IWebElement elementCalculate = driver.FindElement(By.Id("cal"));

            elementA.Click();
            elementA.SendKeys("3");

            elementB.Click();
            elementB.SendKeys("5");

            elementC.Click();
            elementC.SendKeys("1");

            elementD.Click();
            elementD.SendKeys("1");
            Actions actions = new Actions(driver);

            actions.MoveToElement(elementCalculate).Click().Perform();
            
            Thread.Sleep(6000);

            IWebElement elementTotalValue = driver.FindElement(By.Id("Total"));

            int totalValuePopulated = Convert.ToInt32(elementTotalValue.GetAttribute("value"));

            // Writing Test Result to C:\TestResult.txt
            if (totalValuePopulated == 280)
            {
                File.WriteAllText(@"C:\TestResult.txt", "Success");                
            }
            else
            {
                File.WriteAllText(@"C:\TestResult.txt", "Failed");
            }

            driver.Close();
        }
    }
}
