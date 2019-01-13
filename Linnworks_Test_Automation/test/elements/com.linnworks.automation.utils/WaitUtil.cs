using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils
{
    public class WaitUtil
    {
        IWebDriver driver;
        WebDriverWait wait;
        int timeout;

        public WaitUtil(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            timeout = Int32.Parse(ConfigFileReader.timeout);
        }

        public void waitForElementToBeVisible(By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public Boolean waitForPageTitleToContain(String expectedPagetitle)
        {
            return wait.Until(ExpectedConditions.TitleContains(expectedPagetitle));
        }

        public void hardWait(int seconds)
        {
            try
            {
                Thread.Sleep(seconds * 1000);
            }
            catch (ThreadInterruptedException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        
    }
}

