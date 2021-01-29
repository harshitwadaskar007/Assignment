Feature: API_Assignment
	Assignment - Validate the JSON response with valid and invalid scenarios  

@BindingsOnly
Scenario: Validate json response 
	Given I call API with key as 'GDMSTGExy0sVDlZMzNDdUyZ'
	Then  I verify status '200'
	And   I verify promotion properties 

@BindingsOnly
Scenario: Validate promotionId and programType 
	Given I call API with key as 'GDMSTGExy0sVDlZMzNDdUyZ'
	Then  I verify promotionId and programType properties 

@BindingsOnly
Scenario: Validate response with invalid apikey
	Given I call API with key as 'WeId32YeN$dgVSSSUUUJJJJJ'
	Then  I verify status '403'
	And   I verify response with invalid api key