using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;

namespace Lab9
{
    public class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClickFirstMenuItem()
        {
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div[2]/div/div/div/div/nav/div/table/tbody/tr/td[1]/div/a")).Click();
        }
    }

    public class SecondPage
    {
        private IWebDriver driver;

        public SecondPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElementWithID554()
        {
            driver.FindElement(By.XPath("//*[@id=\"bx_1847241719_554\"]")).Click();
        }
    }

    public class ThirdPage
    {
        private IWebDriver driver;

        public ThirdPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElementWithID561()
        {
            driver.FindElement(By.XPath("//*[@id=\"bx_1847241719_561\"]")).Click();
        }
    }

    public class FourthPage
    {
        private IWebDriver driver;

        public FourthPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAnotherElement()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div/div/div/div/div[1]/div[1]/div/div[1]")).Click();
        }
    }

    public class FivePage
    {
        private IWebDriver driver;

        public FivePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElementWithID26416()
        {
            driver.FindElement(By.XPath("//*[@id=\"bx_3966226736_26416\"]/div")).Click();
        }
    }

    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
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
            mainPage.NavigateTo("https://dnk.by/");
            mainPage.ClickFirstMenuItem();

            SecondPage secondPage = new SecondPage(driver);
            secondPage.ClickElementWithID554();

            ThirdPage thirdPage = new ThirdPage(driver);
            thirdPage.ClickElementWithID561();

            FourthPage fourthPage = new FourthPage(driver);
            fourthPage.ClickAnotherElement();

            FivePage fivePage = new FivePage(driver);
            fivePage.ClickElementWithID26416();

        }
    }
}
