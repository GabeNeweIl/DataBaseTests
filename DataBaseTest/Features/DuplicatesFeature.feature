Feature: DuplicatesFeature
	This page includes scripts to check for duplicates in tables in the database

Scenario Outline: Checking tables for duplicates
When I am making a query for duplicates in a table <table>
Then Count of duplicate should be '0'

Examples: 
| table                 |
| sales.customers       |
| production.brands     |
| production.categories |
| productions.products  |
| sale.staff            |
| sale.stores           |