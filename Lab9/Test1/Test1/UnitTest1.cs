using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Firefox;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System;

namespace Lab9
{
    public class Tests
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://dnk.by/";
            verificationErrors = new StringBuilder();

        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                Thread.Sleep(5000);
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }



        [Test]
        public void TestAddItemToBasket()
        {
            driver.Navigate().GoToUrl(baseURL);

            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div[2]/div/div/div/div/nav/div/table/tbody/tr/td[1]/div/a")).Click();


            driver.FindElement(By.XPath("//*[@id=\"bx_1847241719_554\"]")).Click();


            driver.FindElement(By.XPath("//*[@id=\"bx_1847241719_561\"]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div/div/div/div/div[1]/div[1]/div/div[1]")).Click();


            driver.FindElement(By.XPath("//*[@id=\"bx_3966226736_26416\"]/div")).Click();


            driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div/div/div/div/div/div/div/div[2]/div/div[7]/div/div[2]")).Click();



            // IWebElement searchInputLogin = driver.FindElement(By.XPath("//*[@id=\"one_click_buy_id_NAME\"]"));
            // searchInputLogin.Click();
            // searchInputLogin.SendKeys("Evgen");
            // Thread.Sleep(1000);

            //IWebElement searchInputPassword = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div[2]/div[1]/div[2]/input"));
            //searchInputPassword.Click();
            //searchInputPassword.SendKeys("что-то вводим");
            //Thread.Sleep(1000);

            //driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/button")).Click();

        }
    }
}