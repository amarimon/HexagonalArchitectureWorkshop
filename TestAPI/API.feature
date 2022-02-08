Feature: API
	Simple web api example with user controller

@mytag
Scenario: Create a new user
Given I am a client
    When I make a post request to "v1/User" with the following data 
    """
    {
        "id": "1",
        "userName": "albert",
        "email": "amarimon@cloudactivereception.com",
        "password": "Demo123456"
    }
    """
    Then the response status code is "201"
    ##And the response data should be "{ id: 1 }"

Scenario: Get an user
Given I am a client
    When I make a get request to "v1/User" with the following data "1"
    Then the response status code is "200"
    And the response data should be "{"id":"1","userName":"albert","email":"amarimon@cloudactivereception.com","password":"Demo123456"}"
    