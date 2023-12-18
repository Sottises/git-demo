using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Lab11_12.Pages
{
    public class AirPage
    {
        private WebDriverWait _wait;
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "dropdownGlobalSearch")]
        private IWebElement buttonOpenSearch;

        public AirPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }

        public AirPage GoToPage()
        {
            _driver.Navigate().GoToUrl("https://traveling.by/");
            return this;
        }


        public AirPage SearchTextForProducts(string text)
        {
            buttonOpenSearch.Click();

            IWebElement searchInput = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/fellows']")));
            searchInput.SendKeys(text);
            searchInput.Submit();
            return this;
        }

    }
}