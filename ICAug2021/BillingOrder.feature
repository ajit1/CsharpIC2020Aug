Feature: BillingOrder

@mytag
Scenario: Submit Billing Order Page
	Given I am on billing order page
	And enter user details
	When click submit button
	Then user details should be submitted 




