using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json.Linq;


namespace ServiceApiTest
{
    [TestFixture]
    public class BuyTests
    {
        private IWebDriver _webDriver;
        string BaseUrl = "http://5d9cc58566d00400145c9ed4.mockapi.io/shopping_cart";
        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
        }
        [Test]
        public void Test1()
        {
            ApiResponse apiResponse = new ApiResponse();
            string expectedResult = apiResponse.GetResponse("");
            Thread.Sleep(5000);
            Console.WriteLine("-------------------- Web Page Displayed ------------------");
            _webDriver.Navigate().GoToUrl(BaseUrl);
            IWebElement responseElement = _webDriver.FindElement(By.TagName("pre"));

            string displayedResponse = responseElement.Text;
            Console.WriteLine(displayedResponse);
            Assert.IsTrue(expectedResult.Equals(displayedResponse));
        }

        [TearDown]
        public void Teardown()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}