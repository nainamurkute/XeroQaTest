using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using XeroTest.Models;
using XeroTest.Util;

namespace XeroTest.PageObjects
{
    
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "xl-logo--svg")]
        private IWebElement xeroLogo;

        [FindsBy(How = How.ClassName, Using = "xui-panel-title xui-padding-vertical-small")]
        private IWebElement xeroTitleText;

        [FindsBy(How = How.Id, Using = "xl-form-email")]
        private IWebElement userName;

        [FindsBy(How = How.Id, Using = "xl-form-password")]
        private IWebElement userPassword;

        [FindsBy(How = How.Id, Using = "xl-form-submit")]
        private IWebElement loginButton;


        // Returns the Page Title
        public string getPageTitle()
        {
            return driver.Title;
        }

        // Returns the search string
        public string getSearchText()
        {
            return xeroTitleText.Text;
        }

        // Checks whether the Logo is displayed properly or not
        public bool getWebPageLogo()
        {
            return xeroLogo.Displayed;
        }


        // Go to the designated page
        public void goToPage()
        {
            driver.Navigate().GoToUrl(Resources.SiteUrl);
        }

        public TwoFactorAuthenticationPage Page(TestUserCredentials testUser)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("xl-logo--svg")));
            userName.SendKeys(testUser.Username);
            userPassword.SendKeys(testUser.Password);
            loginButton.Click();

            return new TwoFactorAuthenticationPage(driver);
        }

        //public HomePage Page(TestUserCredentials testUser)
        //{
        //    userName.SendKeys(testUser.Username);
        //    userPassword.SendKeys(testUser.Password);
        //    loginButton.Click();
        //    return new HomePage(driver);
        //}

    }
}
