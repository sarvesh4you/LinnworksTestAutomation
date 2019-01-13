using Linnworks_Test_Automation.test.elements.com.linnworks.automation.utils;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;
using System;
using System.Linq;
using System.Net;


namespace LinnworksTests
{
    public class ApiActions : GetPage
    {
        protected RestClient client;
        RestRequest request;
        IRestResponse response;
        CookieContainer _cookieJar = new CookieContainer();
        public string tempCategoryId = null;
        public ApiActions(RestClient client)
        {
            this.client = client;
        }

      
        public int loginIntoApi(String requestUrl, String token)
        {
 
            client = new RestClient(requestUrl);
            client.CookieContainer = _cookieJar;
            request = new RestRequest(Method.POST);
            request.AddParameter("application/json", "{\r\n  \"token\": \""+token+"\"\r\n}", ParameterType.RequestBody);
            response = client.Execute(request);
            var content = response.Content;
            var sessionCookie = response.Cookies.SingleOrDefault(x => x.Name == "ASP.NET_SessionId");
            if (sessionCookie != null)
            {
                _cookieJar.Add(new System.Net.Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
            }
           
            logMessage("ASSERTION PASSED : User Successfully Logged into the API.");
            return (int)response.StatusCode;

        }


        public void veryResponseStatusCodeIs200(int statusCode)
        {
            Assert.IsTrue(statusCode==200, "ASSERTION FAILED : Status code is not 200.");
            logMessage("ASSERTION PASSED : Status code is 200.");
        }


        public int fetchAllTheCategories(string requestUrl)
        {
            client = new RestClient(requestUrl);
            client.CookieContainer = _cookieJar;
            request = new RestRequest(Method.GET);
            response = client.Execute(request);
            // System.Windows.MessageBox.Show(response.Content);
            //JObject json = JObject.Parse(response.Content);
            Assert.IsTrue((response.Content).Contains(YamlReader.getData("test_category.name2")), "ASSERTION FAILED : Category name does not contain in response.");
            Assert.IsTrue((response.Content).Contains(YamlReader.getData("test_category.name3")), "ASSERTION FAILED : Category name does not contain in response.");
            Assert.IsTrue((response.Content).Contains(YamlReader.getData("test_category.name")), "ASSERTION FAILED : Category name does not contain in response.");
            logMessage("ASSERTION PASSED : User is able to fetch all the categories through API.");
            return (int)response.StatusCode;
        }


        public int fetchExistingCategoryByItsId(string requestUrl, string categoryId, string categoryName)
        {
            client = new RestClient(requestUrl+"/"+categoryId);
            client.CookieContainer = _cookieJar;
            request = new RestRequest(Method.GET);
            response = client.Execute(request);
            JObject json = JObject.Parse(response.Content);
            Assert.IsTrue(((String)json["categoryName"]).Equals(categoryName), "ASSERTION FAILED : Category name does not contain in response.");
            logMessage("ASSERTION PASSED : Category name contains in response.");
            return (int)response.StatusCode;
        }


        public int addNewCategory(string requestUrl, string newCategoryId, string newCategoryName)
        {
            client = new RestClient(requestUrl);
            client.CookieContainer = _cookieJar;
            request = new RestRequest(Method.POST);
            request.AddParameter("application/json", "{\r\n  \"categoryId\": \""+ newCategoryId + "\",\r\n  \"categoryName\": \""+ newCategoryName + "\"\r\n}", ParameterType.RequestBody);
            response = client.Execute(request);
            JObject json = JObject.Parse(response.Content);
            Assert.IsTrue(((String)json["categoryName"]).Equals(newCategoryName), "ASSERTION FAILED : Category is not created.");
            logMessage("ASSERTION PASSED : Category successfully added.");
            tempCategoryId = json["categoryId"].ToString();
            return (int)response.StatusCode;
        }


        public int deleteACategory(string requestUrl)
        {
            client = new RestClient(requestUrl+"/"+tempCategoryId);
            client.CookieContainer = _cookieJar;
            request = new RestRequest(Method.DELETE);
            request.AddHeader("postman-token", "299e503c-f44d-abc4-5d03-5cb1eca1d640");
            request.AddHeader("cache-control", "no-cache");
            response = client.Execute(request);
            logMessage("ASSERTION PASSED : Category successfully deleted.");
            return (int)response.StatusCode;
        }
    }
   
}
