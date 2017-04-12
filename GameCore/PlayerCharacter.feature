Feature: PlayerCharacter
	In order to play the game 
	As a human player
	I want my character attributes to be correctly represented 


Background: 
	Given I'm a new player

Scenario Outline: Health reduction
	When I take <damage> damage
	Then My health should be <expectedHealth>

	Examples: 
	| damage | expectedHealth |
	| 0      | 1000           |
	| 250    | 750            |
	| 700    | 300            |
	| 999    | 1              |

Scenario: Two players are hitting me
	When I take 1000 damage 
	Then I will be dead

Scenario: Elf race characters get additional 200 damage resistance
		And I have a damage resistnace of 100
		And I'm an Elf
	When I take 700 damage
	Then My health should be 600

Scenario: Elf race characters get additional 200 damage resistance in a data table`
		And I have the following attribute
		| attribute  | value |
		| Race       | Elf   |
		| Resistance | 100   |
	When I take 700 damage
	Then My health should be 600