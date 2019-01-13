using Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils;
using LinnworksTests;
using OpenQA.Selenium;
using RestSharp;
using System;

namespace Linnworks_Test_Automation.test.elements.com.linnworks.automation
{
    public class TestSessionInitiator
    {

        private IWebDriver driver;
        private RestClient client;
        WaitUtil wait;
        public TakeScreenshot takescreenshot;
        public CategoriesPageActions categoriesPageActions;
        public LoginPageActions loginPageActions;
        public ApiActions apiActions;
     
        public TestSessionInitiator(String testType)
        {
            new ConfigFileReader();
            if (testType.Equals("WEB"))
            {
                driver = (new DriverInitiators()).getDriver();
                wait = new WaitUtil(driver);
                _initPages();
                takescreenshot = new TakeScreenshot(driver);

            }
            else if (testType.Equals("API"))
            {
                _initApi();
            }  

        }

        public void _initPages()
        {
            categoriesPageActions = new CategoriesPageActions(driver);
            loginPageActions = new LoginPageActions(driver);
            apiActions = new ApiActions(client);
        }

        public void _initApi()
        {
            apiActions = new ApiActions(client);
        }

        public void stepStartMessage(String testStepName)
        {
            
            System.Console.WriteLine("");
            System.Console.WriteLine("=================================================================================================");
            System.Console.WriteLine("***** STARTING TEST STEP:- " + testStepName + " *****");
            System.Console.WriteLine("=================================================================================================");
            System.Console.WriteLine("*************************************************************************************************");
            System.Console.WriteLine(" ");
        }

        public void launchApplication(String baseUrl, String pageTitle)
        {
            System.Console.WriteLine("\nApplication url is :- " + baseUrl);
            driver.Url = baseUrl;
        }


        public void TearDown()
        {

            driver.Quit();
            System.Diagnostics.Debug.WriteLine("Browser closed");
        }

    }
}
