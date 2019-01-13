using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Management;


namespace Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils
{
    public class ConfigFileReader
    {
        public static String defaultConfigFile = Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + "/test/resources/configs/Config.properties";
        public static String tier;
        public static String browser;
        public static String seleniumserver;
        public static String platform;
        public static String server;
        public static Dictionary<String, String> sessionInfo = null;
        public static String timeout;
        public static String screenshot;

        public ConfigFileReader()
        {
            sessionInfo = new Dictionary<String, String>();
            foreach (var row in File.ReadAllLines(defaultConfigFile))
                sessionInfo.Add(row.Split('=')[0], row.Split('=')[1]);
            setBrowser();
            setTier();
            setTimeout();
            setScreenshot();
            setPlatform();
            setServer();


        }

        public static void setTimeout()
        {

            timeout = sessionInfo["timeout"];
        }

        public static void setScreenshot()
        {

            screenshot = sessionInfo["take-screenshot"];
        }

        public static void setTier()
        {


            if (TestContext.Parameters["tier"] != null)
            {
                tier = TestContext.Parameters["tier"];

            }
            else
            {

                tier = sessionInfo["tier"];
            }
        }

        public static void setServer()
        {


            if (TestContext.Parameters["server"] != null)
            {
                server = TestContext.Parameters["server"];

            }
            else
            {

                server = sessionInfo["server"];
            }


        }

        public static void setPlatform()
        {


            if (TestContext.Parameters["platform"] != null)
            {
                platform = TestContext.Parameters["platform"];

            }
            else
            {

                platform = sessionInfo["platform"];
            }


        }

        public static void setBrowser()
        {
            if (TestContext.Parameters["browser"] != null)
            {
                browser = TestContext.Parameters["browser"];


            }
            else
            {

                browser = sessionInfo["browser"];
            }


        }

        public static void setSeleniumServer()
        {
            if (TestContext.Parameters["seleniumserver"] != null)
            {
                seleniumserver = TestContext.Parameters["seleniumserver"];

            }
            else
            {

                seleniumserver = sessionInfo["seleniumserver"];
            }

        }

        public static String getProperty(String property)
        {
            return sessionInfo[property];
        }


        public static String getChromeDriverPath()
        {
            return Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + sessionInfo["driverPath"];
        }

        public static String getLinuxChromeDriverPath()
        {
            return Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + sessionInfo["driverPath"];
        }

        public static String getMACChromeDriverPath()
        {
            return Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + sessionInfo["driverPath"];
        }

        public static String getIEDriverPath()
        {
            return Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + sessionInfo["driverPath"];
        }

        public static String getGeckoDriverPath()
        {
        
            return Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + sessionInfo["driverPath"];
        }

        public static String getEdgeDriverPath()
        {
            return Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + sessionInfo["driverPath"];
        }


    }
}
