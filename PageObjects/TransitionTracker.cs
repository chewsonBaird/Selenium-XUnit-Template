using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Net.Http.Headers;
using System.Net;
using Xunit;

namespace SeleniumPOC.PageObjects
{
    public class TransitionTracker
    {
        private const string UriString = "https://uatdigocore.rwbaird.com/";
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;
        private readonly BairdOnLine _bairdOnLine;

        private string transitionsTrackerUrl = "https://uattransitionstracker.rwbaird.com/";

        public TransitionTracker(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            _driver = driver;
            _wait = wait;
            _actions = actions;
            _bairdOnLine = new BairdOnLine(_driver, _wait, _actions);
        }

        // Private Helpers
        private IWebElement WaitAndFindElement(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        // Elements
        public IWebElement ChooseATransitionDropdown => WaitAndFindElement(By.XPath("//a[@id='navbarDropdownMenuLink']"));
        public IWebElement TransitionMA37 => WaitAndFindElement(By.XPath("//button[contains(text(),'MA37 - Testing DO - P - 5/01/2023')]"));
        public IWebElement TransitionMA38 => WaitAndFindElement(By.XPath("//button[contains(text(),'MA38 - Digital Onboarding FA - NP - 5/01/2023')]"));
        public IWebElement HHIDSortByDescendingButton => WaitAndFindElement(By.XPath("//i[@class='p-sortable-column-icon pi pi-fw pi-sort-alt']"));
        public IWebElement HHIDSortByAscendingButton => WaitAndFindElement(By.XPath("//i[@class='p-sortable-column-icon pi pi-fw pi-sort-amount-up-alt']"));
        public IWebElement FilterColumnsField => WaitAndFindElement(By.XPath("//input[@class='p-inputtext p-component']"));
        public IWebElement EditHouseholdButton => WaitAndFindElement(By.XPath("//button[@class='p-splitbutton-defaultbutton p-button p-component p-button-icon-only']"));
        public IWebElement HouseholdDigitalOnboardingTab => WaitAndFindElement(By.XPath("//a[@id='p-tabpanel-7-label']"));
        public IWebElement UpdateHouseholdDataButton => WaitAndFindElement(By.XPath("//button[@class='sitRight p-button p-component p-ripple']"));
        public IWebElement UpdateHouseholdDataConfirmationButton => WaitAndFindElement(By.XPath("//button[@class='ng-tns-c67-3 p-confirm-dialog-accept p-ripple p-button p-component ng-star-inserted']"));
        public IWebElement ImpersonateHouseholdButton => WaitAndFindElement(By.XPath("(//button[@class='p-button p-component p-ripple'])[2]"));
        public IWebElement UIBlocker => WaitAndFindElement(By.XPath("//div[@class='block-ui-wrapper block-ui-main active']"));


        // Actions

        // Assertions

        // Methods
        public void GoTo()
        {
            _driver.Navigate().GoToUrl(transitionsTrackerUrl);
            _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseATransitionDropdown));
            Thread.Sleep(3000);
        }
        public void UpdateHouseholdData(string filterCriteria, bool protocol)
        {
            GoTo();
            try
            {
                ChooseATransitionDropdown.Click();
            }
            catch
            {
                ChooseATransitionDropdown.Click();
            }
            if (protocol)
            {
                try
                {
                    TransitionMA37.Click();
                }
                catch
                {
                    TransitionMA37.Click();
                }
            }
            else
            {
                try
                {
                    TransitionMA38.Click();
                }
                catch
                {
                    TransitionMA38.Click();
                }
            }
            FilterColumnsField.SendKeys(filterCriteria + Keys.Enter);
            _wait.Until(ExpectedConditions.ElementToBeClickable(EditHouseholdButton));
            Thread.Sleep(5000);
            try
            {
                EditHouseholdButton.Click();
            }
            catch
            {
                Thread.Sleep(2000);
                EditHouseholdButton.Click();
            }
            HouseholdDigitalOnboardingTab.Click();
            UpdateHouseholdDataButton.Click();
            UpdateHouseholdDataConfirmationButton.Click();
            Thread.Sleep(2000);
        }
        public void ImpersonateClient(
            string filterCriteria, 
            bool protocol)
        {
            GoTo();
            try
            {
                ChooseATransitionDropdown.Click();
            }
            catch
            {
                ChooseATransitionDropdown.Click();
            }
            if (protocol)
            {
                try
                {
                    TransitionMA37.Click();
                }
                catch
                {
                    TransitionMA37.Click();
                }
            }
            else
            {
                try
                {
                    TransitionMA38.Click();
                }
                catch
                {
                    TransitionMA38.Click();
                }
            }
            FilterColumnsField.SendKeys(filterCriteria + Keys.Enter);
            _wait.Until(ExpectedConditions.ElementToBeClickable(EditHouseholdButton));
            Thread.Sleep(5000);
            try
            {
                EditHouseholdButton.Click();
            }
            catch
            {
                Thread.Sleep(2000);
                EditHouseholdButton.Click();
            }
            HouseholdDigitalOnboardingTab.Click();
            ImpersonateHouseholdButton.Click();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }
        public void UpdateHouseholdDataAndImpersonate(string filterCriteria, bool protocol)
        {
            GoTo();
            try
            {
                ChooseATransitionDropdown.Click();
            }
            catch
            {
                ChooseATransitionDropdown.Click();
            }
            if (protocol)
            {
                try
                {
                    TransitionMA37.Click();
                }
                catch
                {
                    TransitionMA37.Click();
                }
            }
            else
            {
                try
                {
                    TransitionMA38.Click();
                }
                catch
                {
                    TransitionMA38.Click();
                }
            }
            FilterColumnsField.SendKeys(filterCriteria + Keys.Enter);
            _wait.Until(ExpectedConditions.ElementToBeClickable(EditHouseholdButton));
            Thread.Sleep(5000);
            try
            {
                EditHouseholdButton.Click();
            }
            catch
            {
                Thread.Sleep(2000);
                EditHouseholdButton.Click();
            }
            HouseholdDigitalOnboardingTab.Click();
            UpdateHouseholdDataButton.Click();
            UpdateHouseholdDataConfirmationButton.Click();
            Thread.Sleep(3000);
            try
            {
                ImpersonateHouseholdButton.Click();
            }
            catch
            {
                ImpersonateHouseholdButton.Click();
            }
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        public async void APIHouseholdClear()
        {
            _bairdOnLine.GoTo();
            _bairdOnLine.Login();

            var BOLAccessToken = _driver.Manage().Cookies.GetCookieNamed("BOLAccessToken");
            var token = BOLAccessToken.Value;
            await ResetHousehold(token);
            Thread.Sleep(5000);
            _driver.Navigate().Refresh();
        }

        // ---- API Calls

        public static HttpClient client = new HttpClient();
        public static HttpContent content;

        public static async Task<HttpStatusCode> GetHouseholdStatusAsync()
        {
            HttpResponseMessage response = await client.GetAsync(
                $"/clienthousehold");
            return response.StatusCode;
        }

        public static async Task GetHouseholdStatus(string token)
        {
            client.BaseAddress = new Uri(UriString);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var statusCode = await GetHouseholdStatusAsync();
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }


        public static async Task<HttpStatusCode> ResetHouseholdAsync()
        {
            HttpResponseMessage response = await client.PostAsync(
                $"/clear-data", content);
            return response.StatusCode;
        }

        public static async Task ResetHousehold(string token)
        {
            client.BaseAddress = new Uri(UriString);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var statusCode = await ResetHouseholdAsync();
            Assert.True(statusCode == HttpStatusCode.OK);
        }
    }
}
