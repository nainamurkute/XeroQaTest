using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace XeroTest.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Accounting')]")]
        private IWebElement menuAccounting;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Bank accounts')]")]
        private IWebElement subMenuBankAccounts;
              
        public BankAccountsPage bankAccountPage()
        {
            menuAccounting.Click();
            subMenuBankAccounts.Click();
            //add wait
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'Bank accounts')]")));
            return new BankAccountsPage(driver);
        }

        public bool CheckAddedAccount(string accountNumber)
        {
            var TestAccountNumber = driver.FindElement(By.XPath($"//div[contains(text(),'{accountNumber}')]"));
            return TestAccountNumber.Displayed;
        }
    }
}
