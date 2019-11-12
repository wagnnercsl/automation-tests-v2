using System;
using System.Collections;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Desafio_Tecnico_Automacao
{
    [TestClass]
    public class TesteCompra
    {
        [TestMethod]
        public void CompraAutomatizada()
        {
            IWebDriver driver = new ChromeDriver();
            using (driver)
            {
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php?");

                driver.FindElement(By.ClassName("ajax_add_to_cart_button")).Click();
                //wait.Until()
                IWebElement modalCart = driver.FindElement(By.Id("layer_cart"));
                IWebElement elem = modalCart.FindElement(By.ClassName("button-medium"));
                Thread.Sleep(1000);
                elem.Click();
                
                IWebElement cart_table = driver.FindElement(By.Id("cart_summary"));
                IWebElement cart_table_body = cart_table.FindElement(By.TagName("tbody"));
                IWebElement tableRow = cart_table_body.FindElement(By.TagName("tr"));
                if (tableRow.Displayed)
                {
                    Thread.Sleep(1000);
                    IWebElement div = driver.FindElement(By.Id("columns"));
                    div.FindElement(By.ClassName("button-medium")).Click();

                    Random random = new Random();
                    String comprador = "joao.comprador" + random.Next().ToString() + "@exemplo.com";
;                    driver.FindElement(By.Id("email_create")).SendKeys(comprador);
                    driver.FindElement(By.Id("SubmitCreate")).Click();
                    Thread.Sleep(3000);

                    driver.FindElement(By.Id("id_gender1")).Click();

                    driver.FindElement(By.Id("customer_firstname")).SendKeys("João");

                    driver.FindElement(By.Id("customer_lastname")).SendKeys("Comprador");

                    driver.FindElement(By.Id("email")).Clear();
                    driver.FindElement(By.Id("email")).SendKeys(comprador);

                    driver.FindElement(By.Id("passwd")).SendKeys("123456");

                    IWebElement selectDay = driver.FindElement(By.Id("days"));
                    var daysList = new SelectElement(selectDay);
                    daysList.SelectByValue("10");

                    IWebElement selectMonth = driver.FindElement(By.Id("months"));
                    var monthsList = new SelectElement(selectMonth);
                    monthsList.SelectByValue("10");

                    IWebElement selectYear = driver.FindElement(By.Id("years"));
                    var yearsList = new SelectElement(selectYear);
                    yearsList.SelectByValue("2010");

                    driver.FindElement(By.Id("company")).SendKeys("DB Server");

                    driver.FindElement(By.Id("address1")).SendKeys("Av. Ipiranga, 6681");

                    driver.FindElement(By.Id("city")).SendKeys("Porto Alegre");

                    driver.FindElement(By.Id("address1")).Clear();
                    driver.FindElement(By.Id("address1")).SendKeys("Av. Ipiranga, 6681");

                    IWebElement selectState = driver.FindElement(By.Id("id_state"));
                    var statesList = new SelectElement(selectState);
                    statesList.SelectByValue("1");

                    driver.FindElement(By.Id("postcode")).SendKeys("35201");

                    IWebElement selectCountry = driver.FindElement(By.Id("id_country"));
                    var countriesList = new SelectElement(selectCountry);
                    countriesList.SelectByValue("21");

                    driver.FindElement(By.Id("phone_mobile")).SendKeys("51985494014");

                    driver.FindElement(By.Id("alias")).Clear();
                    driver.FindElement(By.Id("alias")).SendKeys("Tecnopuc");

                    IWebElement formAccount = driver.FindElement(By.Id("account-creation_form"));
                    formAccount.FindElement(By.ClassName("button-medium")).Click();

                    IWebElement confirmBuy = driver.FindElement(By.Id("columns"));
                    confirmBuy.FindElement(By.ClassName("button-medium")).Click();

                    
                    IWebElement formAcceptTermsChk = driver.FindElement(By.Id("uniform-cgv"));
                    formAcceptTermsChk.FindElement(By.Name("cgv")).Click();

                    IWebElement formAcceptTermsCheckout = driver.FindElement(By.Id("form"));
                    formAcceptTermsCheckout.FindElement(By.Name("processCarrier")).Click();
                    Thread.Sleep(3000);

                    IWebElement divConfirmPayment = driver.FindElement(By.Id("HOOK_PAYMENT"));
                    divConfirmPayment.FindElement(By.ClassName("bankwire")).Click();

                    IWebElement confirmPayment = driver.FindElement(By.Id("cart_navigation"));
                    confirmPayment.FindElement(By.ClassName("button-medium")).Click();
                    Thread.Sleep(2000);
                    IWebElement txtConfirmation = driver.FindElement(By.ClassName("cheque-indent"));

                    if(txtConfirmation.Text == "Your order on My Store is complete.")
                    {
                        Console.WriteLine("Sucess");
                    }

                }
                else
                {
                    driver.Quit();
                }
            }
            driver.Quit();
        }
    }
}
