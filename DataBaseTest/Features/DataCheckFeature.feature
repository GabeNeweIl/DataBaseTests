Feature: DataCheck
	This page includes scripts for checking data in database

Scenario: The table "sales.store" should include record with valid information
Given Test information of store with following data
| StoreId | StoreName        | Phone          | Email                | Street              | City       | State | ZipCode |
| 1       | Santa Cruz Bikes | (831) 476-4321 | santacruz@bikes.shop | 3700 Portola Drive  | Santa Cruz | CA    | 95060   |
When I do a query to get record from the table "sales.store" wiht id '1'
Then Records from sales.store should include the same information like in testing data

Scenario: The table "sales.staff" should include record with valid information
Given Test information of staff with following data
| StaffId | FirstName | LastName | Email                     | Phone          | StoreId | Active | ManagerId |
| 5       | Jannette  | David    | jannette.david@bikes.shop | (516) 379-4444 | 2       | 1      | 1         |
When I do an query to get record from table sales.staff with id '5'
Then Records from sales.staff should include the same information like in testing data

Scenario: The table production.brands should include record with valid information
Given The infromation of brand with following data
| BrandId | BrandName |
| 3       | Heller    |
When I do an a query to get record from table production.brands with id '3'
Then Records from production.brands should include the same information like in testing data

Scenario: The table production.categories should include record with valid information
Given The infromation of category with following data
| CategoryId | CategoryName |
| 7          | Road Bikes   |
When I do an a query to get record from table production.categories with id '7'
Then Records from production.categories should include the same information like in testing data