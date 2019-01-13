using Linnworks_Test_Automation.test.elements.com.linnworks.automation;
using Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils;
using NUnit.Framework;

namespace LinnnworksTests
{
    public class LinnworksFrontEndTests
    {
        TestSessionInitiator test;

        [OneTimeSetUp()]
        public void Start_Test_Session_And_HandleTestMethodName()
        {
            test = new TestSessionInitiator("WEB");
            test.stepStartMessage(TestContext.CurrentContext.Test.Name);
            test.launchApplication(YamlReader.getData("app_url"), YamlReader.getData("pageTitle"));
        }


        [SetUp()]
        public void handleTestMethodName()
        {
            test.stepStartMessage(TestContext.CurrentContext.Test.Name);
        }


        /*
         * TC001 - [Verify that user is successfully able to login 
         * in to the application by using correct token]
         */
        [Test()]
        public void TC001_Login_To_The_Linnworks_Test_Application()
        {
            test.loginPageActions.loginIntoApplication(YamlReader.getData("user_account.token"));
            test.categoriesPageActions.verifyUserIsOnCategoriesPage();
        }


        /*
        *  TC002 - [verify that user is able to create a new category]
        */
        [Test()]
        public void TC002_Create_A_New_Category()
        {
            test.categoriesPageActions.createNewCategory(YamlReader.getData("category_web.newCategoryName"));
            test.categoriesPageActions.verifyCategoryIsDisplayingOnCategoriesPageList(YamlReader.getData("category_web.newCategoryName"));


        }


        /*
        *  TC003 - [verify that user is able to editing an existing category]
        */
        [Test()]
        public void TC003_Edit_An_Existing_Category()
        {
            test.categoriesPageActions.editAnExistingCategory(YamlReader.getData("category_web.newCategoryName"), YamlReader.getData("category_web.editedCategoryName"));
            test.categoriesPageActions.verifyCategoryIsDisplayingOnCategoriesPageList(YamlReader.getData("category_web.editedCategoryName"));
        }


        /*
         * TC004 - [verify that user is able to delete a category]
         */
        [Test()]
        public void TC004_Delete_An_Existing_Category()
        {
            test.categoriesPageActions.deleteAnExistingCategory(YamlReader.getData("category_web.editedCategoryName"));
            test.categoriesPageActions.verifyCategoryIsNotDisplayingOnCategoriesPageList(YamlReader.getData("category_web.editedCategoryName"));

        }


        /*
         * TC005 - [verify that user is able to logout successfully from the application]
         */
        [Test()]
        public void TC005_Logout_From_The_Linnworks_Test_Application()
        {
            test.loginPageActions.logoutFromTheApplication();
        }


        [TearDown()]
        public void take_screenshot_on_failure()
        {
            test.takescreenshot.takeScreenShotOnException(GetType().Name);

        }


        [OneTimeTearDown()]
        public void Tear_Down()
        {
            test.TearDown();
        }

    }
}
