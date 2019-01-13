using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace LinnworksTests
{
    public class LoginPageActions : GetPage
    {
        public LoginPageActions(IWebDriver driver) : base("LoginPage", driver)
        {

        }

        public void loginIntoApplication(String token )
        {
            
            isElementDisplayed("tab_logIn");
            click(element("tab_logIn"));
            logMessage("User clicked on the 'Login' tab on left pannel.");

            isElementDisplayed("txtfld_token");
            sendText(element("txtfld_token"), token);
            logMessage("User entered '" + token + "' in token textfield.");

            click(element("btn_logIn"));
            logMessage("User clicked on 'Sign In' button");

            logMessage("User succesfully logged into the application.");

        }

        public void logoutFromTheApplication()
        {
            isElementDisplayed("tab_logOut");
            click(element("tab_logOut"));
            logMessage("User clicked on the 'Logout' link on left pannel.");
            Assert.IsTrue(isElementDisplayed("tab_logIn"), "ASSERTION FAILED : User is not able to logout.");
            logMessage("ASSERTION PASSED : User loggedout successfully.");

        }
    }
}
