using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Xunit;

namespace SeleniumPOC.PageObjects
{
    public class DigitalOnboarding
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;

        public DigitalOnboarding(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            _driver = driver;
            _wait = wait;
            _actions = actions;
        }


        // Elements

        //---- Cookies
        public IWebElement AcceptCookies => WaitAndFindElement(By.XPath("//button[@id='onetrust-accept-btn-handler'][contains(text(),'Accept All Cookies')]"));

        //---- Universal Elements and Button Ids
        public IWebElement BackButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-primary btn-normal'][contains(text(),'Back')]"));
        public IWebElement SaveAndExitButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-dark btn-normal'][contains(text(),'Exit')]"));
        public IWebElement ExitButton => WaitAndFindElement(By.XPath("//a[@class='btn btn-dark btn-normal'][contains(text(),'Exit')]"));
        public IWebElement CloseButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-dark btn-normal'][contains(text(),'Close')]"));
        public IWebElement NextButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'Next')]"));
        public IWebElement NoButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-dark btn-normal'][contains(text(),'No')]"));
        public IWebElement YesButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'Yes')]"));
        public IWebElement AddButton => WaitAndFindElement(By.XPath("//div[@class='bi-hover-normal']"));
        public IWebElement CheckBox => WaitAndFindElement(By.XPath("//input[@class='checkbox']"));
        public IWebElement LetsGetStartedButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'s get started')]"));
        public IWebElement LetsResumeButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'s resume')]"));
        public IWebElement LetsMoveOnButton => WaitAndFindElement(By.XPath("//a[@class='btn btn-success btn-normal'][contains(text(),'s move on')]"));
        public IWebElement SaveButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'Save')]"));
        public IWebElement SubmitButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'Submit')]"));
        public IWebElement PageFooter => WaitAndFindElement(By.XPath("//p[@class='text-center small-text pt-2 text-dark']"));
        public IWebElement SubmitCompleted => WaitAndFindElement(By.XPath("//a[@href='/summary']/div/div[@class='text-success text-start']"));
        public IWebElement SubmitInProgress => WaitAndFindElement(By.XPath("//a[@href='/summary']/div/div[@class='text-warning text-start']"));
        public IWebElement YesRadial => WaitAndFindElement(By.XPath("//input[@id='true']"));
        public IWebElement NoRadial => WaitAndFindElement(By.XPath("//input[@id='false']"));
        public IWebElement OkButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'Ok')]"));
        public IWebElement CheckBox2 => WaitAndFindElement(By.XPath("(//input[@class='checkbox'])[2]"));
        public IWebElement ChooseFilesButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-primary btn-normal'][contains(text(),'Choose Files')]"));
        public IWebElement NotAtThisTimeButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'Not at this time')]"));
        public IWebElement FileUploadError => WaitAndFindElement(By.XPath("//h2[contains(text(),'File selected is not a valid file type')]"));
        public IWebElement FileUploadTestFile => WaitAndFindElement(By.XPath("//h5[contains(text(),'TestFile')]"));

        //---- D.O. Landing Progress Bar and Welcome ---------------------------------------
        public IWebElement HouseholdDetailsProgressBar => WaitAndFindElement(By.XPath("//a[@href='/household-details']"));
        public IWebElement AccountOwnersProgressBar => WaitAndFindElement(By.XPath("//a[@href='/account-owners']"));
        public IWebElement AccountsProgressBar => WaitAndFindElement(By.XPath("//a[@href='/accounts']"));
        public IWebElement AccountServicesProgressBar => WaitAndFindElement(By.XPath("//a[@href='/account-services']"));
        public IWebElement TrustedContactsProgressBar => WaitAndFindElement(By.XPath("//a[@href='/trusted-contacts']"));
        public IWebElement SecuritiesProgressBar => WaitAndFindElement(By.XPath("//a[@href='/securities']"));
        public IWebElement AdditionalInformationProgressBar => WaitAndFindElement(By.XPath("//a[@href='/additional-information']"));
        public IWebElement SummaryProgressBar => WaitAndFindElement(By.XPath("//a[@href='/summary']"));
        public IWebElement WelcomeLetsContinueButton => WaitAndFindElement(By.XPath("//button[contains(text(),\"Let's Continue\")]"));
        public IWebElement WelcomeScreenWelcomeHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Welcome')]"));
        public IWebElement WelcomeScreenImReadyToGetStartedButton => WaitAndFindElement(By.XPath("//a[@href='/household-details'][contains(text(),'ready to get started')]"));
        public IWebElement HouseholdDetailsProgressBarNotStarted => WaitAndFindElement(By.XPath("(//div[contains(text(),'Not Started')])[1]"));
        public IWebElement AccountOwnersProgressBarNotStarted => WaitAndFindElement(By.XPath("(//div[contains(text(),'Not Started')])[2]"));
        public IWebElement AccountsProgressBarNotStarted => WaitAndFindElement(By.XPath("(//div[contains(text(),'Not Started')])[3]"));
        public IWebElement AccountServicesProgressBarNotStarted => WaitAndFindElement(By.XPath("(//div[contains(text(),'Not Started')])[4]"));
        public IWebElement TrustedContactsProgressBarNotStarted => WaitAndFindElement(By.XPath("(//div[contains(text(),'Not Started')])[5]"));
        public IWebElement SecuritiesProgressBarNotStarted => WaitAndFindElement(By.XPath("(//div[contains(text(),'Not Started')])[6]"));
        public IWebElement AdditionalInformationProgressBarNotStarted => WaitAndFindElement(By.XPath("(//div[contains(text(),'Not Started')])[7]"));
        public IWebElement SummaryProgressBarNotStarted => WaitAndFindElement(By.XPath("(//div[contains(text(),'Not Started')])[8]"));

        //---- D.O. Household Details ---------------------------------------
        public IWebElement HouseholdDetailsScreenGetStartedButton => WaitAndFindElement(By.XPath("//a[@href='/household-details/addresses']"));
        public IWebElement HouseholdDetailsCountryField => WaitAndFindElement(By.XPath("//select[@id='countryId']"));
        public IWebElement HouseholdDetailsStateField => WaitAndFindElement(By.XPath("//select[@id='stateId']"));
        public IWebElement HouseholdDetailsAddress1Field => WaitAndFindElement(By.XPath("//input[@id='address1']"));
        public IWebElement HouseholdDetailsAddressesHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'s Legal Address?')]"));
        public IWebElement HouseholdDetailsAddress2Field => WaitAndFindElement(By.XPath("//input[@id='address2']"));
        public IWebElement HouseholdDetailsCityField => WaitAndFindElement(By.XPath("//input[@id='city']"));
        public IWebElement HouseholdDetailsPostalCodeField => WaitAndFindElement(By.XPath("//input[@id='postalCode']"));
        public IWebElement HouseholdDetailsOwnField => WaitAndFindElement(By.XPath("//input[@id='own']"));
        public IWebElement HouseholdDetailsRentField => WaitAndFindElement(By.XPath("//input[@id='rent']"));
        public IWebElement HouseholdDetailsCommunicationPreferenceField => WaitAndFindElement(By.XPath("//input[@id='householdName']"));
        public IWebElement HouseholdDetailsFinancialSummaryAnnualHouseholdIncomeField => WaitAndFindElement(By.XPath("//select[@id='annualIncome']"));
        public IWebElement HouseholdDetailsFinancialSummaryHouseholdNetWorthField => WaitAndFindElement(By.XPath("//select[@id='netWorth']"));
        public IWebElement HouseholdDetailsFinancialSummaryInvestableAssetsField => WaitAndFindElement(By.XPath("//select[@id='otherInvestableAssets']"));
        public IWebElement HouseholdDetailsFinancialSummaryTaxBracketField => WaitAndFindElement(By.XPath("//select[@id='taxBracket']"));
        public IWebElement HouseholdDetailsInvestmentExperienceStocksSlider => WaitAndFindElement(By.XPath("//input[@id='stocks']"));
        public IWebElement HouseholdDetailsInvestmentExperienceBondsSlider => WaitAndFindElement(By.XPath("//input[@id='bonds']"));
        public IWebElement HouseholdDetailsInvestmentExperienceMutualFundsSlider => WaitAndFindElement(By.XPath("//input[@id='mutualFunds']"));
        public IWebElement HouseholdDetailsInvestmentExperienceOptionsSlider => WaitAndFindElement(By.XPath("//input[@id='options']"));
        public IWebElement HouseholdDetailsInvestmentExperienceAnnuitiesLifeInsuranceSlider => WaitAndFindElement(By.XPath("//input[@id='annuitiesLifeInsurance']"));
        public IWebElement HouseholdDetailsAccountStatementsChooseFilesButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-primary btn-normal'][contains(text(),'Choose Files')]"));
        public IWebElement FileUpload => WaitAndFindElement(By.XPath("//input[@type='file']"));
        public IWebElement HouseholdDetailsScreenMoveOnButton => WaitAndFindElement(By.XPath("//a[@href='/account-owners'][contains(text(),'move on')]"));
        public IWebElement HouseholdDetailsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Household Details')]"));
        public IWebElement HouseholdDetailsBodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'confirm information for your household that your Financial Advisor(s) will use to communicate with you and provide the best advice and service.')]"));
        public IWebElement HouseholdDetailsCurrentStatus => WaitAndFindElement(By.XPath("//h2[contains(text(),'Current Status of Household Details')]"));
        public IWebElement HouseholdDetailsReviewAnswersLink => WaitAndFindElement(By.XPath("//a[@href='/household-details/addresses']"));
        public IWebElement HouseholdDetailsRentOrOwn => WaitAndFindElement(By.XPath("//label[contains(text(),'Do you Own or Rent?')]"));
        public IWebElement HouseholdDetailsSeparateMailingAddressHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Do you have a separate mailing address')]"));
        public IWebElement HouseholdDetailsCommunicationPreferenceHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'How should we address your household?')]"));
        public IWebElement HouseholdDetailsCommunicationPreferenceDescription => WaitAndFindElement(By.XPath("//label[contains(text(),'How would you like us to address your household in mailing communications?')]"));
        public IWebElement HouseholdDetailsFinancialDetailsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Tell us more about your household financial details')]"));
        public IWebElement HouseholdDetailsInvestmentExperienceHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Tell us about your household investment experience')]"));
        public IWebElement HouseholdDetailsInvestmentExperienceBody => WaitAndFindElement(By.XPath("//p[contains(text(),'Please tell us how many years of combined experience you, and other household members (where applicable), have with each of the following types of investments below.')]"));
        public IWebElement HouseholdDetailsAccountStatementsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Please provide statements for every account you will be transferring to Baird')]"));
        public IWebElement HouseholdDetailsAccountStatementsBody => WaitAndFindElement(By.XPath("//p[contains(text(),'Statements include a full ')]"));
        public IWebElement HouseholdDetailsAccountStatementsFileDescription => WaitAndFindElement(By.XPath("//span[contains(text(),'Choose a file to upload, max size 16MB per file')]"));

        //---- D.O. Account Owners ---------------------------------------
        public IWebElement AccountOwnersSideNavigation => WaitAndFindElement(By.XPath("(//a[@href='/account-owners'])[2]"));
        public IWebElement AccountOwnersAddAccountOwnerButton => WaitAndFindElement(By.XPath("//div[@class='bi-hover-normal']"));
        public IWebElement AccountOwnersEditPrimaryAccountOwnerButton => WaitAndFindElement(By.XPath("//a[@href='/account-owners/1/name']"));
        public IWebElement AccountOwnersEditPrimaryAccountOwnerSummary => WaitAndFindElement(By.XPath("//a[@href='/account-owners/1/summary']"));
        public IWebElement AccountOwnersCourtesyTitleField => WaitAndFindElement(By.XPath("//select[@id='name.courtesyTitleId']"));
        public IWebElement AccountOwnersLegalFirstNameField => WaitAndFindElement(By.XPath("//input[@id='name.legalFirstName']"));
        public IWebElement AccountOwnersLegalMiddleNameField => WaitAndFindElement(By.XPath("//input[@id='name.legalMiddleName']"));
        public IWebElement AccountOwnersLegalLastNameField => WaitAndFindElement(By.XPath("//input[@id='name.legalLastName']"));
        public IWebElement AccountOwnersSuffixField => WaitAndFindElement(By.XPath("//select[@id='name.suffixId']"));
        public IWebElement AccountOwnersPreferredFirstNameField => WaitAndFindElement(By.XPath("//input[@id='name.preferredFirstName']"));
        public IWebElement AccountOwnersDateOfBirthField => WaitAndFindElement(By.XPath("//input[@id='personalDetails.dob']"));
        public IWebElement AccountOwnersSocialSecurityNumberField => WaitAndFindElement(By.XPath("//input[@id='personalDetails.taxId']"));
        public IWebElement AccountOwnersAreYouACitizenYesRadial => WaitAndFindElement(By.XPath("//input[@id='true']"));
        public IWebElement AccountOwnersAreYouACitizenNoRadial => WaitAndFindElement(By.XPath("//input[@id='false']"));
        public IWebElement AccountOwnersMaritalStatusField => WaitAndFindElement(By.XPath("//select[@name='personalDetails.maritalStatusId']"));
        public IWebElement AccountOwnersNumberOfDependentsField => WaitAndFindElement(By.XPath("//input[@name='personalDetails.numberOfDependents']"));
        public IWebElement AccountOwnersAddPhoneButton => WaitAndFindElement(By.XPath("//div[@class='bi-hover-normal']"));
        public IWebElement AccountOwnersRequiredEmailAddressField => WaitAndFindElement(By.XPath("//input[@id='contactDetails.emailAddresses.0.email']"));
        public IWebElement AccountOwnersOptionalEmailAddressField => WaitAndFindElement(By.XPath("//input[@id='contactDetails.emailAddresses.1.email']"));
        public IWebElement AccountOwnersGoToAccountsButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'Go To Accounts')]"));
        public IWebElement AccountOwnersFirstExistingAddressRadial => WaitAndFindElement(By.XPath("//input[@id='0']"));
        public IWebElement AccountOwnersOtherAddressRadial => WaitAndFindElement(By.XPath("//input[@id='other']"));
        public IWebElement AccountOwnersSelfEmployedNameOfBusiness => WaitAndFindElement(By.XPath("//input[@id='employment.businessDetails.name']"));
        public IWebElement AccountOwnersSelfEmployedNatureOfBusiness => WaitAndFindElement(By.XPath("//input[@id='employment.businessDetails.natureOfBusiness']"));
        public IWebElement AccountOwnersSelfEmployedYearsInBusiness => WaitAndFindElement(By.XPath("//input[@id='employment.businessDetails.yearsInBusiness']"));
        public IWebElement AccountOwnersEmploymentOccupation => WaitAndFindElement(By.XPath("//input[@id='employment.employer.occupation']"));
        public IWebElement AccountOwnersEmploymentYearsEmployed => WaitAndFindElement(By.XPath("//input[@id='employment.employer.yearsEmployed']"));
        public IWebElement AccountOwnersEmploymentEmployerName => WaitAndFindElement(By.XPath("//input[@id='employment.employer.employerName']"));
        public IWebElement AccountOwnersEmploymentNatureOfBusiness => WaitAndFindElement(By.XPath("//input[@id='employment.employer.natureOfBusiness']"));
        public IWebElement AccountOwnersEmployerAddress => WaitAndFindElement(By.XPath("//input[@id='employment.employer.address1']"));
        public IWebElement AccountOwnersEmployerAddress2 => WaitAndFindElement(By.XPath("//input[@id='employment.employer.address2']"));
        public IWebElement AccountOwnersEmployerCity => WaitAndFindElement(By.XPath("//input[@id='employment.employer.city']"));
        public IWebElement AccountOwnersEmployerPostalCode => WaitAndFindElement(By.XPath("//input[@id='employment.employer.postalCode']"));
        public IWebElement AccountOwnersHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'All Account Owners')]"));
        public IWebElement AccountOwnersNameHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'s start by getting more information about')]"));
        public IWebElement AccountOwnersNameBody => WaitAndFindElement(By.XPath("//p[contains(text(),'Note: some information has already been provided by your Financial Advisor, please confirm the information is accurate or update as applicable.')]"));
        public IWebElement AccountOwnersPersonalDetailsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Tell us more about')]"));
        public IWebElement AccountOwnersAddressHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Where do you live?')]"));
        public IWebElement AccountOwnersAddressBody => WaitAndFindElement(By.XPath("//label[contains(text(),'Do you Own or Rent?')]"));
        public IWebElement AccountOwnersContactDetailsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Please provide ')]"));
        public IWebElement AccountOwnersPhoneTypeField => WaitAndFindElement(By.XPath("//select[@name='contactDetails.phoneDetails.0.phoneTypeId']"));
        public IWebElement AccountOwnersCountryCodeField => WaitAndFindElement(By.XPath("//select[@name='contactDetails.phoneDetails.0.phoneCountryCodeId']"));
        public IWebElement AccountOwnersPhoneNumberField => WaitAndFindElement(By.XPath("//input[@name='contactDetails.phoneDetails.0.phoneNumber']"));
        public IWebElement AccountOwnersEmploymentHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'What is your employment status?')]"));
        public IWebElement AccountOwnersEmploymentBody => WaitAndFindElement(By.XPath("//label[contains(text(),'Employment Status')]"));
        public IWebElement AccountOwnersEmploymentField => WaitAndFindElement(By.XPath("//select[@name='employmentStatusId']"));

        
        //---- D.O. Accounts ---------------------------------------------
        public IWebElement AccountsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'New Baird Accounts')]"));
        public IWebElement AccountsFirstVisitHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'s gather information about your account(s)')]"));
        public IWebElement AccountsNumberAndOwnerHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Account Number & Owners')]"));
        public IWebElement AccountsTypeHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'s confirm what type of account this is.')]"));
        public IWebElement SingleOwnerAccountsTypeBody => WaitAndFindElement(By.XPath("//p[contains(text(),'The most common types of single-owner accounts are Individual and IRAs.')]"));
        public IWebElement MultipleOwnersAccountsTypeBody => WaitAndFindElement(By.XPath("//p[contains(text(),'The most common type of multiple owner account is a Joint account,')]"));
        public IWebElement AccountsSideNavigation => WaitAndFindElement(By.XPath("(//a[@href='/accounts'])[2]"));
        public IWebElement AccountNumberField => WaitAndFindElement(By.XPath("//input[@id='accountNumber']"));
        public IWebElement EmptyAccountNumberField => WaitAndFindElement(By.XPath("//input[@id='accountNumber'][@value='']"));
        public IWebElement AccountFirmField => WaitAndFindElement(By.XPath("//select[@id='transferringFrom']"));
        public IWebElement AccountAccountOwnerCheckBox => WaitAndFindElement(By.XPath("(//input[@class='checkbox'])[1]"));
        public IWebElement NotTransferringAccountsCheckbox => WaitAndFindElement(By.XPath("//input[@id='isNewAccount']"));
        public IWebElement YesTransferOnDeathRadial => WaitAndFindElement(By.XPath("//input[@id='isTransferOnDeath-true']"));
        public IWebElement NoTransferOnDeathRadial => WaitAndFindElement(By.XPath("//input[@id='isTransferOnDeath-false']"));
        public IWebElement YesUseMarginRadial => WaitAndFindElement(By.XPath("//input[@id='useMargin-true']"));
        public IWebElement NoUseMarginRadial => WaitAndFindElement(By.XPath("//input[@id='useMargin-false']"));
        public IWebElement AccountsGoToAccountServicesButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal'][contains(text(),'Go to Account Services')]"));
        public IWebElement BeneficiariesOptOutCheckbox => WaitAndFindElement(By.XPath("//input[@id='optOut']"));
        public IWebElement AddPrimaryBeneficiaryButton => WaitAndFindElement(By.XPath("(//button[@class='btn btn-success btn-normal'][contains(text(),'Add ')])[1]"));
        public IWebElement AddContingentBeneficiaryButton => WaitAndFindElement(By.XPath("(//button[@class='btn btn-success btn-normal'][contains(text(),'Add ')])[2]"));
        public IWebElement BeneficiaryFullNameField => WaitAndFindElement(By.XPath("//input[@id='name']"));
        public IWebElement BeneficiaryDateOfBirthField => WaitAndFindElement(By.XPath("//input[@id='dateOfBirth']"));
        public IWebElement BeneficiaryTaxIDField => WaitAndFindElement(By.XPath("//input[@id='taxId']"));
        public IWebElement BeneficiaryContactField => WaitAndFindElement(By.XPath("//input[@id='contact']"));
        public IWebElement BeneficiaryTrustTaxIdIdentificationRadial => WaitAndFindElement(By.XPath("//input[@id='taxId'][@type='radio']"));
        public IWebElement BeneficiaryTrustSSNIdentificationRadial => WaitAndFindElement(By.XPath("//input[@id='ssn'][@type='radio']"));
        public IWebElement BeneficiaryTrustDateOfTrust => WaitAndFindElement(By.XPath("//input[@id='dateOfTrust']"));
        public IWebElement CorporationNameCorporateAccount => WaitAndFindElement(By.XPath("//input[@name='entityName']"));
        public IWebElement CorporationNameCorporateTaxId => WaitAndFindElement(By.XPath("//input[@id='entityTIN']"));
        public IWebElement TrustNameField => WaitAndFindElement(By.XPath("//input[@id='nameOfTrust']"));
        public IWebElement TrustCreatedDateField => WaitAndFindElement(By.XPath("//input[@id='createdDate']"));
        public IWebElement TrustTINField => WaitAndFindElement(By.XPath("//input[@id='identificationNumber']"));
        public IWebElement TrusteeYesRadial => WaitAndFindElement(By.XPath("//input[@id='yes']"));
        public IWebElement TrusteeNoRadial => WaitAndFindElement(By.XPath("//input[@id='no']"));
        public IWebElement GrantorNameField => WaitAndFindElement(By.XPath("//input[@id='grantorsNames']"));
        public IWebElement SuccessorTrusteeNameField => WaitAndFindElement(By.XPath("//input[@id='successorTrusteesNames']"));
        public IWebElement ROTHTitleYesRadial => WaitAndFindElement(By.XPath("//input[@id='isRothInTitle-true']"));
        public IWebElement ROTHTitleNoRadial => WaitAndFindElement(By.XPath("//input[@id='isRothInTitle-false']"));
        public IWebElement OriginalHolderDateOfDeath => WaitAndFindElement(By.XPath("//input[@id='originalHolderDateOfDeath']"));
        public IWebElement OriginalHolderDateOfBirth => WaitAndFindElement(By.XPath("//input[@id='originalHolderDateOfBirth']"));
        public IWebElement OriginalHolderName => WaitAndFindElement(By.XPath("//input[@id='originalHolderName']"));
        public IWebElement BenefitOwnerUnborn => WaitAndFindElement(By.XPath("//input[@id='isUnborn']"));
        public IWebElement IRAWithdrawalYesRadial => WaitAndFindElement(By.XPath("//input[@id='isWithdrawingMoney-yes']"));
        public IWebElement IRAWithdrawalNoRadial => WaitAndFindElement(By.XPath("//input[@id='isWithdrawingMoney-no']"));
        public IWebElement PercentageTaxWithholding => WaitAndFindElement(By.XPath("//input[@id='percentage']"));
        public IWebElement DollarTaxWithholding => WaitAndFindElement(By.XPath("//input[@id='dollar']"));
        public IWebElement FederalTaxWithholding => WaitAndFindElement(By.XPath("//input[@id='federalTaxWithholding']"));
        public IWebElement StateTaxWithholding => WaitAndFindElement(By.XPath("//input[@id='stateTaxWithholding']"));
        public IWebElement AccountOwnerSelectionValidation => WaitAndFindElement(By.XPath("//div[contains(text(),'Who is listed first on the account statement? is required')]"));
        public IWebElement AccountNumberValidation => WaitAndFindElement(By.XPath("//div[contains(text(),'Account Number is required')]"));

        //---- D.O. Account Services
        public IWebElement AccountServicesHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Your accounts allow you to sign up for various money management services.')]"));
        public IWebElement AccountServicesSideNavigation => WaitAndFindElement(By.XPath("(//a[@href='/account-services'])[2]"));
        public IWebElement NoExternalBankAccountCheckbox => WaitAndFindElement(By.XPath("//input[@id='noExternalAccounts']"));
        public IWebElement CheckNameField => WaitAndFindElement(By.XPath("//input[@id='nameListCheck.0']"));
        public IWebElement NoCheckbox => WaitAndFindElement(By.XPath("//input[@id='no']"));
        public IWebElement YesCheckbox => WaitAndFindElement(By.XPath("//input[@id='yes']"));
        public IWebElement IDontHaveChecksCheckbox => WaitAndFindElement(By.XPath("//input[@id='noCurrentChecks']"));
        public IWebElement SignaturesContactMeRadial => WaitAndFindElement(By.XPath("//input[@id='skip']"));
        public IWebElement ChooseFilesToUploadRadial => WaitAndFindElement(By.XPath("//input[@id='files']"));
        public IWebElement ExternalBankName => WaitAndFindElement(By.XPath("//input[@id='bankName']"));
        public IWebElement ExternalBankRoutingNumber => WaitAndFindElement(By.XPath("//input[@id='routingNum']"));
        public IWebElement ExternalBankAccountNumber => WaitAndFindElement(By.XPath("//input[@id='accountNumber']"));
        public IWebElement ExternalBankConfirmAccountNumber => WaitAndFindElement(By.XPath("//input[@id='confirmAccountNumber']"));
        public IWebElement ExternalBankCheckingRadial => WaitAndFindElement(By.XPath("//input[@id='checking']"));
        public IWebElement ExternalBankSavingsRadial => WaitAndFindElement(By.XPath("//input[@id='savings']"));
        public IWebElement ExternalBankVerificationNextButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-success btn-normal btn btn-success btn-normal'][contains(text(),'Next')]"));
        public IWebElement AccountServicesCurrentStatus => WaitAndFindElement(By.XPath("//h2[contains(text(),'Current Status of Account Services')]"));
        public IWebElement AccountServicesReviewAnswersLink => WaitAndFindElement(By.XPath("//a[@href='/account-services/debit-card-check-writing/debit-card']"));
        public IWebElement AccountServicesDebitCardHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Debit Card & Check Writing')]"));
        public IWebElement AccountServicesDebitCardBody => WaitAndFindElement(By.XPath("//label[contains(text(),'Would you like a debit card for your qualifying accounts at Baird?')]"));
        public IWebElement AccountServicesCheckOrderBody => WaitAndFindElement(By.XPath("//label[contains(text(),'Great! Debit cards include a free order of checks. Would you like an order of checks for any of your eligible accounts at Baird?')]"));
        public IWebElement AElementNextButton => WaitAndFindElement(By.XPath("//a[@class='btn btn-success btn-normal'][contains(text(),'Next')]"));
        public IWebElement AElementSaveAndExitButton => WaitAndFindElement(By.XPath("//a[@class='btn btn-dark btn-normal'][contains(text(),'Exit')]"));
        public IWebElement DebitChecksRequestedScreenHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'set up your qualifying accounts for debit card and check writing. Please note that checks will arrive in a dark green envelope to your mailing address approximately two weeks after Baird has processed all signatures.')]"));
        public IWebElement AccountServicesOutstandingChecks => WaitAndFindElement(By.XPath("//label[contains(text(),'Do you have any outstanding checks from the account(s) you are transferring?')]"));
        public IWebElement AccountServicesCheckOrderHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'s get some information for your new checks')]"));
        public IWebElement AccountServicesSignaturesHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'In order to set up check writing, Baird will need a copy of the signature of each applicable owner.')]"));
        public IWebElement AccountServicesConfirmationHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'check writing. Please note that checks will arrive in a dark green envelope to your mailing address approximately two weeks after Baird has processed all signatures.')]"));
        public IWebElement AccountServicesEFTACHHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Link your external bank account(s)')]"));
        public IWebElement AccountServicesAddExternalBankHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Please enter your bank details')]"));
        public IWebElement AccountServicesExternalBankVoidedCheckHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'There was a problem verifying your')]"));
        public IWebElement VoidedCheckChooseFileButton => WaitAndFindElement(By.XPath("//input[@type='file']"));
        public IWebElement AccountServicesExternalBankSuccessHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'The ')]"));
        public IWebElement AccountServicesTransferBetweenAccountsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Transfer Between Your Baird Accounts')]"));

        //---- D.O. Trusted Contacts
        public IWebElement TrustedContactsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Trusted Contacts')]"));
        public IWebElement TrustedContactsSideNavigation => WaitAndFindElement(By.XPath("(//a[@href='/trusted-contacts'])[2]"));
        public IWebElement TrustedContactsFullNameField => WaitAndFindElement(By.XPath("//input[@id='trustedContactsFullName']"));
        public IWebElement TrustedContactsEmailField => WaitAndFindElement(By.XPath("//input[@id='emailAddress']"));
        public IWebElement TrustedContactsPhoneNumberField => WaitAndFindElement(By.XPath("//input[@id='phoneNumber']"));
        public IWebElement TrustedContactsBodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'A Trusted Contact is a person, named by an account owner, who Baird is authorized to contact only when issues occur regarding a client’s current contact information, health status, whereabouts, or in the event Baird has a reasonable belief that the client may be a victim of fraud or exploitation. Financial information is not shared with trusted contacts. In addition, it is recommended that the Trusted Contact should NOT be a spouse or significant other living in the same household.')]"));

        //---- D.O. Securities Industry & Affiliations
        public IWebElement SIAHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Securities Industry and Other Affiliations')]"));
        public IWebElement SIASideNavigation => WaitAndFindElement(By.XPath("(//a[@href='/securities'])[2]"));
        public IWebElement GetStartedButton => WaitAndFindElement(By.XPath("//a[@class='btn btn-success btn-normal'][contains(text(),'s get started')]"));
        public IWebElement SIACurrentStatus => WaitAndFindElement(By.XPath("//h2[contains(text(),'Current Status of Securities Industry & Affiliations')]"));
        public IWebElement SIAReviewAnswersLink => WaitAndFindElement(By.XPath("//a[@href='/securities/broker-dealer']"));
        public IWebElement SIABodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'When we open accounts for you, Baird is required to confirm whether you, other account owners or family members of account owners have certain securities industry related affiliations. In this section')]"));
        public IWebElement SIABrokerHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Broker Dealer')]"));
        public IWebElement SIABrokerBodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'Are you or any other account owners listed employed by a broker dealer?')]"));
        public IWebElement SIABairdAssociateHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Baird Associate')]"));
        public IWebElement SIABairdAssociateBodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'Are any accounts owners, their family members or dependents employed by Baird (this includes wholly owned affiliates)?')]"));
        public IWebElement SIASecuritiesFirmHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Securities Firm/Exchange')]"));
        public IWebElement SIAExchangeHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Exchange')]"));
        public IWebElement SIASecuritiesFirmBodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'Is any account owner, or any immediate family of an account owner, employed by or affiliated with one of the following:')]"));
        public IWebElement SIASecuritiesFirmBodyText2 => WaitAndFindElement(By.XPath("//p[contains(text(),'For this question, securities regulatory authority includes: any federal or state regulatory authority, such as the SEC, or any self-regulatory organization, such as FINRA.')]"));
        public IWebElement SIAPubliclyTradedCompanyHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Publicly Traded Company')]"));
        public IWebElement SIAPubliclyTradedCompanyBodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'Is any account owner, their spouse/domestic partner, or any immediate family members an officer, director or 10% (or more) shareholder in a publicly traded company?')]"));
        public IWebElement SIAPubliclyTradedCompanyBodyText2 => WaitAndFindElement(By.XPath("//p[contains(text(),'A person is presumed to control a company if the person directly or indirectly owns 10% or more of the voting stock of the company. If a person is a director or executive officer of a company, the person is also presumed to control the company.')]"));
        public IWebElement SIALargeTraderHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Are you or any other account owner considered a')]"));
        public IWebElement SIALargeTraderBodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'Note: If you are, the SEC would have issued you a large trader ID. This is rare')]"));
        public IWebElement SIALargeTraderHeader2 => WaitAndFindElement(By.XPath("//h1[contains(text(),'Please indicate which account owners are considered a Large Trader and provide their Large Trader ID.')]"));
        public IWebElement SIALargeTraderIdField => WaitAndFindElement(By.XPath("//input[@id='accountOwners.0.largeTraderId']"));

        //---- D.O. AdditionalInformation
        public IWebElement AdditionalInformationCommentField => WaitAndFindElement(By.XPath("//textarea[@id='note']"));
        public IWebElement AdditionalInformationHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Are there any other documents you want to upload or comments you want to leave for your Financial Advisor?')]"));
        public IWebElement AdditionalInformationSideNavigation => WaitAndFindElement(By.XPath("//a[@href='/additional-information']"));
        public IWebElement AdditionalInformationDetailsHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'Additional Information')]"));

        //---- D.O. Summary
        public IWebElement SubmitWithoutStatementsButton => WaitAndFindElement(By.XPath("//button[@class='btn btn-primary btn-normal'][contains(text(),'Submit Without Statements')]"));
        public IWebElement SummarySideNavigation => WaitAndFindElement(By.XPath("(//a[@href='/summary'])[2]"));
        public IWebElement SummaryHeader => WaitAndFindElement(By.XPath("//h1[contains(text(),'take one last look now...')]"));
        public IWebElement SummaryBodyText => WaitAndFindElement(By.XPath("//p[contains(text(),'Please review the information you have provided to ensure it is complete and accurate.')]"));
        public IWebElement SummaryHouseholdDetailsSection => WaitAndFindElement(By.XPath("(//h3[contains(text(),'Household Details')])[2]"));
        public IWebElement SummaryAccountOwnersSection => WaitAndFindElement(By.XPath("(//h3[contains(text(),'Account Owners')])[2]"));
        public IWebElement SummaryAccountOwner => WaitAndFindElement(By.XPath("//b[contains(text(),'Testy McTesterson')]"));
        public IWebElement SummaryAccountsSection => WaitAndFindElement(By.XPath("(//h3[contains(text(),'Accounts')])[2]"));
        public IWebElement SummaryAccount => WaitAndFindElement(By.XPath("//b[contains(text(),'6547-6546')]"));
        public IWebElement SummaryAccountServicesSection => WaitAndFindElement(By.XPath("(//h3[contains(text(),'Account Services')])[2]"));
        public IWebElement SummaryTrustedContactsSection => WaitAndFindElement(By.XPath("(//h3[contains(text(),'Trusted Contacts')])[2]"));
        public IWebElement SummarySIASection => WaitAndFindElement(By.XPath("(//h3[contains(text(),'Securities Industry & Affiliations')])[2]"));
        public IWebElement SummaryAdditionalInfoSection => WaitAndFindElement(By.XPath("(//h3[contains(text(),'Additional Information')])[2]"));
        public IWebElement AccountsAdminLink => WaitAndFindElement(By.XPath("//button[@class='d-print-none text-decoration-underline btn btn-link btn-link-primary btn-normal'][contains(text(),'Admin')]"));
        public IWebElement AdminExternalAccountsCheckbox1 => WaitAndFindElement(By.XPath("(//label[contains(text(),'The Vault')]/..//input)[1]"));
        public IWebElement AdminExternalAccountsCheckbox2 => WaitAndFindElement(By.XPath("(//label[contains(text(),'The Vault')]/..//input)[2]"));
        public IWebElement AdminExternalAccountsCheckbox3 => WaitAndFindElement(By.XPath("(//label[contains(text(),'The Vault')]/..//input)[3]"));


        // Private Helpers
        private IWebElement WaitAndFindElement(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }


        // Selectors
        public void StateSelectorByAbbreviation(string state = "il")
        {
            var locator = "//select[@id='stateId']/option[@value='" + state.ToLower()+"']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void EmployerStateSelectorByAbbreviation(string state = "il")
        {
            var locator = "//select[@id='employment.employer.stateId']/option[@value='" + state.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void TrustStateSelectorByAbbreviation(string state = "il")
        {
            var locator = "//select[@id='stateCreatedIn']/option[@value='" + state.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void CountrySelectorByAbbreviation(string country = "us")
        {
            var locator = "//option[@value='" + country.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void AnnualHouseholdIncomeSelector(string income = "over125k") //value list: under25k, over25k, over40k, over50k, over65k, over125k, over500k, over1000k, na
        {
            var locator = "//select[@name='annualIncome']/option[@value='" + income.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void HouseholdNetWorthSelector(string netWorth = "over200k") //value list: under10k, over10k, over25k, over50k, over200k, over500k, over1000k, over5000k, na
        {
            var locator = "//select[@name='netWorth']/option[@value='" + netWorth.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void OtherInvestableAssetsSelector(string otherInvestableAssets = "over50k") //value list: under10k, over10k, over25k, over50k, over200k, over500k, na
        {
            var locator = "//select[@name='otherInvestableAssets']/option[@value='" + otherInvestableAssets.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void TaxBracketSelector(string taxBracket = "22") //value list: 0, 10, 12, 22, 24, 32, 35, 37
        {
            var locator = "//select[@name='taxBracket']/option[@value='" + taxBracket.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void AccountOwnerMaritalStatusSelector(string maritalStatus = "single") //value list: married, single, divorced, widowed, domestic-partner
        {
            var locator = "//select[@name='personalDetails.maritalStatusId']/option[@value='" + maritalStatus.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void SelectAccountOwnerToEdit(int owner = 1) 
        {
            var locator = "//a[@href='/account-owners/" + owner + "/name']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void PhoneTypeSelector(string phone = "0", string phoneType = "business") //value list: 3 phones allowed: 0, 1, 2  -- phoneTypes: business, home, mobile
        {
            var locatorType = "//select[@id='contactDetails.phoneDetails." + phone + ".phoneTypeId']/option[@value='" + phoneType.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locatorType}")).Click();
        }
        public void PhoneCountryCodeSelector(string phone = "0", string countryCode = "ca")
        {
            var locatorCode = "//select[@id='contactDetails.phoneDetails." + phone + ".phoneCountryCodeId']/option[@value='" + countryCode.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locatorCode}")).Click();
        }
        public void EnterPhoneNumberByPhone(string phone = "0", string phoneNumber = "6248675309")
        {
            var locatorPhone = "//input[@id='contactDetails.phoneDetails." + phone + ".phoneNumber']";
            WaitAndFindElement(By.XPath($"{locatorPhone}")).Clear();
            WaitAndFindElement(By.XPath($"{locatorPhone}")).SendKeys(phoneNumber);
        }
        public void SetPhoneInfoByPhone(string phone = "0", string phoneType = "business", string countryCode = "us", string phoneNumber = "3128675309")
        {
            PhoneTypeSelector(phone, phoneType);
            PhoneCountryCodeSelector(phone, countryCode);
            EnterPhoneNumberByPhone(phone, phoneNumber);
        }
        public void BeneficiaryTypeSelector(string beneficiaryType = "person") //value list: person, entity, trust
        {
            var locator = "//select[@name='type']/option[@value='" + beneficiaryType.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void BeneficiaryRelationshipSelector(string beneficiaryRelation = "spouse") //value list: spouse, other
        {
            var locator = "//select[@name='relationship']/option[@value='" + beneficiaryRelation.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void EmploymentStatusSelector(string employmentStatus = "not-currently-employed") //value list: employed, self-employed, not-currently-employed, retired, student, minor
        {
            var locator = "//select[@name='employmentStatusId']/option[@value='" + employmentStatus.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void AccountTransferFromSelector(string firm = "charles-schwab") //value list: ameriprise, charles-schwab, edward-jones, lpl, merrill-edge, merrill-lynch, morgan-stanley, national-financial, pershing, raymond-james, rbc, ubs, wells-fargo, other-firm
        {
            var locator = "//select[@id='transferringFrom']/option[@value='" + firm.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void InvestmentLengthSelector(string investmentLength = "short") //value list: short, intermediate, long
        {
            var locator = "//select[@id='investmentLength']/option[@value='" + investmentLength.ToLower() + "']";
            var selection = WaitAndFindElement(By.XPath($"{locator}"));
            selection.Click();
            _wait.Until(ExpectedConditions.ElementToBeSelected(selection));
        }
        public void InvestmentPeriodSelector(string investmentLength = "short") //value list: short, intermediate, long
        {
            var locator = "//select[@id='investmentPeriod']/option[@value='" + investmentLength.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void AccountOwnerSelector(string accountOwner = "1") //value list: Starts at "1", this is open ended to select whichever account owner in order.
        {
            var locator = "(//input[@class='checkbox'])[" + accountOwner + "]";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void AccountTypeSelector(string iRAAccountType = "1")
        {
            var locator = "(//input[@class='checkbox'])[" + iRAAccountType + "]";
            WaitAndFindElement(By.XPath($"{locator}")).Click();
        }
        public void TrustedContactsPhoneTypeSelector(string phoneType = "business") //value list: business, home, mobile
        {
            var locatorType = "//select[@id='phoneTypeId']/option[@value='" + phoneType.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locatorType}")).Click();
        }
        public void TrustedContactsPhoneCountryCodeSelector(string countryCode = "ca")
        {
            var locatorCode = "//select[@id='phoneCountryCodeId']/option[@value='" + countryCode.ToLower() + "']";
            WaitAndFindElement(By.XPath($"{locatorCode}")).Click();
        }
        public void PrimaryBeneficiaryAllocationFieldSelector(string beneficiary = "0", string allocation = "50")
        {
            var locatorCode = "//input[@name='primaryBeneficiaries.beneficiaries." + beneficiary + ".primaryAllocation']";
            WaitAndFindElement(By.XPath($"{locatorCode}")).Clear();
            WaitAndFindElement(By.XPath($"{locatorCode}")).SendKeys(allocation);
        }
        public void PrimaryBeneficiaryStirpesSelector(string beneficiary = "0")
        {
            var locatorCode = "//input[@id='primaryBeneficiaries.beneficiaries." + beneficiary.ToLower() + ".perStirpes']";
            WaitAndFindElement(By.XPath($"{locatorCode}")).Click();
        }
        public void ContingentBeneficiaryAllocationFieldSelector(string beneficiary = "0", string allocation = "50")
        {
            var locatorCode = "//input[@name='contingentBeneficiaries.beneficiaries." + beneficiary + ".primaryAllocation']";
            WaitAndFindElement(By.XPath($"{locatorCode}")).Clear();
            WaitAndFindElement(By.XPath($"{locatorCode}")).SendKeys(allocation);
        }
        public void ContingentBeneficiaryStirpesSelector(string beneficiary = "0")
        {
            var locatorCode = "//input[@id='contingentBeneficiaries.beneficiaries." + beneficiary.ToLower() + ".perStirpes']";
            _actions.ScrollToElement(PageFooter);
            try
            {
                WaitAndFindElement(By.XPath($"{locatorCode}")).Click();
            }
            catch
            {
                WaitAndFindElement(By.XPath($"{locatorCode}")).Click();
            }
        }

        // Form Clears
        public void ClearHouseholdAddressScreen()
        {
            HouseholdDetailsAddress1Field.Clear();
            HouseholdDetailsAddress2Field.Clear();
            HouseholdDetailsCityField.Clear();
            HouseholdDetailsPostalCodeField.Clear();
        }
        public void ClearAccountOwnersNameScreen()
        {
            AccountOwnersLegalFirstNameField.Clear();
            AccountOwnersLegalMiddleNameField.Clear();
            AccountOwnersLegalLastNameField.Clear();
            AccountOwnersPreferredFirstNameField.Clear();
        }

        // Button try/catches
        public void AccountsToAccountServices()
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(AccountsGoToAccountServicesButton));
                AccountsGoToAccountServicesButton.Click();
            }
            catch
            {
                AccountServicesSideNavigation.Click();
            }
        }
        public void AccountOwnerToAccounts()
        {
            if (_driver.Url == "https://uatonboarding.rwbaird.com/account-owners/1/summary")
            {
                try
                {
                    _actions.ScrollToElement(SaveAndExitButton);
                    SaveAndExitButton.Click();
                }
                catch
                {
                    _actions.ScrollToElement(SaveAndExitButton);
                    SaveAndExitButton.Click();
                }
            }
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(AccountOwnersGoToAccountsButton));
                AccountOwnersGoToAccountsButton.Click();
            }
            catch
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(AccountOwnersGoToAccountsButton));
                AccountOwnersGoToAccountsButton.Click();
            }
        }
        public void ClickLetsMoveOn()
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(LetsMoveOnButton));
                LetsMoveOnButton.Click();
            }
            catch
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(LetsMoveOnButton));
                LetsMoveOnButton.Click();
            }
            Thread.Sleep(1000);
        }
        public void ClickNextButton()
        {
            
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(NextButton));
                NextButton.Click();
            }
            catch
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(NextButton));
                NextButton.Click();
            }
        }
        public void ClickGetStartedButton()
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(LetsGetStartedButton));
                LetsGetStartedButton.Click();
            }
            catch
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(LetsGetStartedButton));
                LetsGetStartedButton.Click();
            }
        }
        public void ClickGetStartedButtonSecuritiesIndustry()
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(GetStartedButton));
                GetStartedButton.Click();
            }
            catch
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(GetStartedButton));
                GetStartedButton.Click();
            }

        }
    }
}
