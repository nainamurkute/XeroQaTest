using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace XeroTest.PageObjects
{
    public class SelectAuthenticationMethodPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SelectAuthenticationMethodPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);

        }

        //Security questions
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Security questions')]")]
        private IWebElement securityQuestionButton;

        public SecurityQuestionsPage securityquestion()
        {
            securityQuestionButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(),'Answer your security questions to authenticate')]")));
            return new SecurityQuestionsPage(driver);
        }

    }
}
