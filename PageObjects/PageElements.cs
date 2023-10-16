using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation.PageObjects
{
    internal class PageElements
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;

        public PageElements(IWebDriver driver, WebDriverWait wait, Actions actions) 
        {
            _driver = driver;
            _wait = wait;
            _actions = actions;
        }

        private IWebElement WaitAndFindElement(By locator) 
        { 
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }
        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://uatbol.rwbaird.com/Login");
        }

        public IWebElement LoginButton => WaitAndFindElement(By.XPath("//input[@id='loginButton']"));
    }
}
