Feature: Cars

@mytag
Scenario Outline: Compare cars price
	Given navigate to cars page
	When go to the research page
	And search <make> and <model> and <year> and <trim>
	When move to <make> trim page
	And remembering characteristics seats and doors for <make>
	Given navigate to cars page
	When go to the research page
	And search Nissan and Rogue and 2008 and S
	When move to Nissan trim page
	And remembering characteristics seats and doors for Nissan
	When go to the research page
	And switch to the Compare cars page
	And click add car button
	And add <make> car
	And click add car button
	And add Nissan car
	And click see the comparison button
	Then the expected characteristics <make> and Nissan
	When move to the <make> page
	And save <make> price
	Given navigate to cars page
	And go to car for sale tab
	And search <make> car
	And add trim and year parameter for <make> car
	Then new <make> price higher then used car

	Examples: 
	| make  | model | year | trim      |
	| Honda | Civic | 2000 | EX        |
	| BMW   | X7    | 2023 | xDrive40i |



@mytag
Scenario Outline: Compare cars
	Given navigate to cars page
	When go to the research page
	And search Honda and Civic and 2000 and EX
	When move to Honda trim page
	And remembering characteristics seats and doors for Honda
	Given navigate to cars page
	When go to the research page
	And search Nissan and Rogue and 2008 and S
	When move to Nissan trim page
	And remembering characteristics seats and doors for Nissan
	When go to the research page
	And switch to the Compare cars page
	And click add car button
	And add Honda car
	And click add car button
	And add Nissan car
	And click see the comparison button
	Then the expected characteristics Honda and Nissan





