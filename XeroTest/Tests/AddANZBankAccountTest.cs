using System;
using System.Collections.Generic;
using System.Text;
using XeroTest.Models;
using XeroTest.PageObjects;
using NUnit.Framework;

namespace XeroTest.Tests
{
    public class AddANZBankAccountTest:BaseTest
    {
        public LoginPage xerologinpage { get; set; }

        public HomePage homePage { get; set; }

        public TestAccount testAccount { get; set; }

        public TestUserCredentials testuser { get; set; }

        private string accountNumber;

        [Test]
        public void AddAnzAccount()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();

            testuser = new TestUserCredentials();
            testuser.Username = "User name";  //Enter user name here
            testuser.Password = "Password";   //Enter user password
            //login.Page(testuser);

            TwoFactorAuthenticationPage twoFactorAuthenticationPage = login.Page(testuser);

            SelectAuthenticationMethodPage selectAuthenticationMethod = twoFactorAuthenticationPage.AuthPage();

            SecurityQuestionsPage secQuestions = selectAuthenticationMethod.securityquestion();

            var questionList = new List< SecurityQuestion > (){
                new SecurityQuestion() { Question = "What was the name of your first pet?", Answer = "Snoopy" },
                new SecurityQuestion() { Question = "Who is your favourite poet?", Answer = "Xero1234" },
                new SecurityQuestion() { Question = "Who is your favourite fictional character?", Answer = "Naruto" },
            };

            //HomePage homePage = login.Page(testuser);
            HomePage homePage = secQuestions.ClickConfirm(questionList);

            BankAccountsPage bankAccounts = homePage.bankAccountPage();

            AddAccountPage addAccountPage = bankAccounts.accountPage();

            addAccountPage.EnterANZfromPopularBanksInNZOption();

            testAccount = new TestAccount();
            testAccount.ANZAccountName = "XeroDemo12";
            testAccount.ANZAccountNumber = "12-12345-12346";

            accountNumber = testAccount.ANZAccountNumber;

            addAccountPage.EnterANZAccountDetails(testAccount);

            addAccountPage.ContinueButton();
            addAccountPage.GotaFormButton();
            addAccountPage.WillDoItLater();
            addAccountPage.GoToDashboard();

            //validation
            var accountVisible = homePage.CheckAddedAccount(accountNumber);
            Assert.IsTrue(accountVisible, "Account number is not avialable");
        }

    }
}
