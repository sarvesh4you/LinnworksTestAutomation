using Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LinnworksTests
{
    public class BasePage 
    {
        protected WaitUtil wait;
        protected IWebDriver driver;
        protected String specName;

        public BasePage(string specName, IWebDriver driver)
        {
            this.specName = specName;
            this.driver = driver;
            this.wait = new WaitUtil(driver);

        }

        public BasePage()
        {
           
        }
      
     
        public String logMessage(String message)
        {
            System.Diagnostics.Debug.WriteLine(message);
            return message;
        }


        public String getCurrentURL()
        {
            return driver.Url;
        }


        public void navigateOnBackPage()
        {
            driver.Navigate().Back();
            logMessage("User navigated on back page.");
        }
     

        public void sendText(IWebElement el, String text)
        {
            el.Clear();
            el.SendKeys(text);
        }


        public void scrollDown(IWebElement element)
        {

            ((IJavaScriptExecutor)driver).ExecuteScript(
                    "arguments[0].scrollIntoView(true);", element);
        }


        public void click(IWebElement element)
        {
            try
            {
                scrollDown(element);
                element.Click();
            }
            catch (StaleElementReferenceException ex1)
            {
                wait.hardWait(2);
                scrollDown(element);
                element.Click();
                logMessage("Clicked Element " + element
                        + " after catching Stale Element Exception");
            }
            catch (Exception ex2)
            {
                logMessage("Element " + element + " could not be clicked! "
                        + ex2.Message);
            }
        }

     

        public void VerifyPageIsLoaded()
        {
            try
            {
                var pageLoaded = false;

                for (var i = 0; i < 360; i++)
                {
                    Thread.Sleep(500);

                    if (driver.ExecuteJavaScript<string>("return document.readyState").Equals("complete"))
                    {
                        pageLoaded = true;
                        break;
                    }
                }

                if (!pageLoaded)
                {
                    throw new Exception("Page was not with complete state)!");
                }
            }catch(Exception ex)
            {
                logMessage("Page has not loaded completely");
            }
        }


        public void handleAlert()
        {

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.AlertIsPresent()).Accept();
                logMessage("Alert handled..");
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("No Alert window appeared...");
            }
        }


    }
}