Feature: Basic Bank System

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
    And Verify the success message "Account X123 deleted successfully"