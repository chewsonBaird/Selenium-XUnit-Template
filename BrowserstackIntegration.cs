using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Data.SqlTypes;
using Investigation.PageObjects;
using SeleniumPOC.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestObservability.Model.CBT;
using OpenQA.Selenium.Remote;
using TestObservability.Helper.CBT;
using Microsoft.CodeAnalysis;

namespace Investigation
{
    public class BrowserstackIntegration
    {
        private readonly IWebDriver _driver;
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 25;
        private readonly WebDriverWait _wait;
        private readonly Actions _actions;
        private readonly PageElements _pageObject;
        private readonly DigitalOnboarding _digital;
        private readonly BairdOnLine _bairdOnLine;
        private readonly TransitionTracker _transitionTracker;
        private readonly General _general;
        private readonly TestAssertionLibrary _assertions;

        
        public BrowserstackIntegration()
        {
            //ChromeOptions options = new ChromeOptions();
            ////options.AddArguments("headless");
            //options.AddArguments("--start-maximized");
            //options.AddAdditionalOption("acceptInsecureCerts", true);
            ////options.AddArguments("--incognito");
            //_driver = new ChromeDriver(options);

            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "latest"; // Use latest-beta, latest, latest-1 and so on
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("os", "Windows");
            browserstackOptions.Add("osVersion", "10");
            browserstackOptions.Add("sessionName", "BStack Build Name: " + "browserstack-pipe");
            browserstackOptions.Add("userName", "jimwarchol_Z1kK3g");
            browserstackOptions.Add("accessKey", "qBDq6Ngiuzemn8s5asWY");
            browserstackOptions.Add("seleniumVersion", "4.13.0");
            browserstackOptions.Add("acceptInsecureCerts", true);
            browserstackOptions.Add("local", false);
            browserstackOptions.Add("localIdentifier", "");
            capabilities.AddUserProfilePreference("autofill.profile_enabled", false);
            capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

            _driver = new RemoteWebDriver(new Uri("https://hub.browserstack.com/wd/hub/"), capabilities);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
            _actions = new Actions(_driver);
            _pageObject = new PageElements(_driver,_wait,_actions);
            _digital = new DigitalOnboarding(_driver, _wait, _actions);
            _bairdOnLine = new BairdOnLine(_driver, _wait, _actions);
            _transitionTracker = new TransitionTracker(_driver, _wait, _actions);
            _general = new General(_driver, _wait, _actions);
            _assertions = new TestAssertionLibrary(_driver, _wait, _actions);
        }
        //// Test Case Id: 127238
        //[Fact]
        //public void CLIENT_IRAAccount_CoverdellIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData("H.208", false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();
        //        _general.GetStartedAndClearCookies();

