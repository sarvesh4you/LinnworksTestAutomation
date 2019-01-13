using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Regex;
using System.Threading;
using static Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils.ConfigFileReader;

namespace LinnworksTests
{
    public class GetPage : BasePage
    {
        String location = Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + "/test/resources/specs/";

        public GetPage(string specName, IWebDriver driver) : base(specName, driver)
        {
        }

        public GetPage()
        {

        }


        protected IWebElement element(String name)
        {
            VerifyPageIsLoaded();
            String locatorType = null, locatorValue = null;
            String[] lines = System.IO.File.ReadAllLines(location + tier + "/" + this.specName + ".spec");
            foreach (String line in lines)
            {

                String[] locators = Regex.Split(line, @"[\s]{2,}");

                if (locators[0].Equals(name))
                {
                    if (locators.Length > 2)
                    {
                        locatorType = locators[1];
                        locatorValue = locators[2];
                    }
                }
            }
            wait.waitForElementToBeVisible(locator(locatorType, locatorValue));
            return driver.FindElement(locator(locatorType, locatorValue));
        }

        private By locator(String l, String v)
        {

            v = v.Trim();
            switch (l.ToUpper())
            {
                case "CSS":
                case "CSSSELECTOR":
                    return By.CssSelector(v);
                case "XPATH":
                    return By.XPath(v);
                case "ID":
                    return By.Id(v);
                default:
                    return null;
            }
        }


        public IWebElement element(String name, String replacement)
        {
            VerifyPageIsLoaded();
            String locatorType = null, locatorValue = null;
            String[] lines = System.IO.File.ReadAllLines(location + tier + "/" + this.specName + ".spec");
            foreach (String line in lines)
            {
                String[] locators = Regex.Split(line, @"[\s]{2,}");

                if (locators[0].Equals(name))
                {
                    if (locators.Length > 2)
                    {
                        locatorType = locators[1];
                        string pattern = "\\$\\{.+?\\}";

                        Regex rgx = new Regex(pattern);
                        locatorValue = rgx.Replace(locators[2], replacement);
                    }
                }
            }

            wait.waitForElementToBeVisible(locator(locatorType, locatorValue));
            return driver.FindElement(locator(locatorType, locatorValue));
        }

        public IWebElement element(String name, String replacement1, String replacement2)
        {
            VerifyPageIsLoaded();
            String locatorType = null, locatorValue = null;
            String[] lines = System.IO.File.ReadAllLines(location + tier + "/" + this.specName + ".spec");
            foreach (String line in lines)
            {
                String[] locators = Regex.Split(line, @"[\s]{2,}");
                if (locators[0].Equals(name))
                {
                    if (locators.Length > 2)
                    {
                        logMessage("xpath:" + locators[2]);

                        locatorType = locators[1];
                        string pattern1 = "\\$\\{.+?\\}";
                        Regex rgx1 = new Regex(pattern1);
                        locatorValue = rgx1.Replace(locators[2], replacement1);

                        string pattern2 = "\\%\\{.+?\\}";
                        Regex rgx2 = new Regex(pattern2);
                        locatorValue = rgx2.Replace(locators[2], replacement2);

                    }
                }
            }
            return driver.FindElement(locator(locatorType, locatorValue));
        }


       
        public Boolean isElementDisplayed(String elementName)
        {
            VerifyPageIsLoaded();
            Boolean result = element(elementName).Displayed;
            Assert.IsTrue(result, "TEST FAILED: element '" + elementName
                    + "' is not displayed.");
            logMessage("TEST PASSED: element " + elementName
                    + " is displayed.");

            return result;
        }

        public Boolean isElementDisplayed(String elementName, String elementTextReplace)
        {

            Thread.Sleep(1000);

            VerifyPageIsLoaded();
            Boolean result = element(elementName, elementTextReplace).Displayed;
            Assert.IsTrue(result,
                    "TEST FAILED: element '" + elementName + "with text " + elementTextReplace + "' is not displayed.");
            logMessage("TEST PASSED: element " + elementName + " with text " + elementTextReplace + " is displayed.");
            //new WebDriverWait(driver, TimeSpan.FromSeconds(75)).Until(ExpectedConditions.ElementToBeClickable(element(elementName, elementTextReplace)));
            return result;
        }

       
        public Boolean isElementNotDisplayed(String elementName, String elementTextReplace)
        {
            try
            {
                VerifyPageIsLoaded();
                wait.hardWait(3);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
                String locatorType = null, locatorValue = null;
                String[] lines = System.IO.File.ReadAllLines(location + tier + "/" + this.specName + ".spec");
                foreach (String line in lines)
                {
                    String[] locators = Regex.Split(line, @"[\s]{2,}");

                    if (locators[0].Equals(elementName))
                    {
                        if (locators.Length > 2)
                        {
                            locatorType = locators[1];
                            string pattern = "\\$\\{.+?\\}";

                            Regex rgx = new Regex(pattern);
                            locatorValue = rgx.Replace(locators[2], elementTextReplace);
                        }
                    }
                }
                Boolean result = driver.FindElement(locator(elementName, elementTextReplace)).Displayed;
                Assert.IsFalse(result,
                        "TEST FAILED: element '" + elementName + "with text " + elementTextReplace + "' is DISPLAYED!!!");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
                return result;
            }
            catch (Exception ex)
            {

                logMessage(
                        "TEST PASSED: element " + elementName + " with text " + elementTextReplace + " is NOT DISPLAYED");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            }
            return true;
        }

     
        public String logMessage(String message)
        {
            System.Console.WriteLine(message);
            return message;
        }

       

      
      

       

      
    }
}
