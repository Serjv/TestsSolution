Feature: APITestsFeature
	In order to translate text
	As a user
	I want to get translation of text

@APITests
Scenario: Translation
	Given I have request <path> 
	And I have keys <parameters> 
	When I press Send
	Then the result should be <result>

	Examples:
| path														| parameters							|result			|
|    https://translate.yandex.net/api/v1.5/tr/translate		|   key=yourkey&text=hello&lang=en-ru   |   привет		|
|    https://translate.yandex.net/api/v1.5/tr/detect		|    key=yourkey&text=hello				|   en			|
|    https://translate.yandex.net/api/v1.5/tr/getLangs		|    key=yourkey&ui=en					|   200			|
