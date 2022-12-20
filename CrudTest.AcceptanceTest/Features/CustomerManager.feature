Feature: Create Read Edit Delete Customer

    Background:
        Given system error codes are following
          | Code | Description                                                |
          | 101  | Invalid Mobile Number                                      |
          | 102  | Invalid Email address                                      |
          | 201  | Duplicate customer by First-name, Last-name, Date-of-Birth |
          | 202  | Duplicate customer by Email address                        |

    Scenario Outline: Create Read Edit Delete Customer
        When user creates a customer with following data
          | ID | Firstname | Lastname | Email        | PhoneNumber   | DateOfBirth |
          | 1  | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 |
        Then user can lookup all customers and filter by Email of "john@doe.com" and get "1" records
        When user creates a customer with following data
          | ID | Firstname | Lastname | Email        | PhoneNumber   | DateOfBirth |
          | 1  | John      | Doe      | john2000@doe.com | +989121234567 | 01-JAN-2000 |
        Then user receive error code "201"
        And user can lookup all customers and filter by Email of "john2000@doe.com" and get "0" records
        And user can lookup all customers and filter by Email of "john@doe.com" and get "1" records
        When user creates a customer with following data
          | ID | Firstname | Lastname | Email        | PhoneNumber   | DateOfBirth |
          | 1  | Sara      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 |
        Then user receive error code "202"
        And user can lookup all customers and filter by Email of "john@doe.com" and get "1" records
        When user edit customer with new email of "new@email.com"
        Then user can lookup all customers and filter by Email of "john@doe.com" and get "0" records
        And user can lookup all customers and filter by Email of "new@email.com" and get "1" records
        When user delete customer by Email of "new@email.com"
        Then user can lookup all customers and filter by Email of "john@doe.com" and get "0" records
        And user can lookup all customers and filter by Email of "new@email.com" and get "0" records
        When user creates a customer with following data
          | ID | Firstname | Lastname | Email        | PhoneNumber   | DateOfBirth |
          | 1  | Sara      | Doe      | sara@doe.com | +9121234567 | 01-JAN-2000 | 
        Then user receive error code "101"
        And user can lookup all customers and filter by Email of "sara@doe.com" and get "0" records
        When user creates a customer with following data
          | ID | Firstname | Lastname | Email        | PhoneNumber   | DateOfBirth | 
          | 1  | John      | Doe      | johndoe.com | +989121234567 | 01-JAN-2000 | 
        Then user receive error code "102" 
        And user can lookup all customers and filter by Email of "johndoe.com" and get "0" records
       

     