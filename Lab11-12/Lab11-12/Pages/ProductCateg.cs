using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab11_12.Pages
{
    public class ProductCateg
    {
        private WebDriverWait _wait;
        private readonly IWebDriver _driver;

        public ProductCateg(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        public ProductCateg GoToPage()
        {
            _driver.Navigate().GoToUrl("https://dnk.by/catalog/koreya/ukhod-za-litsom/demakiyazh_1");
            return this;
        }

        public ProductCateg SetFilterModels(List<string> models)
        {
            foreach (string model in models)
            {
                IWebElement filterCheckbox = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//label[starts-with(@for, 'i-brand-expanded-') and span[@class='input-text' and text()='{model}']]")));
                filterCheckbox.Click();
            }
            return this;
        }

        public ProductCateg SetFilterPrice(string fromPrice, string toPrice)
        {
            IWebElement filterPrice = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id=\"right_block_ajax\"]/div[1]/div[2]/div/div/form/div[2]/div[2]")));
            IWebElement priceRangeFrom = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("i-range-box-from-0")));
            IWebElement priceRangeTo = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("i-range-box-to-0")));


            priceRangeFrom.SendKeys(fromPrice);
            priceRangeTo.SendKeys(toPrice);
            priceRangeTo.SendKeys(Keys.Enter);

            return this;
        }
    }
}
