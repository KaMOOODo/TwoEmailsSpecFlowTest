Feature: TutanotaLogin

A short summary of the feature

@Login @tutanota
Scenario: Login first email  with correct login and password
	Given I open Tutanota login webpage
	When I enter "youremail@tutanota.com" in login input
	And I enter 'yourpassword' in password input
	And I click Login button
	Then the tutanota main page with "youremail@tutanota.com" title should be opened 

@Login @tutanota
Scenario: Login first email  with incorrect login and/or password
	Given I open Tutanota login webpage
	When I enter "youremail@tutanota.com" in login input
	And I enter 'incorrectpassword' in password input
	And I click Login button
	Then the error message should be "Invalid login credentials. Please try again. Lost account access"
	
@Login @tutanota
Scenario: Login first email with empty login and/or password
	Given I open Tutanota login webpage
	When I enter "youremail@tutanota.com" in login input
	And I enter '' in password input
	And I click Login button
	Then the error message should be "Invalid login credentials. Please try again. Lost account access"
