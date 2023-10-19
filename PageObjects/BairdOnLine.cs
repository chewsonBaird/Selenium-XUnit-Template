using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumPOC.PageObjects
{
    public class BairdOnLine
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;

        public BairdOnLine(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            _driver = driver;
            _wait = wait;
            _actions = actions;
        }

        // Private Helpers
        private IWebElement WaitAndFindElement(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        // Elements
        public IWebElement Username => WaitAndFindElement(By.XPath("//input[@id='Username']"));
        public IWebElement Password => WaitAndFindElement(By.XPath("//input[@id='Password']"));
        public IWebElement LoginButton => WaitAndFindElement(By.XPath("//input[@id='loginButton']"));

        // Actions

        // Assertions

        // Methods
        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://uatbol.rwbaird.com/Login");
            _wait.Until(ExpectedConditions.ElementToBeClickable(Username));
        }
        public void PROD__GoTo__PROD()
        {
            _driver.Navigate().GoToUrl("https://bol.rwbaird.com/Login");
            _wait.Until(ExpectedConditions.ElementToBeClickable(Username));
        }
        public void Login(string username = "chewson", string password = "Testing123")
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            LoginButton.Click();
        }
    }
}
