using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using XeroTest.Models;
using XeroTest.PageObjects;
using XeroTest.Tests;

namespace XeroTest
{
    [TestFixture]
    public class LoginTest: BaseTest
    {
      //  public LoginPage xerologinpage {get; set;}

        public HomePage homePage {get; set;}

        public TestAccount testAccount {get; set;}

        public TestUserCredentials testuser {get; set;}

        public string PageTitle = "Login | Xero Accounting Software";

        [Test]
        public void Login()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            Assert.AreEqual(driver.Title, PageTitle);
            testuser = new TestUserCredentials();
            testuser.Username = "User name";  //Enter user name here
            testuser.Password = "Password";   //Enter user password
            login.Page(testuser);

        }

     

     
    }
}