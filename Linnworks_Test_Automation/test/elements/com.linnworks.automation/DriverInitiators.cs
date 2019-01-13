using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils.ConfigFileReader;

namespace Linnworks_Test_Automation.test.elements.com.linnworks.automation
{
    public class DriverInitiators
    {
        IWebDriver driver;

        public IWebDriver getDriver()
        {

           
                if (server.ToUpper().Equals("LOCAL"))
                {
                    switch (browser.ToUpper())
                    {
                        case "CHROME":
                            return getChromeDriver(); // current implementation
                        case "FIREFOX":
                            return getChromeDriver(); // future implementation
                        default:
                            return getChromeDriver();
                    }
                }
                else
                {
                    return getChromeDriver();
                }
           
        }

        public IWebDriver getChromeDriver()
        {
            driver = new ChromeDriver(getChromeDriverPath());
            driver.Manage().Window.Maximize();

            return driver;
        }
    
    }
}
