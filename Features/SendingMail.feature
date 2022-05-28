Feature: SendingMail

A short summary of the feature

@SendingMail
Scenario: Log in to one of the services and send a letter from it to another mailbox of a predetermined arbitrary content.
	Given I open Tutanota main webpage
	When I send email to "youremail@proton.me" with text "This message was created by SpecFlow test"
	When I open Proton main webpage
	Then The unread email from "youremail@tutanota.com" exists in the conversation list