using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Xunit;
using SeleniumExtras.WaitHelpers;

namespace SeleniumPOC.PageObjects
{
    public class TestAssertionLibrary
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;
        private readonly DigitalOnboarding _digital;
        private readonly BairdOnLine _bairdOnLine;
        private readonly TransitionTracker _transitionTracker;

        public TestAssertionLibrary(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            _driver = driver;
            _wait = wait;
            _actions = actions;
            _digital = new DigitalOnboarding(driver, wait, actions);
            _bairdOnLine = new BairdOnLine(driver, wait, actions);
            _transitionTracker = new TransitionTracker(driver, wait, actions);
        }
        
        // Household Details -----------------------------

        public void Test_95971()
        {
            // Test Case Id: 95971
            Assert.True(_digital.HouseholdDetailsHeader.Displayed);
            Assert.True(_digital.HouseholdDetailsBodyText.Displayed);
            Assert.True(_digital.HouseholdDetailsCurrentStatus.Displayed);
            Assert.True(_digital.ExitButton.Displayed);
            Assert.True(_digital.HouseholdDetailsScreenGetStartedButton.Displayed);
        }
        public void Test_95976()
        {
            // Test Case Id: 95976
            Assert.True(_digital.HouseholdDetailsAddress1Field.Displayed);
            Assert.True(_digital.HouseholdDetailsAddress2Field.Displayed);
            Assert.True(_digital.HouseholdDetailsCityField.Displayed);
            Assert.True(_digital.HouseholdDetailsCountryField.Displayed);
            Assert.True(_digital.HouseholdDetailsPostalCodeField.Displayed);
            Assert.True(_digital.HouseholdDetailsStateField.Displayed);
            Assert.True(_digital.HouseholdDetailsOwnField.Displayed);
            Assert.True(_digital.HouseholdDetailsRentField.Displayed);
            Assert.True(_digital.HouseholdDetailsAddressesHeader.Displayed);
            Assert.True(_digital.HouseholdDetailsRentOrOwn.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
        }
        public void Test_95979()
        {
            // Test Case Id: 95979
            Assert.True(_digital.HouseholdDetailsSeparateMailingAddressHeader.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NoButton.Displayed);
            Assert.True(_digital.YesButton.Displayed);
        }
        public void Test_95984()
        {
            // Test Case Id: 95984
            Assert.True(_digital.HouseholdDetailsCommunicationPreferenceHeader.Displayed);
            Assert.True(_digital.HouseholdDetailsCommunicationPreferenceDescription.Displayed);
            Assert.True(_digital.HouseholdDetailsCommunicationPreferenceField.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_95987()
        {
            // Test Case Id: 95987
            Assert.True(_digital.HouseholdDetailsFinancialDetailsHeader.Displayed);
            Assert.True(_digital.HouseholdDetailsFinancialSummaryAnnualHouseholdIncomeField.Displayed);
            Assert.True(_digital.HouseholdDetailsFinancialSummaryHouseholdNetWorthField.Displayed);
            Assert.True(_digital.HouseholdDetailsFinancialSummaryInvestableAssetsField.Displayed);
            Assert.True(_digital.HouseholdDetailsFinancialSummaryTaxBracketField.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_95988()
        {
            // Test Case Id: 95988
            Assert.True(_digital.HouseholdDetailsInvestmentExperienceHeader.Displayed);
            Assert.True(_digital.HouseholdDetailsInvestmentExperienceBody.Displayed);
            Assert.True(_digital.HouseholdDetailsInvestmentExperienceStocksSlider.Displayed);
            Assert.True(_digital.HouseholdDetailsInvestmentExperienceBondsSlider.Displayed);
            Assert.True(_digital.HouseholdDetailsInvestmentExperienceMutualFundsSlider.Displayed);
            Assert.True(_digital.HouseholdDetailsInvestmentExperienceOptionsSlider.Displayed);
            Assert.True(_digital.HouseholdDetailsInvestmentExperienceAnnuitiesLifeInsuranceSlider.Displayed);
            _actions.ScrollToElement(_digital.SaveAndExitButton);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
            _actions.ScrollToElement(_digital.HouseholdDetailsInvestmentExperienceHeader);
        }
        public void Test_95989()
        {
            // Test Case Id: 95989
            Assert.True(_digital.HouseholdDetailsAccountStatementsHeader.Displayed);
            Assert.True(_digital.HouseholdDetailsAccountStatementsBody.Displayed);
            Assert.True(_digital.HouseholdDetailsAccountStatementsFileDescription.Displayed);
            Assert.True(_digital.HouseholdDetailsAccountStatementsChooseFilesButton.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }

        // Account Owners -------------------------------------------

        public void Test_96019()
        {
            // Test Case Id: 96019
            Assert.True(_digital.AccountOwnersHeader.Displayed);
            Assert.True(_digital.AccountOwnersAddAccountOwnerButton.Displayed);
            Assert.True(_digital.AccountOwnersEditPrimaryAccountOwnerButton.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.ExitButton.Displayed);
            Assert.True(_digital.AccountOwnersGoToAccountsButton.Displayed);
        }
        public void Test_96020()
        {
            // Test Case Id: 96020
            Assert.True(_digital.AccountOwnersNameHeader.Displayed);
            Assert.True(_digital.AccountOwnersNameBody.Displayed);
            Assert.True(_digital.AccountOwnersCourtesyTitleField.Displayed);
            Assert.True(_digital.AccountOwnersLegalFirstNameField.Displayed);
            Assert.True(_digital.AccountOwnersLegalMiddleNameField.Displayed);
            Assert.True(_digital.AccountOwnersLegalLastNameField.Displayed);
            Assert.True(_digital.AccountOwnersSuffixField.Displayed);
            Assert.True(_digital.AccountOwnersPreferredFirstNameField.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96021()
        {
            // Test Case Id: 96021
            Assert.True(_digital.AccountOwnersPersonalDetailsHeader.Displayed);
            Assert.True(_digital.AccountOwnersDateOfBirthField.Displayed);
            Assert.True(_digital.AccountOwnersAreYouACitizenYesRadial.Displayed);
            Assert.True(_digital.AccountOwnersAreYouACitizenNoRadial.Displayed);
            Assert.True(_digital.AccountOwnersSocialSecurityNumberField.Displayed);
            Assert.True(_digital.AccountOwnersMaritalStatusField.Displayed);
            Assert.True(_digital.AccountOwnersNumberOfDependentsField.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96022()
        {
            // Test Case Id: 96022
            Assert.True(_digital.AccountOwnersAddressHeader.Displayed);
            Assert.True(_digital.AccountOwnersAddressBody.Displayed);
            Assert.True(_digital.HouseholdDetailsRentField.Displayed);
            Assert.True(_digital.HouseholdDetailsOwnField.Displayed);
            Assert.True(_digital.HouseholdDetailsCountryField.Displayed);
            Assert.True(_digital.HouseholdDetailsAddress1Field.Displayed);
            Assert.True(_digital.HouseholdDetailsAddress2Field.Displayed);
            Assert.True(_digital.HouseholdDetailsStateField.Displayed);
            Assert.True(_digital.HouseholdDetailsCityField.Displayed);
            Assert.True(_digital.HouseholdDetailsPostalCodeField.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96023()
        {
            // Test Case Id: 96023
            Assert.True(_digital.AccountOwnersContactDetailsHeader.Displayed);
            Assert.True(_digital.AccountOwnersPhoneTypeField.Displayed);
            Assert.True(_digital.AccountOwnersAddPhoneButton.Displayed);
            Assert.True(_digital.AccountOwnersCountryCodeField.Displayed);
            Assert.True(_digital.AccountOwnersPhoneNumberField.Displayed);
            Assert.True(_digital.AccountOwnersRequiredEmailAddressField.Displayed);
            Assert.True(_digital.AccountOwnersOptionalEmailAddressField.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96024()
        {
            // Test Case Id: 96024
            Assert.True(_digital.AccountOwnersEmploymentHeader.Displayed);
            Assert.True(_digital.AccountOwnersEmploymentBody.Displayed);
            Assert.True(_digital.AccountOwnersEmploymentField.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }

        // Accounts --------------------------------------------------

        public void Test_96038()
        {
            // Test Case Id: 96038
            Assert.True(_digital.AccountsFirstVisitHeader.Displayed);
            Assert.True(_digital.AddButton.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.ExitButton.Displayed);
        }
        public void Test_96039()
        {
            // Test Case Id: 96039
            Assert.True(_digital.AccountsNumberAndOwnerHeader.Displayed);
            Assert.True(_digital.AccountNumberField.Displayed);
            Assert.True(_digital.AccountFirmField.Displayed);
            Assert.True(_digital.AccountAccountOwnerCheckBox.Displayed);
            Assert.True(_digital.AddButton.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96045()
        {
            // Test Case Id: 96045
            Assert.True(_digital.AccountsTypeHeader.Displayed);
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.SingleOwnerAccountsTypeBody.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96046()
        {
            // Test Case Id: 96046
            Assert.True(_digital.AccountsTypeHeader.Displayed);
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.MultipleOwnersAccountsTypeBody.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }

        // Account Services -------------------------------------------------------------

        public void Test_96075()
        {
            Assert.True(_digital.AccountServicesDebitCardHeader.Displayed);
            Assert.True(_digital.AccountServicesDebitCardBody.Displayed);
            Assert.True(_digital.NoRadial.Displayed);
            Assert.True(_digital.YesRadial.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96079()
        {
            Assert.True(_digital.AccountServicesDebitCardHeader.Displayed);
            Assert.True(_digital.AccountServicesCheckOrderBody.Displayed);
            Assert.True(_digital.NoRadial.Displayed);
            Assert.True(_digital.YesRadial.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96086()
        {
            Assert.True(_digital.AccountServicesCheckOrderHeader.Displayed);
            Assert.True(_digital.AccountServicesOutstandingChecks.Displayed);
            Assert.True(_digital.CheckNameField.Displayed);
            Assert.True(_digital.NoCheckbox.Displayed);
            Assert.True(_digital.YesCheckbox.Displayed);
            Assert.True(_digital.IDontHaveChecksCheckbox.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96103() 
        {
            Assert.True(_digital.AccountServicesSignaturesHeader.Displayed);
            Assert.True(_digital.SignaturesContactMeRadial.Displayed);
            Assert.True(_digital.ChooseFilesToUploadRadial.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96108()
        {
            Assert.True(_digital.AccountServicesConfirmationHeader.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.AElementSaveAndExitButton.Displayed);
            Assert.True(_digital.AElementNextButton.Displayed);
        }
        public void Test_96110()
        {
            Assert.True(_digital.AccountServicesEFTACHHeader.Displayed);
            Assert.True(_digital.AddButton.Displayed);
            Assert.True(_digital.NoExternalBankAccountCheckbox.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96112()
        {
            Assert.True(_digital.AccountServicesAddExternalBankHeader.Displayed);
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.ExternalBankName.Displayed);
            Assert.True(_digital.ExternalBankRoutingNumber.Displayed);
            Assert.True(_digital.ExternalBankAccountNumber.Displayed);
            Assert.True(_digital.ExternalBankConfirmAccountNumber.Displayed);
            Assert.True(_digital.ExternalBankCheckingRadial.Displayed);
            Assert.True(_digital.ExternalBankSavingsRadial.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96113()
        {
            Assert.True(_digital.AccountServicesExternalBankVoidedCheckHeader.Displayed);
            Assert.True(_digital.VoidedCheckChooseFileButton.Displayed);
            Assert.True(_digital.SignaturesContactMeRadial.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96115()
        {
            Assert.True(_digital.AccountServicesExternalBankSuccessHeader.Displayed);
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.ExternalBankVerificationNextButton.Displayed);
        }
        public void Test_96117()
        {
            Assert.True(_digital.AccountServicesTransferBetweenAccountsHeader.Displayed);
            Assert.True(_digital.NoRadial.Displayed);
            Assert.True(_digital.YesRadial.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }

        // Trusted Contacts ------------------------------------------------------------

        public void Test_96121()
        {
            Assert.True(_digital.TrustedContactsHeader.Displayed);
            Assert.True(_digital.TrustedContactsBodyText.Displayed);
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.ExitButton.Displayed);
            Assert.True(_digital.NotAtThisTimeButton.Displayed);
        }

        // Securities Industry & Affiliations ---------------------------------------

        public void Test_96129() 
        {
            Assert.True(_digital.SIAHeader.Displayed);
            Assert.True(_digital.SIABodyText.Displayed);
            Assert.True(_digital.SIACurrentStatus.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.ExitButton.Displayed);
            Assert.True(_digital.GetStartedButton.Displayed);
        }
        public void Test_96130()
        {
            Assert.True(_digital.SIABrokerBodyText.Displayed);
            Assert.True(_digital.SIABrokerHeader.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NoButton.Displayed);
            Assert.True(_digital.YesButton.Displayed);
        }
        public void Test_96130a()
        {
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.SIABrokerHeader.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96131()
        {
            Assert.True(_digital.SIABairdAssociateHeader.Displayed);
            Assert.True(_digital.SIABairdAssociateBodyText.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NoButton.Displayed);
            Assert.True(_digital.YesButton.Displayed);
        }
        public void Test_96131a()
        {
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.SIABairdAssociateHeader.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96132()
        {
            Assert.True(_digital.SIASecuritiesFirmHeader.Displayed);
            Assert.True(_digital.SIASecuritiesFirmBodyText.Displayed);
            Assert.True(_digital.SIASecuritiesFirmBodyText2.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NoButton.Displayed);
            Assert.True(_digital.YesButton.Displayed);
        }
        public void Test_96132a()
        {
            Assert.True(_digital.SIAExchangeHeader.Displayed);
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96133()
        {
            Assert.True(_digital.SIAPubliclyTradedCompanyHeader.Displayed);
            Assert.True(_digital.SIAPubliclyTradedCompanyBodyText.Displayed);
            Assert.True(_digital.SIAPubliclyTradedCompanyBodyText2.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NoButton.Displayed);
            Assert.True(_digital.YesButton.Displayed);
        }
        public void Test_96133a()
        {
            Assert.True(_digital.SIAPubliclyTradedCompanyHeader.Displayed);
            Assert.True(_digital.CheckBox.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }
        public void Test_96134()
        {
            Assert.True(_digital.SIALargeTraderHeader.Displayed);
            Assert.True(_digital.SIALargeTraderBodyText.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.NoButton.Displayed);
            Assert.True(_digital.YesButton.Displayed);
        }
        public void Test_96134a()
        {
            Assert.True(_digital.SIALargeTraderHeader2.Displayed);
            Assert.True(_digital.SIALargeTraderIdField.Displayed);
            Assert.True(_digital.BackButton.Displayed);
            Assert.True(_digital.SaveAndExitButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
        }

        // Additional Information ----------------------------------------------

        public void Test_96161()
        {
            Assert.True(_digital.AdditionalInformationHeader.Displayed);
            Assert.True(_digital.YesButton.Displayed);
            Assert.True(_digital.NoButton.Displayed);
            Assert.True(_digital.BackButton.Displayed);
        }
        public void Test_96162() 
        {
            Assert.True(_digital.AdditionalInformationDetailsHeader.Displayed);
            Assert.True(_digital.ChooseFilesButton.Displayed);
            Assert.True(_digital.NextButton.Displayed);
            Assert.True(_digital.BackButton.Displayed);
        }

        // Summary --------------------------------------------

        public void Test_96163()
        {
            // Test Case Id: 96163
            Assert.True(_digital.SummaryHeader.Displayed);
            Assert.True(_digital.SummaryBodyText.Displayed);
            Assert.True(_digital.SummaryHouseholdDetailsSection.Displayed);
            Assert.True(_digital.SummaryAccountOwnersSection.Displayed);
            Assert.True(_digital.SummaryAccountsSection.Displayed);
            Assert.True(_digital.SummaryAccountServicesSection.Displayed);
            Assert.True(_digital.SummaryTrustedContactsSection.Displayed);
            Assert.True(_digital.SummarySIASection.Displayed);
            Assert.True(_digital.SummaryAdditionalInfoSection.Displayed);
        }

        // Household Progress Bar Not Started
        public void HouseholdProgressBarNotStarted()
        {
            Assert.True(_digital.HouseholdDetailsProgressBarNotStarted.Displayed);
            Assert.True(_digital.AccountOwnersProgressBarNotStarted.Displayed);
            Assert.True(_digital.AccountsProgressBarNotStarted.Displayed);
            Assert.True(_digital.AccountServicesProgressBarNotStarted.Displayed);
            Assert.True(_digital.TrustedContactsProgressBarNotStarted.Displayed);
            Assert.True(_digital.SecuritiesProgressBarNotStarted.Displayed);
            Assert.True(_digital.AdditionalInformationProgressBarNotStarted.Displayed);
            Assert.True(_digital.SummaryProgressBarNotStarted.Displayed);
        }
    }
}