using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Lab11_12.Pages
{
    public class HomePage
    {
        private WebDriverWait _wait;
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "dropdownGlobalSearch")]
        private IWebElement buttonOpenSearch;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }

        public HomePage GoToPage()
        {
            _driver.Navigate().GoToUrl("https://dnk.by/");
            return this;
        }

        public HomePage SearchTextForProducts(string text)
        {
            buttonOpenSearch.Click();

            IWebElement searchInput = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"title-search-input_fixed\"]")));
            searchInput.SendKeys(text);
            searchInput.Submit();
            return this;
        }

        public HomePage SearchPromotion(string text)
        {
            buttonOpenSearch.Click();

            IWebElement cookieCloseButton = _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div[2]/div/div/div/div/nav/div/table/tbody/tr/td[5]/div/a"));
            cookieCloseButton.Click();
            return this;
        }

       
    }
}