        //        //Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        //Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddCoverdellIRAAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        // Test Case Id: 96368
        //Single account owner, individual account
        [Fact]
        public async void CLIENT_IndividualAccount()
        {
            try
            {
                _driver.Manage().Window.Maximize();
                //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);
                var token = await _transitionTracker.APIHouseholdClear();

                //_bairdOnLine.GoTo();
                //_bairdOnLine.Login();

                //Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
                //Assert.True(_digital.LetsGetStartedButton.Enabled);

                _general.GetStartedAndClearCookies();

                //Household Details Flow
                _general.EnterHouseholdDetails();
                _digital.ClickLetsMoveOn();

                //Account Owners Flow
                _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
                _general.EditAccountOwner(employmentScenario: 1); 
                _digital.AccountOwnerToAccounts();

                //Accounts Flow
                _general.AddIndividualAccountToHousehold();
                _digital.AccountsToAccountServices();

                //Account Services Flow
                _digital.ClickGetStartedButton();
                _general.BairdAccountDebitCard(checks: true);
                _general.ExternalBankAccount(externalAccount: true);
                _digital.ClickNextButton();
                _digital.ClickLetsMoveOn();

                //Trusted Contacts
                _general.SelectTrustedContactAndAddDetails();
                _digital.ClickLetsMoveOn();

                //Securities Industry & Affiliations
                _general.SelectSecuritiesIndustryAndAffiliationsDetails();

                //Additional Information
                _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

                //Summary
                //_general.SubmitWithoutStatements();

                Assert.True(_digital.SubmitCompleted.Displayed);
            }
            //catch
            //{
            //    Assert.Fail();
            //}
            finally
            {
                _driver.Quit();
            }
        }
        //// Test Case Id: 125275
        ////Single account owner, IRA account
        //[Fact]
        //public void CLIENT_IRAAccount_TraditionalIRA_WithBeneficiaries_Primary()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner(employmentScenario: 2);
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(
        //            iRAAccountType: "1",
        //            beneficiaries: true,
        //            beneficiaryScenario: 1,
        //            primaryBeneficiaryType: "person",
        //            contingentBeneficiaryType: "trust"
        //            );
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 125279
        ////Single account owner, IRA account
        //[Fact]
        //public void CLIENT_SingleOwner_OtherAccount_529CollegeSavings()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner(employmentScenario: 5);
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOther529CollegeAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 129508
        ////Single account owner, IRA account, Successful External Bank Validation
        //[Fact]
        //public void CLIENT_IRAAccount_TraditionalIRA_SuccessfulExternalAccount()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner(firstName: "Wilson", lastName: "Paul");
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.SuccessfulExternalBankValidation(); // Test Case Id: 129508
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 
        ////Single account owner, IRA account, Primary and Contingent Beneficiaries
        //[Fact]
        //public void CLIENT_IRAAccount_TraditionalIRA_WithBeneficiaries_PrimaryContingent()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "1",
        //            beneficiaries: true,
        //            beneficiaryScenario: 3,
        //            primaryBeneficiaryType: "person",
        //            contingentBeneficiaryType: "entity");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 
        ////Single account owner, IRA account, Primary and Contingent Beneficiaries
        //[Fact]
        //public void CLIENT_IRAAccount_TraditionalIRA_WithBeneficiaries_TwoPrimaryWithAllocationsAndStirpes()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "1",
        //            beneficiaries: true,
        //            beneficiaryScenario: 4,
        //            primaryBeneficiaryType: "trust",
        //            contingentBeneficiaryType: "person");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 
        ////Single account owner, IRA account, Primary and Contingent Beneficiaries
        //[Fact]
        //public void CLIENT_IRAAccount_TraditionalIRA_WithBeneficiaries_TwoPrimaryAndContingentWithAllocationsAndStirpes()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "1",
        //            beneficiaries: true,
        //            beneficiaryScenario: 5,
        //            primaryBeneficiaryType: "person",
        //            contingentBeneficiaryType: "person");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127566
        //[Fact]
        //public void CLIENT_JointAccount_JTTENWROS()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddJointAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard(debitCard: true);
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _general.TransferBetweenAccounts();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127574
        //[Fact]
        //public void CLIENT_JointAccount_JTTENByEntirety()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddJointAccountToHousehold(jointAccountType: "2");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _general.TransferBetweenAccounts();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127575
        //[Fact]
        //public void CLIENT_JointAccount_TIC()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddJointTICAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _general.TransferBetweenAccounts();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127576
        //[Fact]
        //public void CLIENT_JointAccount_CommunityProperty()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddJointAccountToHousehold(jointAccountType: "4");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard(debitCard: true, debitCardChecks: true);
        //        _general.ExternalBankAccount(externalAccount: true); // Test Case Id: 129511
        //        _digital.ClickNextButton();
        //        _general.TransferBetweenAccounts();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127559
        //[Fact]
        //public void CLIENT_MultipleOwner_OtherAccount_529CollegeSavings()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner(employmentScenario: 6);
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOther529CollegeAccountToHousehold(multipleOwners: true);
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _general.TransferBetweenAccounts();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127560
        //[Fact]
        //public void CLIENT_MultipleOwner_OtherAccount_Corporate()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOtherCorporateAccountToHousehold(multipleOwners: true);
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard(debitCard: true, debitCardChecks: true);
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _general.TransferBetweenAccounts();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127561
        //[Fact]
        //public void CLIENT_MultipleOwner_OtherAccount_Other()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOtherOtherAccountToHousehold(multipleOwners: true);
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _general.TransferBetweenAccounts();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127562
        //[Fact]
        //public void CLIENT_MultipleOwner_OtherAccount_Trust()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOtherTrustAccountToHousehold(multipleOwners: true);
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _general.TransferBetweenAccounts();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127493
        //[Fact]
        //public void CLIENT_SingleOwner_OtherAccount_Corporate()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner(employmentScenario: 4);
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOtherCorporateAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127495
        //[Fact]
        //public void CLIENT_SingleOwner_OtherAccount_Other()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOtherOtherAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127549
        //[Fact]
        //public void CLIENT_SingleOwner_OtherAccount_Trust()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOtherTrustAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127554
        //[Fact]
        //public void CLIENT_SingleOwner_OtherAccount_UGMAUTMA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddOtherUGMAUTMAAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127209
        //[Fact]
        //public void CLIENT_IRAAccount_RolloverIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "2");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127215
        //[Fact]
        //public void CLIENT_IRAAccount_ROTHIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "3");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127218
        //[Fact]
        //public void CLIENT_IRAAccount_BeneficiaryIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddBeneficiaryIRAAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127479
        //[Fact]
        //public void CLIENT_IRAAccount_MinorIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddMinorIRAAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127482
        //[Fact]
        //public void CLIENT_IRAAccount_SARSEPIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "7");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127483
        //[Fact]
        //public void CLIENT_IRAAccount_SEPIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "8", beneficiaries: true, beneficiaryScenario: 5);
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127484
        //[Fact]
        //public void CLIENT_IRAAccount_SIMPLEIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "9", beneficiaries: true, beneficiaryScenario: 5);
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 127486
        //[Fact]
        //public void CLIENT_IRAAccount_SpousalIRA()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIRAAccountToHousehold(iRAAccountType: "10");
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.ExternalBankAccount();
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 129647
        //[Fact]
        //public void CLIENT_IRAAccount_TaxWithholdings()
        //{
        //    string firm = "charles-schwab";
        //    string accountNumber = "43218765";
        //    string accountOwner = "1";
        //    string accountType = "2";
        //    string iRAAccountType = "1";
        //    string investmentLength = "short";
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner(dateOfBirth: "08301963");
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddAccountToHousehold(
        //        firm: firm,
        //        accountNumber: accountNumber,
        //        accountOwner: accountOwner,
        //        singleOwnerAccountType: accountType);
        //        _general.SelectSubAccount(subAccountType: iRAAccountType);
        //        _digital.InvestmentLengthSelector(investmentLength);

        //        Assert.True(_digital.IRAWithdrawalNoRadial.Displayed);
        //        Assert.True(_digital.IRAWithdrawalYesRadial.Displayed);

        //        _digital.IRAWithdrawalYesRadial.Click();
        //        _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.IRAWithdrawalYesRadial));

        //        Assert.True(_digital.PercentageTaxWithholding.Displayed);
        //        Assert.True(_digital.DollarTaxWithholding.Displayed);
        //        Assert.True(_digital.BeneficiariesOptOutCheckbox.Displayed);

        //        _digital.PercentageTaxWithholding.Click();
        //        _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.PercentageTaxWithholding));
        //        _digital.FederalTaxWithholding.SendKeys("12.35");
        //        _digital.StateTaxWithholding.SendKeys("4.20");

        //        Assert.True(_digital.NextButton.Enabled);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 130497
        //[Fact]
        //public void CLIENT_AccountOwnerCanBeDeselected()
        //{
        //    string firm = "charles-schwab";
        //    string accountNumber = "43218765";
        //    string accountOwner = "1";
        //    string secondAccountOwner = "2";
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        //Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        //Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow - Add Account owner from accounts screen and deselect them as an owner
        //        _digital.AddButton.Click();
        //        _general.AddAccountOwner();
        //        _digital.AccountTransferFromSelector(firm);
        //        _digital.AccountNumberField.Clear();
        //        _digital.AccountNumberField.SendKeys(accountNumber);
        //        _digital.AccountOwnerSelector(accountOwner);
        //        _digital.AccountOwnerSelector(secondAccountOwner);
        //        _digital.ClickNextButton();
        //        _digital.BackButton.Click();
        //        Assert.False(_digital.CheckBox2.Selected);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 131804
        //[Fact]
        //public void CLIENT_JointAccount_NoOwnersSelected()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _general.AddAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        _general.AddAccountToHousehold(multipleOwners: true);
        //        _general.SelectSubAccount();
        //        _digital.ClickNextButton();
        //        _digital.BackButton.Click();

        //        Assert.True(_digital.AccountOwnerSelectionValidation.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //// Test Case Id: 132125
        //[Fact]
        //public void CLIENT_AccountsNumberValidationDisabledWhenNotTransferingCheckboxSelected()
        //{
        //    string accountNumber = "4";
        //    string accountOwner = "1";
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner();
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow 
        //        _digital.AddButton.Click();
        //        _digital.AccountNumberField.SendKeys(accountNumber);
        //        // .Clear() did not prompt the validation so I used backspace to prompt it.
        //        _digital.AccountNumberField.SendKeys(Keys.Backspace);

        //        Assert.True(_digital.AccountNumberValidation.Displayed);

        //        _digital.AccountOwnerSelector(accountOwner);
        //        _digital.AccountNumberField.SendKeys(accountNumber);
        //        _digital.NotTransferringAccountsCheckbox.Click();
        //        _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NotTransferringAccountsCheckbox));

        //        Assert.True(_digital.EmptyAccountNumberField.Displayed);
        //        Assert.True(_digital.NextButton.Enabled);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
        //////Test Case Id: 132207
        ////[Fact]
        ////public void Client_FirstVisitAdminPrefillProgressBar()
        ////{
        ////    try
        ////    {
        ////        //Impersonation and prefill data
        ////        _transitionTracker.UpdateHouseholdDataAndImpersonate(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);
        ////        _general.GetStartedAndClearCookies();

        ////        //Household Details Flow
        ////        _general.EnterHouseholdDetails();
        ////        _digital.ClickLetsMoveOn();

        ////        //Account Owners Flow
        ////        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        ////        _general.EditAccountOwner();
        ////        _digital.AccountOwnersGoToAccountsButton.Click();

        ////        //Accounts Flow
        ////        _general.AddIndividualAccountToHousehold();
        ////        _digital.ExitButton.Click();

        ////        //Client Login
        ////        _bairdOnLine.GoTo();
        ////        _bairdOnLine.Login();

        ////        _assertions.HouseholdProgressBarNotStarted();
        ////    }
        ////    finally
        ////    {
        ////        _driver.Quit();
        ////    }
        ////}

        ////TODO: Update fileUpload to support running on browserstack
        //// Test Case Id: 132999
        ////Single account owner, individual account
        //[Fact]
        //public void CLIENT_FileUploadRequiredFileType()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails(fileUpload: true, successfulUpload: false, fileName: "TestFile.txt");
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner(employmentScenario: 1);
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIndividualAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard(
        //            checks: true,
        //            fileUpload: true,
        //            fileName: "TestFile.iso",
        //            successfulUpload: false);
        //        _general.ExternalBankAccount(externalAccount: true);
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(
        //            fileUpload: true,
        //            successfulUpload: false,
        //            fileName: "TestFile.mp3",
        //            additionalInformation: true);

        //        //Summary
        //        _general.SubmitWithoutStatements();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}

        ////TODO: Update fileUpload to support running on browserstack
        //// Test Case Id: 133256
        ////Single account owner, individual account
        //[Fact]
        //public void CLIENT_FileUploadSuccess()
        //{
        //    try
        //    {
        //        _driver.Manage().Window.Maximize();
        //        //_transitionTracker.UpdateHouseholdData(TEST_HOUSEHOLD_TRANSITION_TRACKER_ID, false);

        //        _bairdOnLine.GoTo();
        //        _bairdOnLine.Login();

        //        Assert.True(_digital.WelcomeScreenWelcomeHeader.Displayed);
        //        Assert.True(_digital.LetsGetStartedButton.Enabled);

        //        _general.GetStartedAndClearCookies();

        //        //Household Details Flow
        //        _general.EnterHouseholdDetails(fileUpload: true);
        //        _digital.ClickLetsMoveOn();

        //        //Account Owners Flow
        //        _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersEditPrimaryAccountOwnerButton));
        //        _general.EditAccountOwner(employmentScenario: 1);
        //        _digital.AccountOwnersGoToAccountsButton.Click();

        //        //Accounts Flow
        //        _general.AddIndividualAccountToHousehold();
        //        _digital.AccountsToAccountServices();

        //        //Account Services Flow
        //        _digital.ClickGetStartedButton();
        //        _general.BairdAccountDebitCard(
        //            checks: true,
        //            fileUpload: true);
        //        _general.ExternalBankAccount(externalAccount: true);
        //        _digital.ClickNextButton();
        //        _digital.ClickLetsMoveOn();

        //        //Trusted Contacts
        //        _general.SelectTrustedContactAndAddDetails();
        //        _digital.ClickLetsMoveOn();

        //        //Securities Industry & Affiliations
        //        _general.SelectSecuritiesIndustryAndAffiliationsDetails();

        //        //Additional Information
        //        _general.AdditionalInformationSelectionWithAssertions(fileUpload: true);

        //        //Summary
        //        _general.Submit();

        //        Assert.True(_digital.SubmitCompleted.Displayed);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
    }
}