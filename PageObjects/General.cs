using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Xunit;
using System.Linq.Expressions;
using System.Reflection;
using System.Drawing;

namespace SeleniumPOC.PageObjects
{
    public class General
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;
        private readonly DigitalOnboarding _digital;
        private readonly BairdOnLine _bairdOnLine;
        private readonly TransitionTracker _transitionTracker;
        private readonly TestAssertionLibrary _assertions;

        public General(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            _driver = driver;
            _wait = wait;
            _actions = actions;
            _digital = new DigitalOnboarding(driver, wait, actions);
            _bairdOnLine = new BairdOnLine(driver, wait, actions);
            _transitionTracker = new TransitionTracker(driver, wait, actions);
            _assertions = new TestAssertionLibrary(driver, wait, actions);
        }

        public void AddAddress(
            string country = "us",
            string address1 = "123 Fake St",
            string address2 = "#234",
            string city = "Chicago",
            string state = "il",
            string postalCode = "60605",
            bool own = true)
        {
            _digital.ClearHouseholdAddressScreen();
            _digital.CountrySelectorByAbbreviation(country);
            _digital.HouseholdDetailsAddress1Field.SendKeys(address1);
            _digital.HouseholdDetailsAddress2Field.SendKeys(address2);
            _digital.HouseholdDetailsCityField.SendKeys(city);
            _digital.StateSelectorByAbbreviation(state);
            _digital.HouseholdDetailsPostalCodeField.SendKeys(postalCode);
            if (own)
            {
                _digital.HouseholdDetailsOwnField.Click();
            }
            else
            {
                _digital.HouseholdDetailsRentField.Click();
            }
        }
        public void SetInvestmentExperience()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.HouseholdDetailsInvestmentExperienceStocksSlider));
            try
            {
                _digital.HouseholdDetailsInvestmentExperienceStocksSlider.SendKeys(Keys.Right);
                _digital.HouseholdDetailsInvestmentExperienceBondsSlider.SendKeys(Keys.Right);
                _digital.HouseholdDetailsInvestmentExperienceMutualFundsSlider.SendKeys(Keys.Right);
                _digital.HouseholdDetailsInvestmentExperienceOptionsSlider.SendKeys(Keys.Right);
                _digital.HouseholdDetailsInvestmentExperienceAnnuitiesLifeInsuranceSlider.SendKeys(Keys.Right);
            }
            catch
            {
                _digital.HouseholdDetailsInvestmentExperienceStocksSlider.SendKeys(Keys.Left + Keys.Right);
                _digital.HouseholdDetailsInvestmentExperienceBondsSlider.SendKeys(Keys.Left + Keys.Right);
                _digital.HouseholdDetailsInvestmentExperienceMutualFundsSlider.SendKeys(Keys.Left + Keys.Right);
                _digital.HouseholdDetailsInvestmentExperienceOptionsSlider.SendKeys(Keys.Left + Keys.Right);
                _digital.HouseholdDetailsInvestmentExperienceAnnuitiesLifeInsuranceSlider.SendKeys(Keys.Left + Keys.Right);
            }
        }
        public void CheckForCookies()
        {
            try
            {
                if (_digital.AcceptCookies.Displayed)
                {
                    _digital.AcceptCookies.Click();
                }
            }
            catch { }
        }
        public void GetStartedAndClearCookies()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.LetsGetStartedButton));
            _digital.ClickGetStartedButton();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.WelcomeScreenImReadyToGetStartedButton));
            _digital.WelcomeScreenImReadyToGetStartedButton.Click();
            CheckForCookies();
        }
        public void EnterHouseholdDetails(
            string country = "us",
            string address1 = "123 Fake St",
            string address2 = "#234",
            string city = "Chicago",
            string state = "il",
            string postalCode = "60605",
            bool own = true,
            bool fileUpload = false,
            bool successfulUpload = true,
            string fileName = "TestFile.jpg",
            string communicationPreference = "Who's house? Duck's house!")
        {
            _assertions.Test_95971();

            _digital.HouseholdDetailsScreenGetStartedButton.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.HouseholdDetailsCountryField));

            _assertions.Test_95976();

            AddAddress(country, address1, address2, city, state, postalCode, own = true);
            _digital.ClickNextButton();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.YesButton));

            _assertions.Test_95979();

            _digital.NoButton.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.NextButton));

            _assertions.Test_95984();

            _digital.HouseholdDetailsCommunicationPreferenceField.Clear();
            _digital.HouseholdDetailsCommunicationPreferenceField.SendKeys(communicationPreference);
            _digital.ClickNextButton();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.HouseholdDetailsFinancialSummaryAnnualHouseholdIncomeField));

            _assertions.Test_95987();

            _digital.AnnualHouseholdIncomeSelector();
            _digital.HouseholdNetWorthSelector();
            _digital.OtherInvestableAssetsSelector();
            _digital.TaxBracketSelector();
            _digital.ClickNextButton();

            _assertions.Test_95988();

            SetInvestmentExperience();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.NextButton));
            _digital.ClickNextButton();

            _assertions.Test_95989();

            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.HouseholdDetailsAccountStatementsChooseFilesButton));
            
            //if (fileUpload)
            //{
            //    var file = DrawText(text: "This is an image", font: new Font("Tahoma", 8), textColor: Color.Orange, backColor: Color.Black);
            //    file.Save(fileName);
            //    var filePath = Path.GetFullPath(fileName);
            //    if (successfulUpload)
            //    {
            //        _digital.FileUpload.SendKeys(filePath);

            //        Assert.True(_digital.FileUploadTestFile.Displayed);
            //    }
            //    else
            //    {
            //        _digital.FileUpload.SendKeys(filePath);

            //        Assert.True(_digital.FileUploadError.Displayed);

            //        _digital.CloseButton.Click();
            //    }
            //}

            _digital.ClickNextButton();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.HouseholdDetailsScreenMoveOnButton));
        }
        public void AddAccountOwner(
            string firstName = "Bugs",
            string middleName = "Big Hops",
            string lastName = "Bunny",
            string preferredName = "Buster",
            string dateOfBirth = "09301973",
            bool citizen = true,
            string socialSecurityNumber = "867530899",
            string maritalStatus = "single",
            string dependents = "0",
            bool addPhone = false,
            string phoneSelect = "1",
            string phoneTypeSelect = "mobile",
            string phoneNumberSelect = "7894561001",
            string primaryEmail = "chewson@rwbaird.com",
            string secondaryEmail = "testing@testEmail.edu",
            int employmentScenario = 3)
        {
            _digital.AccountOwnersAddAccountOwnerButton.Click();
            _digital.ClearAccountOwnersNameScreen();
            _digital.AccountOwnersLegalFirstNameField.SendKeys(firstName);
            _digital.AccountOwnersLegalMiddleNameField.SendKeys(middleName);
            _digital.AccountOwnersLegalLastNameField.SendKeys(lastName);
            _digital.AccountOwnersPreferredFirstNameField.SendKeys(preferredName);
            _digital.ClickNextButton();
            _digital.AccountOwnersDateOfBirthField.SendKeys(dateOfBirth);
            if (citizen)
            {
                _digital.AccountOwnersAreYouACitizenYesRadial.Click();
            }
            else
            {
                _digital.AccountOwnersAreYouACitizenNoRadial.Click();
            }
            _digital.AccountOwnersSocialSecurityNumberField.SendKeys(socialSecurityNumber);
            _digital.AccountOwnerMaritalStatusSelector(maritalStatus);
            _digital.AccountOwnersNumberOfDependentsField.SendKeys(dependents);
            _digital.ClickNextButton();
            _digital.AccountOwnersOtherAddressRadial.Click();
            AddAddress();
            _digital.ClickNextButton();
            _digital.SetPhoneInfoByPhone();
            if (addPhone)
            {
                _digital.AccountOwnersAddPhoneButton.Click();
                _digital.SetPhoneInfoByPhone
                    (phone: phoneSelect,
                    phoneType: phoneTypeSelect,
                    phoneNumber: phoneNumberSelect);
            }
            _digital.AccountOwnersRequiredEmailAddressField.Clear();
            _digital.AccountOwnersRequiredEmailAddressField.SendKeys(primaryEmail);
            _digital.AccountOwnersOptionalEmailAddressField.Clear();
            _digital.AccountOwnersOptionalEmailAddressField.SendKeys(secondaryEmail);
            _digital.ClickNextButton();
            EmploymentSelection(employmentScenario);
            _digital.ClickNextButton();
        }
        public void AddMinorAccountOwner(
            string firstName = "Roger",
            string middleName = "Lil Hops",
            string lastName = "Bunny",
            string preferredName = "Chester",
            string dateOfBirth = "09302019",
            bool citizen = true,
            string socialSecurityNumber = "867530899")
        {
            _digital.AccountOwnersAddAccountOwnerButton.Click();
            _digital.ClearAccountOwnersNameScreen();
            _digital.AccountOwnersLegalFirstNameField.SendKeys(firstName);
            _digital.AccountOwnersLegalMiddleNameField.SendKeys(middleName);
            _digital.AccountOwnersLegalLastNameField.SendKeys(lastName);
            _digital.AccountOwnersPreferredFirstNameField.SendKeys(preferredName);
            _digital.ClickNextButton();
            _digital.AccountOwnersDateOfBirthField.SendKeys(dateOfBirth);
            if (citizen)
            {
                _digital.AccountOwnersAreYouACitizenYesRadial.Click();
            }
            else
            {
                _digital.AccountOwnersAreYouACitizenNoRadial.Click();
            }
            _digital.AccountOwnersSocialSecurityNumberField.SendKeys(socialSecurityNumber);
            _digital.ClickNextButton();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AccountOwnersOtherAddressRadial));
            _digital.ClickNextButton();
            _digital.SetPhoneInfoByPhone();
            _digital.ClickNextButton();

        }
        public void EditAccountOwner(
            int owner = 1,
            string firstName = "Daffy",
            string middleName = "Da",
            string lastName = "Duck",
            string preferredName = "Donald",
            string dateOfBirth = "08301983",
            bool citizen = true,
            string socialSecurityNumber = "867530900",
            string maritalStatus = "single",
            string dependents = "0",
            bool addPhone = false,
            string phoneSelect = "1",
            string phoneTypeSelect = "mobile",
            string phoneNumberSelect = "7894561001",
            string primaryEmail = "chewson@rwbaird.com",
            string secondaryEmail = "testing@testEmail.edu",
            int employmentScenario = 3)
        {
            _assertions.Test_96019();

            _digital.SelectAccountOwnerToEdit(owner);
            _digital.ClearAccountOwnersNameScreen();

            _assertions.Test_96020();

            _digital.AccountOwnersLegalFirstNameField.SendKeys(firstName);
            _digital.AccountOwnersLegalMiddleNameField.SendKeys(middleName);
            _digital.AccountOwnersLegalLastNameField.SendKeys(lastName);
            _digital.AccountOwnersPreferredFirstNameField.SendKeys(preferredName);
            _digital.ClickNextButton();

            _assertions.Test_96021();

            _digital.AccountOwnersDateOfBirthField.SendKeys(dateOfBirth);
            if (citizen)
            {
                _digital.AccountOwnersAreYouACitizenYesRadial.Click();
            }
            else
            {
                _digital.AccountOwnersAreYouACitizenNoRadial.Click();
            }
            _digital.AccountOwnersSocialSecurityNumberField.SendKeys(socialSecurityNumber);
            _digital.AccountOwnerMaritalStatusSelector(maritalStatus);
            _digital.AccountOwnersNumberOfDependentsField.SendKeys(dependents);
            _digital.ClickNextButton();

            _assertions.Test_96022();

            AddAddress();
            _digital.ClickNextButton();

            _assertions.Test_96023();

            _digital.SetPhoneInfoByPhone();
            if (addPhone)
            {
                _digital.AccountOwnersAddPhoneButton.Click();
                _digital.SetPhoneInfoByPhone
                    (phone: phoneSelect,
                    phoneType: phoneTypeSelect,
                    phoneNumber: phoneNumberSelect);
            }
            _digital.AccountOwnersRequiredEmailAddressField.Clear();
            _digital.AccountOwnersRequiredEmailAddressField.SendKeys(primaryEmail);
            _digital.AccountOwnersOptionalEmailAddressField.Clear();
            _digital.AccountOwnersOptionalEmailAddressField.SendKeys(secondaryEmail);
            _digital.ClickNextButton();

            _assertions.Test_96024();

            EmploymentSelection(employmentScenario);
            _digital.NextButton.Click();
        }
        public void EmploymentSelection(int employmentScenario)
        {
            switch (employmentScenario)
            {
                case 1:
                    _digital.EmploymentStatusSelector("employed");
                    _digital.ClickNextButton();
                    _digital.AccountOwnersEmploymentOccupation.SendKeys("Sign Spinner");
                    _digital.AccountOwnersEmploymentYearsEmployed.SendKeys("25");
                    _digital.AccountOwnersEmploymentEmployerName.SendKeys("National Hunters Association");
                    _digital.AccountOwnersEmploymentNatureOfBusiness.SendKeys("Nonprofit Organization");
                    _digital.CountrySelectorByAbbreviation();
                    _digital.AccountOwnersEmployerAddress.SendKeys("321 Ekaf Rd");
                    _digital.AccountOwnersEmployerAddress2.SendKeys("#3406");
                    _digital.AccountOwnersEmployerCity.SendKeys("Chicago");
                    _digital.EmployerStateSelectorByAbbreviation();
                    _digital.AccountOwnersEmployerPostalCode.SendKeys("60605");
                    break;
                case 2:
                    _digital.EmploymentStatusSelector("self-employed");
                    _digital.ClickNextButton();
                    _digital.AccountOwnersSelfEmployedNameOfBusiness.SendKeys("Ducks House of Business");
                    _digital.AccountOwnersSelfEmployedNatureOfBusiness.SendKeys("Duck Stuff");
                    _digital.AccountOwnersSelfEmployedYearsInBusiness.SendKeys("42");
                    _digital.ClickNextButton();
                    _digital.AccountOwnersFirstExistingAddressRadial.Click();
                    break;
                case 3:
                    _digital.EmploymentStatusSelector();
                    break;
                case 4:
                    _digital.EmploymentStatusSelector("retired");
                    break;
                case 5:
                    _digital.EmploymentStatusSelector("student");
                    break;
                case 6:
                    _digital.EmploymentStatusSelector("minor");
                    break;
                default:
                    _digital.EmploymentStatusSelector();
                    break;
            }
        }
        public void AddAccountToHousehold(
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            bool multipleOwners = false,
            string secondOwner = "2",
            string singleOwnerAccountType = "1",
            string multipleOwnerAccountType = "1")
        {

            _assertions.Test_96038();

            _digital.AddButton.Click();

            _assertions.Test_96039();

            _digital.AccountTransferFromSelector(firm);
            _digital.AccountNumberField.Clear();
            _digital.AccountNumberField.SendKeys(accountNumber);
            _digital.AccountOwnerSelector(accountOwner);
            if (multipleOwners)
            {
                _digital.AccountOwnerSelector(secondOwner);
                _digital.ClickNextButton();

                _assertions.Test_96046();

                _digital.AccountTypeSelector(multipleOwnerAccountType);
                _wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("(//input[@class='checkbox'])[" + multipleOwnerAccountType + "]")));
            }
            else
            {
                _digital.ClickNextButton();

                _assertions.Test_96045();

                _digital.AccountTypeSelector(singleOwnerAccountType);
                _wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("(//input[@class='checkbox'])[" + singleOwnerAccountType + "]")));
            }
            _digital.ClickNextButton();
        }
        public void SelectSubAccount(string subAccountType = "1")
        {
            try
            {
                _digital.AccountTypeSelector(subAccountType);
                _wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("(//input[@class='checkbox'])[" + subAccountType + "]")));
            }
            catch
            {
                _digital.AccountTypeSelector(subAccountType);
                _wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("(//input[@class='checkbox'])[" + subAccountType + "]")));
            }
            _actions.ScrollToElement(_digital.NextButton);
            _digital.ClickNextButton();
        }
        public void AddIndividualAccountToHousehold(
            bool transferOnDeath = false,
            bool useMargin = false,
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            string accountType = "1",
            string investmentLength = "short")
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                singleOwnerAccountType: accountType);
            AddAccountTransferOnDeath(transferOnDeath);
            AddAccountUseMargin(useMargin);
            _digital.InvestmentLengthSelector(investmentLength);

            if (transferOnDeath)
            {
                Assert.True(_digital.YesTransferOnDeathRadial.Selected);
            }
            else
            {
                Assert.True(_digital.NoTransferOnDeathRadial.Selected);
            }

            _digital.ClickNextButton();
        }
        public void AddAccountTransferOnDeath(bool transferOnDeath = false)
        {
            if (transferOnDeath)
            {
                _digital.YesTransferOnDeathRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.YesTransferOnDeathRadial));
            }
            else
            {
                _digital.YesTransferOnDeathRadial.Click();
                _digital.NoTransferOnDeathRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoTransferOnDeathRadial));
            }
        }
        public void AddAccountUseMargin(bool useMargin = false)
        {
            if (useMargin)
            {
                _digital.YesUseMarginRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.YesUseMarginRadial));
            }
            else
            {
                _digital.YesUseMarginRadial.Click();
                _digital.NoUseMarginRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoUseMarginRadial));
            }
        }

        public void AddIRAAccountToHousehold(
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            string accountType = "2",
            string iRAAccountType = "1",
            string investmentLength = "short",
            bool beneficiaries = false,
            int beneficiaryScenario = 1,
            string primaryBeneficiaryType = "person",
            string primaryBeneficiaryName = "Golden Goose",
            string primaryBeneficiaryRelationship = "spouse",
            string primaryBeneficiaryTaxId = "367530899",
            string primaryBeneficiaryContact = "Mr Bigglesworth",
            string primaryBeneficiaryDateOfBirth = "08301983",
            bool primaryBeneficiaryTrustTaxId = true,
            string contingentBeneficiaryType = "person",
            string contingentBeneficiaryName = "White Wolf",
            string contingentBeneficiaryRelationship = "spouse",
            string contingentBeneficiaryTaxId = "586225888",
            string contingentBeneficiaryContact = "Mr Anderson",
            string contingentBeneficiaryDateOfBirth = "04151997",
            bool contingentBeneficiaryTrustTaxId = true)
        {
            AddAccountToHousehold(
                firm: firm, 
                accountNumber: accountNumber, 
                accountOwner: accountOwner, 
                singleOwnerAccountType: accountType);
            SelectSubAccount(subAccountType: iRAAccountType);
            _digital.InvestmentLengthSelector(investmentLength);
            _digital.ClickNextButton();
            if (beneficiaries)
            {
                AddBeneficiaries(beneficiaryScenario,
                    primaryBeneficiaryType,
                    primaryBeneficiaryName,
                    primaryBeneficiaryRelationship,
                    primaryBeneficiaryTaxId,
                    primaryBeneficiaryContact,
                    primaryBeneficiaryDateOfBirth,
                    primaryBeneficiaryTrustTaxId,
                    contingentBeneficiaryType,
                    contingentBeneficiaryName,
                    contingentBeneficiaryRelationship,
                    contingentBeneficiaryTaxId,
                    contingentBeneficiaryContact,
                    contingentBeneficiaryDateOfBirth,
                    contingentBeneficiaryTrustTaxId);
            }
            else
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.BeneficiariesOptOutCheckbox));
                _digital.BeneficiariesOptOutCheckbox.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.BeneficiariesOptOutCheckbox));
            }
            _actions.ScrollToElement(_digital.NextButton);
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.NextButton));
            _digital.ClickNextButton();
        }
        public void AddBeneficiaryIRAAccountToHousehold(
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            string accountType = "2",
            string iRAAccountType = "4",
            bool rOTHInTitle = false,
            string investmentLength = "short",
            string originalHolderName = "Grey Gander",
            string originalHolderDateOfBirth = "08301914",
            string originalHolderDateOfDeath = "08301983",
            bool beneficiaries = false,
            int beneficiaryScenario = 1,
            string primaryBeneficiaryType = "person",
            string primaryBeneficiaryName = "Golden Goose",
            string primaryBeneficiaryRelationship = "spouse",
            string primaryBeneficiaryTaxId = "367530899",
            string primaryBeneficiaryContact = "Mr Bigglesworth",
            string primaryBeneficiaryDateOfBirth = "08301983",
            bool primaryBeneficiaryTrustTaxId = true,
            string contingentBeneficiaryType = "person",
            string contingentBeneficiaryName = "White Wolf",
            string contingentBeneficiaryRelationship = "spouse",
            string contingentBeneficiaryTaxId = "586225888",
            string contingentBeneficiaryContact = "Mr Anderson",
            string contingentBeneficiaryDateOfBirth = "04151997",
            bool contingentBeneficiaryTrustTaxId = true)
        {
            AddAccountToHousehold(
                firm: firm, 
                accountNumber: accountNumber, 
                accountOwner: accountOwner, 
                singleOwnerAccountType: accountType);
            SelectSubAccount(subAccountType: iRAAccountType);
            if (rOTHInTitle)
            {
                _digital.ROTHTitleYesRadial.Click();
            }
            else
            {
                _digital.ROTHTitleNoRadial.Click();
            }
            _digital.OriginalHolderDateOfDeath.SendKeys(originalHolderDateOfDeath);
            _digital.OriginalHolderDateOfBirth.SendKeys(originalHolderDateOfBirth);
            _digital.OriginalHolderName.SendKeys(originalHolderName);
            _digital.InvestmentLengthSelector(investmentLength);
            _digital.BeneficiariesOptOutCheckbox.Click();
            _actions.ScrollToElement(_digital.NextButton);
            _digital.ClickNextButton();

            if (beneficiaries)
            {
                AddBeneficiaries(beneficiaryScenario,
                    primaryBeneficiaryType,
                    primaryBeneficiaryName,
                    primaryBeneficiaryRelationship,
                    primaryBeneficiaryTaxId,
                    primaryBeneficiaryContact,
                    primaryBeneficiaryDateOfBirth,
                    primaryBeneficiaryTrustTaxId,
                    contingentBeneficiaryType,
                    contingentBeneficiaryName,
                    contingentBeneficiaryRelationship,
                    contingentBeneficiaryTaxId,
                    contingentBeneficiaryContact,
                    contingentBeneficiaryDateOfBirth,
                    contingentBeneficiaryTrustTaxId);
            }
            else
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.BeneficiariesOptOutCheckbox));
                _digital.BeneficiariesOptOutCheckbox.Click();
                _actions.ScrollToElement(_digital.NextButton);
            }
            _digital.ClickNextButton();
        }
        public void AddCoverdellIRAAccountToHousehold(
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            string accountType = "2",
            string iRAAccountType = "5",
            string investmentLength = "short")
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                singleOwnerAccountType: accountType);
            SelectSubAccount(subAccountType: iRAAccountType);
            _digital.InvestmentLengthSelector(investmentLength);
            _actions.ScrollToElement(_digital.NextButton);
            _digital.ClickNextButton();
            _digital.BenefitOwnerUnborn.Click();
            _digital.ClickNextButton();
        }
        public void AddMinorIRAAccountToHousehold(
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            string accountType = "2",
            string iRAAccountType = "6",
            bool rOTHInTitle = false,
            string investmentLength = "short",
            bool beneficiaries = false,
            int beneficiaryScenario = 1,
            string primaryBeneficiaryType = "person",
            string primaryBeneficiaryName = "Golden Goose",
            string primaryBeneficiaryRelationship = "spouse",
            string primaryBeneficiaryTaxId = "367530899",
            string primaryBeneficiaryContact = "Mr Bigglesworth",
            string primaryBeneficiaryDateOfBirth = "08301983",
            bool primaryBeneficiaryTrustTaxId = true,
            string contingentBeneficiaryType = "person",
            string contingentBeneficiaryName = "White Wolf",
            string contingentBeneficiaryRelationship = "spouse",
            string contingentBeneficiaryTaxId = "586225888",
            string contingentBeneficiaryContact = "Mr Anderson",
            string contingentBeneficiaryDateOfBirth = "04151997",
            bool contingentBeneficiaryTrustTaxId = true)
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                singleOwnerAccountType: accountType);
            SelectSubAccount(subAccountType: iRAAccountType);
            _digital.InvestmentLengthSelector(investmentLength);
            if (rOTHInTitle)
            {
                _digital.ROTHTitleYesRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.ROTHTitleYesRadial));
            }
            else
            {
                _digital.ROTHTitleNoRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.ROTHTitleNoRadial));
            }
            _actions.ScrollToElement(_digital.NextButton);
            _digital.ClickNextButton();
            AddMinorAccountOwner();
            _digital.AccountOwnerSelector(accountOwner);
            _digital.ClickNextButton();
            if (beneficiaries)
            {
                AddBeneficiaries(beneficiaryScenario,
                    primaryBeneficiaryType,
                    primaryBeneficiaryName,
                    primaryBeneficiaryRelationship,
                    primaryBeneficiaryTaxId,
                    primaryBeneficiaryContact,
                    primaryBeneficiaryDateOfBirth,
                    primaryBeneficiaryTrustTaxId,
                    contingentBeneficiaryType,
                    contingentBeneficiaryName,
                    contingentBeneficiaryRelationship,
                    contingentBeneficiaryTaxId,
                    contingentBeneficiaryContact,
                    contingentBeneficiaryDateOfBirth,
                    contingentBeneficiaryTrustTaxId);
            }
            else
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.BeneficiariesOptOutCheckbox));
                _digital.BeneficiariesOptOutCheckbox.Click();
                _actions.ScrollToElement(_digital.NextButton);
            }
            _digital.ClickNextButton();
        }
        //Cases: Dictated by beneficiaryScenario
        public void AddBeneficiaries(int beneficiaryScenario = 1,
            string primaryBeneficiaryType = "person",
            string primaryBeneficiaryName = "Golden Goose",
            string primaryBeneficiaryRelationship = "spouse",
            string primaryBeneficiaryTaxId = "367530899",
            string primaryBeneficiaryContact = "Mr Bigglesworth",
            string primaryBeneficiaryDateOfBirth = "08301983",
            bool primaryBeneficiaryTrustTaxId = true,
            string contingentBeneficiaryType = "person",
            string contingentBeneficiaryName = "White Wolf",
            string contingentBeneficiaryRelationship = "spouse",
            string contingentBeneficiaryTaxId = "586225888",
            string contingentBeneficiaryContact = "Mr Anderson",
            string contingentBeneficiaryDateOfBirth = "04151997",
            bool contingentBeneficiaryTrustTaxId = true)
        {
            //TODO: add cases
            //Add Primary beneficiary with 100 % allocation - Done Case: 1
            //Add Contingent beneficiary with 100 % allocation - This to be used as a negative testcase as you can not continue with only a contingent beneficiary.  - Done Case: 2
            //Add Primary and Contingent beneficiary with 100 % allocation.  - Done Case: 3
            //Add 2 Primary beneficiaries, split the allocation and select stirpes.  - Done Case: 4
            //Add 2 Primary beneficiaries, split the allocation (65-35 here) and select stirpes.  - Done Case: 5
            switch (beneficiaryScenario)
            {
                // Primary Beneficiary added
                case 1:
                    _digital.AddPrimaryBeneficiaryButton.Click();
                    _digital.AddButton.Click();
                    if (primaryBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryRelationship,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    else if (primaryBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTaxId,
                            primaryBeneficiaryContact);
                    }
                    else if (primaryBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTrustTaxId,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    _actions.ScrollToElement(_digital.NextButton);
                    _digital.ClickNextButton();
                    break;
                // Contingent Beneficiary added - This is a negative test scenario, account must have primary to have contingent.
                case 2:
                    _digital.AddContingentBeneficiaryButton.Click();
                    _digital.AddButton.Click();
                    if (contingentBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryRelationship,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    else if (contingentBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTaxId,
                            contingentBeneficiaryContact);
                    }
                    else if (contingentBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTrustTaxId,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    break;
                //Primary and Contingent beneficiaries added
                case 3:
                    _digital.AddPrimaryBeneficiaryButton.Click();
                    _digital.AddButton.Click();
                    if (primaryBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryRelationship,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    else if (primaryBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTaxId,
                            primaryBeneficiaryContact);
                    }
                    else if (primaryBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTrustTaxId,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    _digital.ClickNextButton();
                    _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AddContingentBeneficiaryButton));
                    _actions.ScrollToElement(_digital.AddContingentBeneficiaryButton);
                    try
                    {
                        _digital.AddContingentBeneficiaryButton.Click();
                    }
                    catch
                    {
                        _digital.AddContingentBeneficiaryButton.Click();
                    }
                    _digital.AddButton.Click();
                    if (contingentBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryRelationship,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    else if (contingentBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTaxId,
                            contingentBeneficiaryContact); ;
                    }
                    else if (contingentBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTrustTaxId,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    _actions.ScrollToElement(_digital.NextButton);
                    _digital.ClickNextButton();
                    break;
                // 2 Primary Beneficiaries with Allocations
                case 4:
                    _digital.AddPrimaryBeneficiaryButton.Click();
                    _digital.AddButton.Click();
                    if (primaryBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryRelationship,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    else if (primaryBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTaxId,
                            primaryBeneficiaryContact);
                    }
                    else if (primaryBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTrustTaxId,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    _digital.ClickNextButton();
                    _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AddPrimaryBeneficiaryButton));
                    _actions.ScrollToElement(_digital.AddPrimaryBeneficiaryButton);
                    try
                    {
                        _digital.AddPrimaryBeneficiaryButton.Click();
                    }
                    catch
                    {
                        _digital.AddPrimaryBeneficiaryButton.Click();
                    }
                    _digital.AddButton.Click();
                    //using contingent variables to handle the second beneficiary
                    if (contingentBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryRelationship,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    else if (contingentBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTaxId,
                            contingentBeneficiaryContact);
                    }
                    else if (contingentBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTrustTaxId,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    _digital.ClickNextButton();
                    _digital.PrimaryBeneficiaryAllocationFieldSelector();
                    _digital.PrimaryBeneficiaryStirpesSelector();
                    _digital.PrimaryBeneficiaryAllocationFieldSelector(beneficiary: "1");
                    _digital.PrimaryBeneficiaryStirpesSelector("1");
                    break;
                // 2 Primary and 2 Contingent with allocations and Stirpes
                case 5:
                    _digital.AddPrimaryBeneficiaryButton.Click();
                    _digital.AddButton.Click();
                    if (primaryBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryRelationship,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    else if (primaryBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTaxId,
                            primaryBeneficiaryContact);
                    }
                    else if (primaryBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTrustTaxId,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    _digital.ClickNextButton();
                    _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AddPrimaryBeneficiaryButton));
                    _actions.ScrollToElement(_digital.AddPrimaryBeneficiaryButton);
                    try
                    {
                        _digital.AddPrimaryBeneficiaryButton.Click();
                    }
                    catch
                    {
                        _digital.AddPrimaryBeneficiaryButton.Click();
                    }
                    _digital.AddButton.Click();
                    //using contingent variables to handle the second beneficiary
                    if (contingentBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryRelationship,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    else if (contingentBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTaxId,
                            contingentBeneficiaryContact);
                    }
                    else if (contingentBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTrustTaxId,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    _digital.ClickNextButton();
                    _digital.PrimaryBeneficiaryAllocationFieldSelector();
                    _digital.PrimaryBeneficiaryStirpesSelector();
                    _digital.PrimaryBeneficiaryAllocationFieldSelector(beneficiary: "1");
                    _digital.PrimaryBeneficiaryStirpesSelector("1");
                    _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AddContingentBeneficiaryButton));
                    _actions.ScrollToElement(_digital.AddContingentBeneficiaryButton);
                    try
                    {
                        _digital.AddContingentBeneficiaryButton.Click();
                    }
                    catch
                    {
                        _digital.AddContingentBeneficiaryButton.Click();
                    }
                    _digital.AddButton.Click();
                    if (contingentBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryRelationship,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    else if (contingentBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTaxId,
                            contingentBeneficiaryContact);
                    }
                    else if (contingentBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            contingentBeneficiaryType,
                            contingentBeneficiaryName,
                            contingentBeneficiaryTrustTaxId,
                            contingentBeneficiaryDateOfBirth,
                            contingentBeneficiaryTaxId);
                    }
                    _digital.ClickNextButton();
                    _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.AddContingentBeneficiaryButton));
                    _actions.ScrollToElement(_digital.AddContingentBeneficiaryButton);
                    try
                    {
                        _digital.AddContingentBeneficiaryButton.Click();
                    }
                    catch
                    {
                        _digital.AddContingentBeneficiaryButton.Click();
                    }
                    _digital.AddButton.Click();
                    if (primaryBeneficiaryType == "person")
                    {
                        AddBeneficiaryTypePerson(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryRelationship,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    else if (primaryBeneficiaryType == "entity")
                    {
                        AddBeneficiaryTypeEntity(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTaxId,
                            primaryBeneficiaryContact);
                    }
                    else if (primaryBeneficiaryType == "trust")
                    {
                        AddBeneficiaryTypeTrust(
                            primaryBeneficiaryType,
                            primaryBeneficiaryName,
                            primaryBeneficiaryTrustTaxId,
                            primaryBeneficiaryDateOfBirth,
                            primaryBeneficiaryTaxId);
                    }
                    _digital.ClickNextButton();
                    _actions.ScrollToElement(_digital.BackButton);
                    _digital.ContingentBeneficiaryAllocationFieldSelector(allocation: "65");
                    _digital.ContingentBeneficiaryStirpesSelector();
                    _digital.ContingentBeneficiaryAllocationFieldSelector(beneficiary: "1", allocation: "35");
                    _digital.ContingentBeneficiaryStirpesSelector("1");
                    break;
                default:
                    _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.BeneficiariesOptOutCheckbox));
                    _digital.BeneficiariesOptOutCheckbox.Click();
                    _actions.ScrollToElement(_digital.NextButton);
                    break;
            }
        }
        public void AddBeneficiaryTypePerson(
            string beneficiaryType,
            string beneficiaryName,
            string beneficiaryRelationship,
            string beneficiaryDateOfBirth,
            string beneficiaryTaxId)
        {
            _digital.BeneficiaryTypeSelector(beneficiaryType);
            _digital.ClickNextButton();
            _digital.BeneficiaryFullNameField.SendKeys(beneficiaryName);
            _digital.BeneficiaryRelationshipSelector(beneficiaryRelationship);
            _digital.BeneficiaryDateOfBirthField.SendKeys(beneficiaryDateOfBirth);
            _digital.BeneficiaryTaxIDField.SendKeys(beneficiaryTaxId);
            _actions.ScrollToElement(_digital.NextButton);
        }
        public void AddBeneficiaryTypeEntity(
            string beneficiaryType,
            string beneficiaryName,
            string beneficiaryTaxId,
            string beneficiaryContact)
        {
            _digital.BeneficiaryTypeSelector(beneficiaryType);
            _digital.ClickNextButton();
            _digital.BeneficiaryFullNameField.SendKeys(beneficiaryName);
            _digital.BeneficiaryTaxIDField.SendKeys(beneficiaryTaxId);
            _digital.BeneficiaryContactField.SendKeys(beneficiaryContact);
            _actions.ScrollToElement(_digital.NextButton);
        }
        public void AddBeneficiaryTypeTrust(
            string beneficiaryType,
            string beneficiaryName,
            bool beneficiaryTrustTaxId,
            string beneficiaryDateOfBirth,
            string beneficiaryTaxId)
        {
            _digital.BeneficiaryTypeSelector(beneficiaryType);
            _digital.ClickNextButton();
            _digital.BeneficiaryFullNameField.SendKeys(beneficiaryName);
            if (beneficiaryTrustTaxId)
            {
                _digital.BeneficiaryTrustSSNIdentificationRadial.Click();
                _digital.BeneficiaryTrustTaxIdIdentificationRadial.Click();
            }
            else
            {
                _digital.BeneficiaryTrustSSNIdentificationRadial.Click();
            }
            _digital.BeneficiaryTrustDateOfTrust.SendKeys(beneficiaryDateOfBirth);
            _digital.BeneficiaryTaxIDField.SendKeys(beneficiaryTaxId);
            _actions.ScrollToElement(_digital.NextButton);
        }
        public void AddOther529CollegeAccountToHousehold(
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            bool multipleOwners = false,
            bool uTMAUGMA = false,
            string secondOwner = "2",
            string singleOwnerAccountType = "3",
            string multipleOwnerAccountType = "2",
            string otherAccountType = "1",
            string investmentLength = "short",
            bool assertions = false)
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                secondOwner: secondOwner,
                multipleOwners: multipleOwners,
                singleOwnerAccountType: singleOwnerAccountType,
                multipleOwnerAccountType: multipleOwnerAccountType);
            SelectSubAccount(subAccountType: otherAccountType);
            UTMAUGMA(uTMAUGMA);
            _digital.InvestmentPeriodSelector(investmentLength);
            _digital.ClickNextButton();
            _digital.AccountOwnerSelector(accountOwner);
            Thread.Sleep(500);
            _digital.ClickNextButton();
        }
        public void AddOtherCorporateAccountToHousehold(
            string firm = "charles-schwab",
            string corporationName = "Daffys Duck Hunting Supplies",
            string corporationTaxId = "867530900",
            string accountNumber = "43218765",
            string accountOwner = "1",
            bool multipleOwners = false,
            string secondOwner = "2",
            string singleOwnerAccountType = "3",
            string multipleOwnerAccountType = "2",
            string otherAccountType = "2",
            bool assertions = false)
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                secondOwner: secondOwner,
                multipleOwners: multipleOwners,
                singleOwnerAccountType: singleOwnerAccountType,
                multipleOwnerAccountType: multipleOwnerAccountType);
            SelectSubAccount(subAccountType: otherAccountType);
            _digital.CorporationNameCorporateAccount.SendKeys(corporationName);
            _digital.CorporationNameCorporateTaxId.SendKeys(corporationTaxId);
            _actions.ScrollToElement(_digital.NextButton);
            _digital.ClickNextButton();
        }
        public void AddOtherOtherAccountToHousehold(
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            bool multipleOwners = false,
            string secondOwner = "2",
            string singleOwnerAccountType = "3",
            string multipleOwnerAccountType = "2",
            string otherAccountType = "3",
            bool assertions = false)
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                secondOwner: secondOwner,
                multipleOwners: multipleOwners,
                singleOwnerAccountType: singleOwnerAccountType,
                multipleOwnerAccountType: multipleOwnerAccountType);
            SelectSubAccount(subAccountType: otherAccountType);
        }
        public void AddOtherTrustAccountToHousehold(
            string firm = "charles-schwab",
            string trustName = "Trusty Tims",
            string trustCreatedOnDate = "09112001",
            string trustInvestmentLength = "short",
            string trustTIN = "867530900",
            string grantorName = "Pied Piper",
            bool successorTrustee = false,
            string successorTrusteeName = "Dole Ingout-Cash",
            string state = "il",
            string accountNumber = "43218765",
            string accountOwner = "1",
            bool multipleOwners = false,
            string secondOwner = "2",
            string singleOwnerAccountType = "3",
            string multipleOwnerAccountType = "2",
            string otherAccountType = "4",
            bool assertions = false)
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                secondOwner: secondOwner,
                multipleOwners: multipleOwners,
                singleOwnerAccountType: singleOwnerAccountType,
                multipleOwnerAccountType: multipleOwnerAccountType);
            SelectSubAccount(subAccountType: otherAccountType);
            _digital.TrustNameField.SendKeys(trustName);
            _digital.TrustStateSelectorByAbbreviation(state);
            _digital.TrustCreatedDateField.SendKeys(trustCreatedOnDate);
            _digital.InvestmentLengthSelector(trustInvestmentLength);
            _digital.TrustTINField.SendKeys(trustTIN);
            _digital.ClickNextButton();
            if (successorTrustee)
            {
                _digital.GrantorNameField.SendKeys(grantorName);
                _digital.TrusteeYesRadial.Click();
                _digital.SuccessorTrusteeNameField.SendKeys(successorTrusteeName);
            }
            else
            {
                _digital.GrantorNameField.SendKeys(grantorName);
                _digital.TrusteeNoRadial.Click();
            }
            _digital.ClickNextButton();
            _digital.ClickNextButton();
        }
        public void AddOtherUGMAUTMAAccountToHousehold(
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            bool uTMAUGMA = false,
            string singleOwnerAccountType = "3",
            string otherAccountType = "1",
            string investmentLength = "short",
            bool assertions = false)
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                singleOwnerAccountType: singleOwnerAccountType);
            SelectSubAccount(subAccountType: otherAccountType);
            UTMAUGMA(uTMAUGMA);
            _digital.InvestmentPeriodSelector(investmentLength);
            _digital.ClickNextButton();
            _digital.AccountOwnerSelector(accountOwner);
            Thread.Sleep(500);
            _digital.ClickNextButton();
        }
        public void AddJointAccountToHousehold(
            bool transferOnDeath = false,
            bool useMargin = false,
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            string secondOwner = "2",
            string accountType = "1",
            string jointAccountType = "1",
            string investmentLength = "short")
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                secondOwner: secondOwner,
                multipleOwners: true,
                multipleOwnerAccountType: accountType);
            SelectSubAccount(subAccountType: jointAccountType);
            _digital.AccountOwnerSelector(accountOwner);
            if (transferOnDeath)
            {
                _digital.YesTransferOnDeathRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.YesTransferOnDeathRadial));
            }
            else
            {
                _digital.YesTransferOnDeathRadial.Click();
                _digital.NoTransferOnDeathRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoTransferOnDeathRadial));
            }
            if (useMargin)
            {
                _digital.YesUseMarginRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.YesUseMarginRadial));
            }
            else
            {
                _digital.YesUseMarginRadial.Click();
                _digital.NoUseMarginRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoUseMarginRadial));
            }
            _digital.InvestmentLengthSelector(investmentLength);
            _digital.ClickNextButton();
        }
        public void AddJointTICAccountToHousehold(
            bool useMargin = false,
            string firm = "charles-schwab",
            string accountNumber = "43218765",
            string accountOwner = "1",
            string secondOwner = "2",
            string accountType = "1",
            string jointAccountType = "3",
            string investmentLength = "short")
        {
            AddAccountToHousehold(
                firm: firm,
                accountNumber: accountNumber,
                accountOwner: accountOwner,
                secondOwner: secondOwner,
                multipleOwners: true,
                multipleOwnerAccountType: accountType);
            SelectSubAccount(subAccountType: jointAccountType);
            _digital.AccountOwnerSelector(accountOwner);
            if (useMargin)
            {
                _digital.YesUseMarginRadial.Click();
            }
            else
            {
                _digital.YesUseMarginRadial.Click();
                _digital.NoUseMarginRadial.Click();
            }
            _digital.InvestmentLengthSelector(investmentLength);
            _digital.ClickNextButton();
        }
        public void BairdAccountDebitCard(
            bool debitCard = false,
            bool debitCardChecks = false,
            bool checks = false,
            string fileName = "TestFile.jpg",
            bool successfulUpload = true,
            bool fileUpload = false)
        {
            //var file = DrawText(text: "This is an image", font: new Font("Tahoma", 8), textColor: Color.Orange, backColor: Color.Black);
            //file.Save(fileName);
            //var filePath = Path.GetFullPath(fileName);

            _assertions.Test_96075();

            if (debitCard)
            {
                try
                {
                    _digital.YesRadial.Click();
                }
                catch
                {
                    _digital.YesRadial.Click();
                }
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.YesRadial));
                _digital.ClickNextButton();

                _assertions.Test_96079();
                
                if (debitCardChecks)
                {
                    try
                    {
                        _digital.YesRadial.Click();
                    }
                    catch
                    {
                        _digital.YesRadial.Click();
                    }
                    _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.YesRadial));
                    _digital.ClickNextButton();

                    _assertions.Test_96086();

                    _digital.NoCheckbox.Click();
                    _digital.ClickNextButton();

                    _assertions.Test_96103();

                    //if (fileUpload)
                    //{
                    //    if (successfulUpload)
                    //    {
                    //        _digital.FileUpload.SendKeys(filePath);

                    //        Assert.True(_digital.FileUploadTestFile.Displayed);
                    //    }
                    //    else
                    //    {
                    //        _digital.FileUpload.SendKeys(filePath);

                    //        Assert.True(_digital.FileUploadError.Displayed);

                    //        _digital.CloseButton.Click();

                    //        _digital.SignaturesContactMeRadial.Click();
                    //    }
                    //}
                    //else
                    //{
                        _digital.SignaturesContactMeRadial.Click();
                    //}
                    _digital.ClickNextButton();

                    _assertions.Test_96108();

                    //Another button with an 'a' element instead of button
                    _digital.AElementNextButton.Click();
                }
                else 
                {
                    try
                    {
                        _digital.NoRadial.Click();
                    }
                    catch
                    {
                        _digital.NoRadial.Click();
                    }
                    _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoRadial));
                    _digital.ClickNextButton();
                }
            }
            else
            {
                try
                {
                    _digital.NoRadial.Click();
                }
                catch
                {
                    _digital.NoRadial.Click();
                }
                Thread.Sleep(500);
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoRadial));
                _digital.ClickNextButton();
                Thread.Sleep(1500);
                if (checks)
                {
                    try
                    {
                        _digital.YesRadial.Click();
                    }
                    catch
                    {
                        _digital.YesRadial.Click();
                    }
                    _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.YesRadial));
                    _digital.ClickNextButton();

                    _assertions.Test_96086();

                    _digital.NoCheckbox.Click();
                    _digital.ClickNextButton();

                    _assertions.Test_96103();

                    //if (fileUpload)
                    //{
                    //    if (successfulUpload)
                    //    {
                    //        _digital.FileUpload.SendKeys(filePath);

                    //        Assert.True(_digital.FileUploadTestFile.Displayed);
                    //    }
                    //    else
                    //    {
                    //        _digital.FileUpload.SendKeys(filePath);

                    //        Assert.True(_digital.FileUploadError.Displayed);

                    //        _digital.CloseButton.Click();

                    //        _digital.SignaturesContactMeRadial.Click();
                    //    }
                    //}
                    //else
                    //{
                        _digital.SignaturesContactMeRadial.Click();
                    //}
                    _digital.ClickNextButton();

                    _assertions.Test_96108();

                    //Another button with an 'a' element instead of button
                    _digital.AElementNextButton.Click();
                }
                else 
                {
                    Thread.Sleep(500);
                    try
                    {
                        _digital.NoRadial.Click();
                    }
                    catch
                    {
                        _digital.NoRadial.Click();
                    }
                    Thread.Sleep(500);
                    _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoRadial));
                    _digital.ClickNextButton();
                    Thread.Sleep(500);
                }
            }
        }
        public void ExternalBankAccount(bool externalAccount = false, bool checking = false, bool multipleOwners = false,string bankName = "The Vault", string bankAccountNumber = "12512213212412412")  // Test Case Id: 129511
        {
            _assertions.Test_96110();

            if (externalAccount)
            {
                Thread.Sleep(500);
                try
                {
                    _digital.AddButton.Click();
                }
                catch
                {
                    _digital.AddButton.Click();
                }

                _assertions.Test_96112();

                _digital.AccountOwnerSelector("1");
                if (multipleOwners)
                {
                    _digital.AccountOwnerSelector("2");
                }
                _digital.ExternalBankName.SendKeys(bankName);
                _digital.ExternalBankRoutingNumber.SendKeys("123223314");
                _digital.ExternalBankAccountNumber.SendKeys(bankAccountNumber);
                _digital.ExternalBankConfirmAccountNumber.SendKeys(bankAccountNumber);
                if (checking)
                {
                    _digital.ExternalBankCheckingRadial.Click();
                    _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.ExternalBankCheckingRadial));
                }
                else
                {
                    _digital.ExternalBankSavingsRadial.Click();
                    _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.ExternalBankSavingsRadial));
                }
                _digital.ClickNextButton();
                Thread.Sleep(25000);
                _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.OkButton)).Click();
                _digital.ClickNextButton();
                _digital.SignaturesContactMeRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.SignaturesContactMeRadial));
                
                _assertions.Test_96113();
                
                _digital.ClickNextButton();
                _digital.CheckBox.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.CheckBox));
                _digital.ExternalBankVerificationNextButton.Click();
            }
            else
            {
                Thread.Sleep(500);
                _digital.NoExternalBankAccountCheckbox.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoExternalBankAccountCheckbox));
            }
        }
        public void SuccessfulExternalBankValidation(bool checking = true, bool multipleOwners = false) // Test Case Id: 129508
        {
            Thread.Sleep(500);
            try
            {
                _digital.AddButton.Click();
            }
            catch
            {
                _digital.AddButton.Click();
            }
            _digital.AccountOwnerSelector("1");
            if (multipleOwners)
            {
                _digital.AccountOwnerSelector("2");
            }
            _digital.ExternalBankName.SendKeys("The Vault");
            _digital.ExternalBankRoutingNumber.SendKeys("122199983");
            _digital.ExternalBankAccountNumber.SendKeys("89455");
            _digital.ExternalBankConfirmAccountNumber.SendKeys("89455");
            if (checking)
            {
                _digital.ExternalBankCheckingRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.ExternalBankCheckingRadial));
            }
            else
            {
                _digital.ExternalBankSavingsRadial.Click();
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.ExternalBankSavingsRadial));
            }
            _digital.ClickNextButton();
            Thread.Sleep(25000);
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.CheckBox));
                _digital.CheckBox.Click();
            }
            catch
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.CheckBox));
                _digital.CheckBox.Click();
            }
            _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.CheckBox));

            _assertions.Test_96115();

            _digital.ExternalBankVerificationNextButton.Click();
        }
        public void TransferBetweenAccounts(bool transfer = false)
        {
            _assertions.Test_96117();

            if (transfer)
            {
                Thread.Sleep(500);
                try
                {
                    _digital.YesRadial.Click();
                }
                catch
                {
                    _digital.YesRadial.Click();
                }
                Thread.Sleep(500);
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.YesRadial));
                _digital.ClickNextButton();
                Thread.Sleep(500);
            }
            else
            {
                Thread.Sleep(500);
                try
                {
                    _digital.NoRadial.Click();
                }
                catch
                {
                    _digital.NoRadial.Click();
                }
                Thread.Sleep(500);
                _wait.Until(ExpectedConditions.ElementToBeSelected(_digital.NoRadial));
                _digital.ClickNextButton();
                Thread.Sleep(500);
            }
        }
        public void SelectTrustedContactAndAddDetails(
            string fullName = "Rumpelstiltskin",
            string email = "chewson@rwbaird.com",
            string phoneNumber = "1234567890",
            string address1 = "123 Fake St",
            string address2 = "#234",
            string city = "Chicago",
            string postalCode = "60605")
        {
            _assertions.Test_96121();

            _digital.CheckBox.Click();
            _digital.YesButton.Click();
            _digital.TrustedContactsFullNameField.SendKeys(fullName);
            _digital.TrustedContactsEmailField.SendKeys(email);
            _digital.TrustedContactsPhoneTypeSelector();
            _digital.TrustedContactsPhoneCountryCodeSelector();
            _digital.TrustedContactsPhoneNumberField.Clear();
            _digital.TrustedContactsPhoneNumberField.SendKeys(phoneNumber);
            _digital.HouseholdDetailsAddress1Field.SendKeys(address1);
            _digital.HouseholdDetailsAddress2Field.SendKeys(address2);
            _digital.HouseholdDetailsCityField.SendKeys(city);
            _digital.StateSelectorByAbbreviation();
            _digital.HouseholdDetailsPostalCodeField.SendKeys(postalCode);
            try
            {
                _digital.SaveButton.Click();
            }
            catch
            {
                _digital.SaveButton.Click();
            }
            _wait.Until(ExpectedConditions.ElementToBeClickable(_digital.LetsMoveOnButton));
        }
        //TODO: Update true flows. This was not finished during initial pass.
        public void SelectSecuritiesIndustryAndAffiliationsDetails(
            bool broker = false,
            string brokerAccountOwner = "1",
            bool bairdAssociate = false,
            string bairdAssociateAccountOwner = "1",
            bool securitiesFirmExchange = false,
            string securitiesFirmExchangeAccountOwner = "1",
            bool publiclyTraded = false,
            string publiclyTradedAccountOwner = "1",
            bool largeTrader = false,
            string largeTraderAccountOwner = "1",
            bool assertions = false)
        {
            _assertions.Test_96129();

            _digital.ClickGetStartedButtonSecuritiesIndustry();
            
            _assertions.Test_96130();

            if (broker)
            {
                _digital.YesButton.Click();
                _digital.AccountOwnerSelector(brokerAccountOwner);

                _assertions.Test_96130a();

                _digital.ClickNextButton();
            }
            else
            {
                _digital.NoButton.Click();
            }

            _assertions.Test_96131();

            Thread.Sleep(500);
            if (bairdAssociate)
            {
                _digital.YesButton.Click();
                _digital.AccountOwnerSelector(bairdAssociateAccountOwner);

                _assertions.Test_96131a();

                _digital.ClickNextButton();
            }
            else
            {
                _digital.NoButton.Click();
            }

            _assertions.Test_96132();

            Thread.Sleep(500);
            if (securitiesFirmExchange)
            {
                _digital.YesButton.Click();
                _digital.AccountOwnerSelector(securitiesFirmExchangeAccountOwner);

                _assertions.Test_96132a();

                _digital.ClickNextButton();
            }
            else
            {
                _digital.NoButton.Click();
            }

            _assertions.Test_96133();

            Thread.Sleep(500);
            if (publiclyTraded)
            {
                _digital.YesButton.Click();
                _digital.AccountOwnerSelector(publiclyTradedAccountOwner);

                _assertions.Test_96133a();

                _digital.ClickNextButton();
            }
            else
            {
                _digital.NoButton.Click();
            }

            _assertions.Test_96134();

            Thread.Sleep(500);
            if (largeTrader)
            {
                _digital.YesButton.Click();

                _assertions.Test_96134a();

                _digital.ClickNextButton();
            }
            else
            {
                _digital.NoButton.Click();
            }
            _digital.ClickLetsMoveOn();
        }
        public void AdditionalInformationSelectionWithAssertions(
            bool additionalInformation = false, 
            bool fileUpload = false,
            bool successfulUpload = true,
            string fileName = "TestFile.jpg",
            string comment = "I just wanted you to know that this area holds text responses that are relayed to your FA")
        {
            _assertions.Test_96161();

            if (additionalInformation)
            {
                _digital.YesButton.Click();
                _digital.AdditionalInformationCommentField.SendKeys(comment);

                _assertions.Test_96162();


                //if (fileUpload)
                //{
                //    var file = DrawText(text: "This is an image", font: new Font("Tahoma", 8), textColor: Color.Orange, backColor: Color.Black);
                //    file.Save(fileName);
                //    var filePath = Path.GetFullPath(fileName);
                //    if (successfulUpload)
                //    {
                //        _digital.FileUpload.SendKeys(filePath);

                //        Assert.True(_digital.FileUploadTestFile.Displayed);
                //    }
                //    else
                //    {
                //        _digital.FileUpload.SendKeys(filePath);

                //        Assert.True(_digital.FileUploadError.Displayed);

                //        _digital.CloseButton.Click();
                //    }
                //}
                _digital.ClickNextButton();
            }
            else
            {
                _digital.NoButton.Click();
            }
        }
        public void SubmitWithoutStatements()
        {
            _actions.ScrollToElement(_digital.SubmitButton);

            _assertions.Test_96163();
            Assert.True(_digital.SubmitButton.Enabled);

            try
            {
                _digital.SubmitButton.Click();
            }
            catch
            {
                _digital.SubmitButton.Click();
            }
            _digital.SubmitWithoutStatementsButton.Click();
            _digital.ClickNextButton();
        }
        public void Submit()
        {
            _actions.ScrollToElement(_digital.SubmitButton);

            _assertions.Test_96163();
            Assert.True(_digital.SubmitButton.Enabled);

            try
            {
                _digital.SubmitButton.Click();
            }
            catch
            {
                _digital.SubmitButton.Click();
            }
            _digital.ClickNextButton();
        }
        public void UTMAUGMA(bool uTMAUGMA)
        {
            if (uTMAUGMA)
            {
                _digital.YesCheckbox.Click();
            }
            else
            {
                _digital.NoCheckbox.Click();
            }
        }
    }
}