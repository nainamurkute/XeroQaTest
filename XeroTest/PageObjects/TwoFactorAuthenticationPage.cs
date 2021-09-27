using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace XeroTest.PageObjects
{
    public class TwoFactorAuthenticationPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public TwoFactorAuthenticationPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit' and contains(.,'Use another authentication method')]")]
        private IWebElement useAnotherAuthenticationLink;

        public SelectAuthenticationMethodPage AuthPage()
        {

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@type='submit' and contains(.,'Use another authentication method')]")));
            useAnotherAuthenticationLink.Click();
            return new SelectAuthenticationMethodPage(driver);

        }
    }
}
