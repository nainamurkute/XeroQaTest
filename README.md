# XeroQaTest

#User Story
As a Xero User, In order to manage my business successfully, 
I want to be able to add an “ANZ (NZ)” bank accountinside any Xero Organisation.

#XeroQaTest
This is a sample automated test for Xero Coding Exercise - QA Analyst

#There are two tests:
- one Basic flows : Login success 
- two Add acount and verify that account number is added : Add Anz Account

#To execute this test
- Clone the repo from github
- Open the project (.sln) => Build
- Right click => Run test(s) the  LoginTest.cs file from Tests folder
- Right click => Run test(s) the  AddANZBankAccountTest.cs file from Tests folder
- Both tests should pass


#Future improvement
- Implement in Given-When-Then format (BDD)
- Create report for test run
- fetch User name and password from config file


#Note
I have note provided my login credentials, so one has to add there own login credentials to run tests
- LoginTest.cs Line 32,33
- AddANZBankAccountTest Line 29, 30
