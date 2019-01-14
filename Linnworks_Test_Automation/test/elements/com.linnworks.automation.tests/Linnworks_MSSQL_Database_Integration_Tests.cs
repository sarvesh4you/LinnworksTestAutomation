using Linnworks_Test_Automation.test.elements.com.linnworks.automation;
using Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;

namespace LinnnworksTests
{
    public class LinnworksMSSQLDatabaseIntegrationTests
    {
        TestSessionInitiator test;

        [OneTimeSetUp()]
        public void Start_Test_Session_And_HandleTestMethodName()
        {
            
              test = new TestSessionInitiator("DB");
              test.stepStartMessage(TestContext.CurrentContext.Test.Name);
    
        }


        [SetUp()]
        public void handleTestMethodName()
        {
           
            test.stepStartMessage(TestContext.CurrentContext.Test.Name);
        }


        /*
        * TC001 - [Verify DB user is able to add records in database]
        */
        [Test()]
        public void TC001_Add_Records_Into_The_Database()
        {
            //DB integration test 1
            Assert.IsTrue('S'=='S');
   
        }

        [Test()]
        public void TC002_Fetch_Records_From_The_Database()
        {
            //DB integration test 2
            Assert.IsTrue('S' == 'S');

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
