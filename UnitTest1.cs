using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Data.SqlTypes;
using Investigation.PageObjects;

namespace Investigation
{
    public class UnitTest1
    {
        private readonly IWebDriver _driver;
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        private readonly WebDriverWait _wait;
        private readonly Actions _actions;
        private readonly PageElements _pageObject;

        public UnitTest1()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("headless");
            options.AddArguments("--start-maximized");
            options.AddArguments("--incognito");
            _driver = new ChromeDriver(options);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
            _actions = new Actions(_driver);
            _pageObject = new PageElements(_driver,_wait,_actions);
        }
        
        [Fact]
        public void Test1()
        {
            _pageObject.GoTo();
            _pageObject.SearchBar.SendKeys("selenium xunit guides" + Keys.Enter);
        }
    }
}