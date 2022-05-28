Feature: ProtonLogin

A short summary of the feature


@Login @proton
Scenario: Login second email with correct login and password
	Given I open Proton login webpage
	When I enter "youremail@proton.me" in login input
	And I enter 'yourpassword' in password input
	And I click Login button
	Then the proton main page with "secondfreeemail@proton.me" title should be opened 

@Login @proton
Scenario: Login first email  with incorrect login and/or password
	Given I open Proton login webpage
	When I enter "youremail@proton.me" in login input
	And I enter 'incorrectpassword' in password input
	And I click Login button
	Then the error message should be "Incorrect login credentials. Please try again"
	
@Login @proton
Scenario: Login first email with empty login and/or password
	Given I open Proton login webpage
	When I enter "youremail@proton.me" in login input
	And I enter '' in password input
	And I click Login button
	Then the error message should be "This field is required"