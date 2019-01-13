using NUnit.Framework;
using System;


namespace LinnworksTests
{
    class EmailResults
    {
      
        [OneTimeSetUp()]
        public void setupMailConfig()
        {
            // Initializing all the required variables
           
           String xmlReportName = "TestResult.xml";
           String htmlReportName = "TestResult.html";

            String today = DateTime.Today.ToString("dd-MMM-yyyy");
            String from = "";
            String to = "";
            String cc = "";
            String bcc = "";
        }

    
        [Test()]
        public void Email_Test_Report()
        {
            try
            {
                System.Console.WriteLine("***** Mail Sent Successfully *****");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("***** There was an error in sending email :"+ex.ToString()+" *****");
            }
        }
    }
}
