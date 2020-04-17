Feature: Translation
	In order to translate text
	As a user
	I want to get translation of text

@Browser_Chrome
@Browser_Edge
@Browser_Firefox
Scenario: Translation
	Given I navigated to translation page
	When I have entered <text> into the translator
	And I choosen translate on <lang>
	Then the result should be <Result> on the screen

Examples:
| text			| lang			|Result			 |
|    привет		|   английский  |    Hi			 |
|    привет мир	|    английский	|   Hello World  |
|    hello world|    русский	|   Привет мир   |