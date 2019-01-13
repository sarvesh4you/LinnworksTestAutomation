using Linnworks_Test_Automation.test.elements.com.linnworks.automation;
using Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;

namespace LinnnworksTests
{
    public class LinnworksBackEndTests
    {
        TestSessionInitiator test;

        [OneTimeSetUp()]
        public void Start_Test_Session_And_HandleTestMethodName()
        {
            
              test = new TestSessionInitiator("API");
              test.stepStartMessage(TestContext.CurrentContext.Test.Name);
    
        }


        [SetUp()]
        public void handleTestMethodName()
        {
           
            test.stepStartMessage(TestContext.CurrentContext.Test.Name);
        }


        /*
        * TC001 - [Verify that user is successfully able to login 
        * in to the API by using correct token]
        */
        [Test()]
        public void TC001_Login_To_The_Linnworks_Test_Api()
        {
            int statusCode = test.apiActions.loginIntoApi(YamlReader.getData("api_endpoint.loginAuth"), YamlReader.getData("user_account.token"));
            test.apiActions.veryResponseStatusCodeIs200(statusCode);
        }


        /*
        *  TC002 - [verify that user is able to fetch all the categories through the API]
        */
        [Test()]
        public void TC002_Fetch_All_The_Categories()
        {
            int statusCode = test.apiActions.fetchAllTheCategories(YamlReader.getData("api_endpoint.categoryIndex"));
            test.apiActions.veryResponseStatusCodeIs200(statusCode);


        }


        /*
        *  TC003 - [verify that user is able to fetch an existing category by it's ID]
        */
        [Test()]
        public void TC003_Fetch_An_Existing_Category_By_Id()
        {
            int statusCode = test.apiActions.fetchExistingCategoryByItsId(YamlReader.getData("api_endpoint.categoryById"), YamlReader.getData("test_category.id"), YamlReader.getData("test_category.name"));
            test.apiActions.veryResponseStatusCodeIs200(statusCode);
        }


        /*
         * TC004 - [verify that user is able to add a category]
         */
        [Test()]
        public void TC004_Add_A_New_Category()
        {
            int statusCode = test.apiActions.addNewCategory(YamlReader.getData("api_endpoint.createNewCategory"), YamlReader.getData("category_api.newCategoryId"), YamlReader.getData("category_api.newCategoryName"));
            test.apiActions.veryResponseStatusCodeIs200(statusCode);

        }


        /*
         * TC005 - [verify that user is able to delete a category]
         */
        [Test()]
        public void TC005_Delete_A_Category()
        {
            int statusCode = test.apiActions.deleteACategory(YamlReader.getData("api_endpoint.deleteCategory"));
            test.apiActions.veryResponseStatusCodeIs200(statusCode);
        }



        [TearDown()]
        public void take_screenshot_on_failure()
        {
           // TearDown

        }


        [OneTimeTearDown()]
        public void Tear_Down()
        {
          //  OneTimeTearDown
        }

    }
}
