Feature: DatacomScenariosLogin


Scenario Outline: Navigate to the error page
	Given I navigate to the homepage with the below envrionment
		| BrowserName | Url                                       |
		| <Browser>   | https://qa-practice.netlify.app/bugs-form |
	Then Error Home page should be displayed
Examples:
	| Browser |
	| chrome  |
	| edge    |


Scenario Outline: Verify the Last Name is trimmed after regirstration
	Given I navigate to the homepage with the below envrionment
		| BrowserName | Url                                       |
		| <Browser>   | https://qa-practice.netlify.app/bugs-form |
	Then Error Home page should be displayed
	And I Enter all the form details
		| FirstName | LastName | PhoneNumber  | Country     | EmailAddress  | Password |
		| Johnny    | Bravo    | "8109090091" | New Zealand | abc@gmail.com | Pwdqwe   |
	And I click on Register button on Error Page
	Then I verify the Success message
	Then Verify Last Name is trimmed
Examples:
	| Browser |
	| chrome  |
	| edge    |


Scenario Outline: Verify the Phone Number is last digit is one greater than actual phone number after regirstration
	Given I navigate to the homepage with the below envrionment
		| BrowserName | Url                                       |
		| <Browser>   | https://qa-practice.netlify.app/bugs-form |
	Then Error Home page should be displayed
	And I Enter all the form details
		| FirstName | LastName | PhoneNumber  | Country     | EmailAddress  | Password |
		| Johnny    | Bravo    | "8109090091" | New Zealand | abc@gmail.com | Pwdqwe   |
	And I click on Register button on Error Page
	Then I verify the Success message
	Then Verify Phone Number is incremented by one
Examples:
	| Browser |
	| chrome  |
	| edge    |


Scenario Outline: Verify the Last Name field is required
	Given I navigate to the homepage with the below envrionment
		| BrowserName | Url                                       |
		| <Browser>   | https://qa-practice.netlify.app/bugs-form |
	Then Error Home page should be displayed
	And I Enter all the form details
		| FirstName | LastName | PhoneNumber  | Country     | EmailAddress  | Password |
		| Johnny    |		   | "8109090091" | New Zealand | abc@gmail.com | Pwdqwe   |
	And I click on Register button on Error Page
	Then I verify the Success message
	Then Verify Last Name field is not blank
Examples:
	| Browser |
	| chrome  |
	| edge    |


Scenario Outline: Verify Password length field is between six and twenty characters
	Given I navigate to the homepage with the below envrionment
		| BrowserName | Url                                       |
		| <Browser>   | https://qa-practice.netlify.app/bugs-form |
	Then Error Home page should be displayed
	And I Enter all the form details
		| FirstName | LastName | PhoneNumber  | Country     | EmailAddress  | Password |
		| Johnny    | Depp     | "8109090091" | New Zealand | abc@gmail.com | Fivee    |
	And I click on Register button on Error Page
	Then Verify Password length field is between six and twenty characters
Examples:
	| Browser |
	| chrome  |
	| edge    |


Scenario Outline: Verify Phone Number field is atleast 10 characters
	Given I navigate to the homepage with the below envrionment
		| BrowserName | Url                                       |
		| <Browser>   | https://qa-practice.netlify.app/bugs-form |
	Then Error Home page should be displayed
	And I Enter all the form details
		| FirstName | LastName | PhoneNumber | Country     | EmailAddress  | Password |
		| Johnny    | Depp     | "81090"     | New Zealand | abc@gmail.com | Fivee    |
	And I click on Register button on Error Page
	Then Verify Phone Number field length is atleast ten characters
Examples:
	| Browser |
	| chrome  |
	| edge    |
