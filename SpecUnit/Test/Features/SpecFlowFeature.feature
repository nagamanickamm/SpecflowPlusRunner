Feature: SpecFlowFeature

@specflow
Scenario: Add two numbers in Web
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	