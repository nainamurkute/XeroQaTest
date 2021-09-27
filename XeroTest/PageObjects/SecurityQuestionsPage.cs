using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using XeroTest.Models;

namespace XeroTest.PageObjects
{
    public class SecurityQuestionsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SecurityQuestionsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);
        }

        //Security questions
        [FindsBy(How = How.XPath, Using = "//button[@type='submit' and contains(text(),'Confirm')]")]
        private IWebElement ConfirmButton;

        public HomePage ClickConfirm(List<SecurityQuestion> questions)
        {
            foreach (var question in questions)
            {
                string str = $"//label[contains(text(),'{question.Question}')]/following::input[1]";
                if (driver.FindElements(By.XPath(str)).Count > 0)
                {
                    IWebElement element = driver.FindElement(By.XPath(str));
                    element.Click();
                    element.SendKeys(question.Answer);
                }
            }

            ConfirmButton.Click();
            // add wait
            return new HomePage(driver);
        }
    }
}
