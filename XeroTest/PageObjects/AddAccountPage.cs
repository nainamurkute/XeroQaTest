using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using XeroTest.Models;

namespace XeroTest.PageObjects
{
    public class AddAccountPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'ANZ (NZ)')]")]
        private IWebElement ANZFromPolpularBanksNZ;

        [FindsBy(How = How.Id, Using = "accountname-1025-inputEl")]
        private IWebElement accountName;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Account Type')]/following::input[1]")]
        private IWebElement accountTypeList;

        [FindsBy(How = How.XPath, Using = "//li[@class='ba-combo-list-item' and contains(text(),'Everyday (day-to-day)')]")]
        private IWebElement accountType1;

        [FindsBy(How = How.Id, Using = "accountnumber-1056-inputEl")]
        private IWebElement accountNumber;

        [FindsBy(How = How.Id, Using = "common-button-submit-1015")]
        private IWebElement continueButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'got a form')]")]
        private IWebElement iHaveGotFormButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'do it later')]")]
        private IWebElement iWillDoItLater;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Go to dashboard')]")]
        private IWebElement goToDashboard;
        

        public void EnterANZfromPopularBanksInNZOption()
        {
            //add wait
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'ANZ (NZ)')]")));
            Console.WriteLine("Ithink it is visble");
            ANZFromPolpularBanksNZ.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(),'Enter your ANZ (NZ) account details')]")));

            //Add wait until 'Enter your ANz account details screen is visible
        }

        public void EnterANZAccountDetails(TestAccount anzTestAccount)
        {
            accountName.SendKeys(anzTestAccount.ANZAccountName);
            accountTypeList.Click();
            accountType1.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'ANZ (NZ)')]")));
            accountNumber.SendKeys(anzTestAccount.ANZAccountNumber);
        }

        public void ContinueButton()
        {
            continueButton.Click();
            //wait
        }

        public void GotaFormButton()
        {
            iHaveGotFormButton.Click();
        }

        public void WillDoItLater()
        {
            iWillDoItLater.Click();
        }

        public void GoToDashboard()
        {
            goToDashboard.Click();
            Console.WriteLine("Xero homepage");
        }



    }
}
