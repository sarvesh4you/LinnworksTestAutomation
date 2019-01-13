using System;
using System.Drawing.Imaging;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.IO;
using System.Diagnostics;
using static Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils.ConfigFileReader;

namespace Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils
{
    public class TakeScreenshot
    {
        private IWebDriver driver;

        public TakeScreenshot(IWebDriver driver)
        {

            this.driver = driver;
        }

        String screenshotPath = Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + "/screenshots/";

        public void takeScreenShotOnException(String className)
        {

            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Debug.WriteLine("******** Test failed ******");

                if (screenshot.Equals("true") || screenshot.Equals("yes"))
                {
                    try
                    {
                        if (driver != null)
                        {
                            takeScreenshot();
                        }
                    }
                    catch (Exception ex)
                    {
                       Debug.WriteLine(ex.ToString());
                    }
                }
                
            }
            else
            {
                Debug.WriteLine("******* Test Case Passed *******");

            }
        }

        public void takeScreenshot()
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            Directory.CreateDirectory(screenshotPath);
            String fp = screenshotPath + "_" + TestContext.CurrentContext.Test.FullName + ".png";
            Debug.WriteLine("Screenshot path : " + fp);
            screenshot.SaveAsFile(fp, ScreenshotImageFormat.Png);

        }
    }
}
