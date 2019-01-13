using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using static Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils.ConfigFileReader;


namespace Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils
{
    public class YamlReader
    {
        static String yamlPath = Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName) + "/test/resources/testdata/" + tier + "_Testdata.yml";

        public static Dictionary<Object, Object> readYaml()
        {
            Deserializer deserializer = new Deserializer();
            Dictionary<Object, Object> yaml = deserializer.Deserialize<Dictionary<Object, Object>>(File.OpenText(yamlPath));
            return yaml;
        }

        public static String getData(String token)
        {
            return (String)getValue(token);
        }

        public static Object getValue(String token)
        {
            Dictionary<Object, Object> yaml = readYaml();
            String[] st = token.Split('.');
            return parseMap(yaml, token)[st[st.Length - 1]].ToString();
        }

        public static Dictionary<Object, Object> parseMap(Dictionary<Object, Object> yaml, String token)
        {
            if (token.Contains("."))
            {
                String[] st = token.Split('.');
                yaml = parseMap((Dictionary<Object, Object>)yaml[st[0]], token.Replace(st[0] + ".", ""));
            }
            return yaml;
        }
    }
}

