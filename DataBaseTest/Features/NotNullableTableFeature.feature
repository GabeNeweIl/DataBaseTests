Feature: NotNullableTableFeature
	This page includes scripts to check tables for records

Scenario Outline: Checking tables for records
When I am making an query for <tableName>
Then Count of records should be more the '0'

Examples: 
| tableName             |
| sales.customers       |
| production.brands     |
| production.categories |
| productions.products  |
| sale.staff            |
| sale.stores           |