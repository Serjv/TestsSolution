using OpenQA.Selenium;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationTests
{
    public class PageDriver
    {
        private readonly WebDriver _webDriver;
        private readonly ConfigurationDriver _configurationDriver;

        public PageDriver(WebDriver webDriver, ConfigurationDriver configurationDriver)
        {
            _webDriver = webDriver;
            _configurationDriver = configurationDriver;
        }

        public void GoToTranslationPage()
        {
            string baseUrl = _configurationDriver.SeleniumBaseUrl;
            _webDriver.Current.Manage().Window.Maximize();
            _webDriver.Current.Navigate().GoToUrl($"{baseUrl}/");
        }

        public void EnterText(string text)
        {
            _webDriver.Wait.Until(d => d.FindElement(By.Id("source"))).SendKeys(text);
            _webDriver.Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[4]/div[3]"))).Click();
        }

        public void EnterLanguage(string text)
        {
            _webDriver.Wait.Until(d => d.FindElement(By.Id("tl_list-search-box"))).SendKeys(text);
            _webDriver.Wait.Until(d => d.FindElement(By.Id("tl_list-search-box"))).SendKeys(Keys.Enter);
            _webDriver.Wait.Until(d => d.FindElement(By.XPath("//span/span")).Displayed);
        }

        public void ValidateResultShouldBe(string expectedResult)
        {
            var result = _webDriver.Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/div[3]/div[1]/div[2]/div/span[1]/span")).Text);

            result.Should().Be(expectedResult);
        }
    }
}
