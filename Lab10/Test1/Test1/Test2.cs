using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;

namespace Test2
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }

    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClickThirdMenuItem()
        {
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div[2]/div/div/div/div/nav/div/table/tbody/tr/td[3]/div/a")).Click();
        }
    }

    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public void ClickProduct()
        {
            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//*[@id=\"bx_3966226736_26806\"]/div")).Click();
        }

        public void AddToBasket()
        {
            Thread.Sleep(7000); // Подождать 7 секунд
            IWebElement buttonElement = driver.FindElement(By.XPath("//*[@id=\"bx_117848907_26806_basket_actions\"]"));
            buttonElement.Click();
            Thread.Sleep(7000);
        }
    }

    public class BasketPage : BasePage
    {
        public BasketPage(IWebDriver driver) : base(driver) { }

        public void ClickBasketItem()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div/div/div/div/div/div/div/div[2]/div/div[6]/div/div[1]")).Click();
        }
    }

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
            MainPage mainPage = new MainPage(driver);
            mainPage.GoToUrl(baseURL);
            mainPage.ClickThirdMenuItem();

            ProductPage productPage = new ProductPage(driver);
            productPage.ClickProduct();
            productPage.AddToBasket();

            BasketPage basketPage = new BasketPage(driver);
            basketPage.ClickBasketItem();
        }
    }
}
