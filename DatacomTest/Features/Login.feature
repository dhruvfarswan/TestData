Feature: DatacomScenariosLogin


Scenario Outline: Login to the application
	Given I navigate to the homepage with the below envrionment
	| BrowserName | Url                                     |
	| <Browser>   | http://automationpractice.com/index.php |
	When I click on login button
	Then Login page should be displayed
	When I enter username and password as testuserauto@gmail.com and QssCD123#
	Examples: 
	| Browser |
	| chrome  |
	| edge    |

Scenario Outline: Register to the application
	Given I navigate to the homepage with the below envrionment
	| BrowserName | Url                                     |
	| <Browser>   | http://automationpractice.com/index.php |
	When I click on login button
	Then Login page should be displayed
	When I enter Email address and click on create account
	Then Create an account page is displayed
	And I Enter all the below required details
    | FirstName | LastName | Password | Address    | City | State  | ZipCode   | MobileNo     |
    | John      | Bravo    | qwqwe@@  | ABC Street | XYZ  | Kansas | "66002"   | "9898987898" |
	Then I click on Register button

	Examples: 
	| Browser |
	| chrome  |
	| edge    |


	Scenario Outline: Add 2 products to shopping cart
	Given I navigate to the homepage with the below envrionment
	| BrowserName | Url                                     |
	| <Browser>   | http://automationpractice.com/index.php |
	When I click on Add to Cart for 1 product
	And I click on Continue Shopping button
	And I click on Add to Cart for 2 product
	And I click on Continue Shopping button
	Then I verify the total price of the products in the cart is correct or not
	Examples: 
	| Browser |
	| chrome  |
	| edge    |