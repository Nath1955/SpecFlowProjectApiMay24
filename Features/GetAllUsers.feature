Feature: GetAllUsers

@mytag
Scenario:Retrieve all users info
	Given I have a resource
	When I request all users info
	Then the response code to retrieve all users is 200
	And the response body includes the following:
	| page | per_page | total | total_pages | id | email                  | first_name | last_name | avatar                                  |
	| 1    | 6        | 12    | 2           | 1  | george.bluth@reqres.in | George     | Bluth     | https://reqres.in/img/faces/1-image.jpg |
	| 1    | 6        | 12    | 2           | 2  |janet.weaver@reqres.in  | Janet      | Weaver      | https://reqres.in/img/faces/2-image.jpg |

Scenario: Create a new user
 Given I have a new user endpoint
 When I request to create a new user with the following body:
 | name   | job    |
 | Joseph | leader |
 Then the response code for newly created user is 201
 And the response body include the following:
 | name   | job    |
 | Joseph | leader |




	

	