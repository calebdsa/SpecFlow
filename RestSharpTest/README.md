Basic Bank System API Automation Framework
Overview
This repository contains a C# API automation framework using SpecFlow, RestSharp, and NUnit for testing the Basic Bank System API. The framework focuses on scenarios such as creating an account, deleting an account, depositing to an account, and withdrawing from an account.

Table of Contents
Prerequisites
Project Structure
Usage
Scenarios
Endpoints
Test Coverage
Tech Stacks

Prerequisites
Before running the tests, make sure you have the following installed:
Visual Studio or another C# development environment.
SpecFlow for behavior-driven development (BDD).
RestSharp for making API requests.
NUnit for assertions.

Project Structure
The project is organized as follows:
Features: Contains the SpecFlow feature files defining test scenarios.
Models: Holds the C# objects for request and response serialization.
Steps: Contains the C# step definitions for the scenarios.
Utils: Includes a Helper class for serializing requests, executing endpoints, and deserializing responses.

Usage
Clone the repository:
git clone https://github.com/yourusername/basic-bank-api-automation.git
Open the solution in your preferred C# development environment (e.g., Visual Studio).

Run the tests to ensure the system functions as expected:
dotnet test

Scenarios
Scenario: Create new Account with valid data
    Given Account Initial Balance is $1000
    And Account name is "Rajesh Mittal"
    And Address is "Ahmedabad, Gujarat"
    When POST endpoint triggered to create new account with above details
    Then Verify the response code is 200
    And Verify no error is returned
    And Verify the success message "Account created successfully"
    And Verify the account details are correctly returned in the JSON response
    And Store Account Number as "<AccountNumber>"

    Examples:
    | InitialBalance  | AccountName        | Address                    |
    |    1000         | "Rajesh Mittal"    | "Ahmedabad, Gujarat"       |

Scenario Outline: Deposit to an Account
    Given Get the Account Number
    And Deposite Amount is <Amount>
    When PUT endpoint triggered to deposit to the account
    Then Verify the response code is 200
    And Verify no error is returned
    And Verify the success message "<SuccessMessage>"
    And Verify the deposite new balance is <NewBalance>

    Examples:
    | Amount | SuccessMessage                                             | NewBalance |
    | 1000   | "1000$ deposited to Account {account Number} successfully" | 2000       |

Scenario Outline: Withdraw from an Account
    Given Get the Account Number
    And Amount is <Amount>
    When PUT endpoint triggered to withdraw from the account
    Then Verify the response code is 200
    And Verify no error is returned
    And Verify the success message "<SuccessMessage>"
    And Verify the withdraw new balance is <NewBalance>

    Examples:
     | Amount | SuccessMessage                                              | NewBalance |
     | 500    | "500$ withdrawn from Account {account Number} successfully" | 1500       |


    Scenario: Delete an Account
    Given Get the Account Number
    When DELETE endpoint triggered to delete the account
    Then Verify the response code is 200
    And Verify no error is returned
    And Verify the success message "Account {account Number} deleted successfully"

Endpoints
Create Account:

Endpoint: POST https://www.localhost:8080/api/account/create
Request Payload:
{
  "InitialBalance": 1000,
  "AccountName": "Rajesh Mittal",
  "Address": "Ahmedabad, Gujarat"
}
Response:
{
  "Data": {
    "NewBalance": 1000,
    "AccountName": "Rajesh Mittal",
    "AccountNumber": "X123"
  },
  "Message": "Account X123 created successfully",
  "Errors": []
}

Delete Account:

Endpoint: DELETE https://www.localhost:8080/api/account/delete/{accountID}
Response:
{
  "Data": null,
  "Message": "Account {accountID} deleted successfully",
  "Errors": []
}

Deposit to Account:

Endpoint: PUT https://www.localhost:8080/api/account/deposit
Request Payload:
{
  "AccountNumber": "X123",
  "Amount": 1000
}
Response:
{
  "Data": {
    "AccountNumber": "X123",
    "NewBalance": 2000
  },
  "Message": "1000$ deposited to Account X123 successfully",
  "Errors": []
}

Withdraw from Account:

Endpoint: PUT https://www.localhost:8080/api/account/withdraw
Request Payload:
{
  "AccountNumber": "X123",
  "Amount": 1000
}
Response:
{
  "Data": {
    "AccountID": "X123",
    "NewBalance": 0
  },
  "Message": "1000$ withdrawn from Account X123 successfully",
  "Errors": []
}

Test Coverage
The framework covers the following scenarios:

Creating a new account with valid data.
Deleting an account.
Depositing funds into an account with various scenarios.
Withdrawing funds from an account with various scenarios.

Tech Stacks
SpecFlow: Behavior-driven development framework.
RestSharp: HTTP library for making API requests.
NUnit: Unit testing framework for assertions.
