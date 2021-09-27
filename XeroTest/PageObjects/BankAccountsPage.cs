using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace XeroTest.PageObjects
{
    public class BankAccountsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public BankAccountsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Add Bank Account")]
        private IWebElement addBankAccountLink;

        public String getPageTitle()
        {
            return driver.Title;
        }

        public AddAccountPage accountPage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Add Bank Account")));
            addBankAccountLink.Click();
            return new AddAccountPage(driver);
        }



    }

   
}
