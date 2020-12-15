# Fantasy Run
***
### About the game
This project contains the implementation for my Mobile Apps 3 game development.
This game is a fantasy endless runner. The player is brought into an endless environment. Upon starting the game the player starts moving through the endless environment that is generated on the fly. The objective of the player is to collect coins and get a high possible while avoiding enemies and obstacles.
This game is made with <b>Unity Version: 2019.4.11f1</b>
***
### How to play
The players forward movement is done automatically as with any other endless runner.

<b> The A and D keys</b>
These keys are used to move the player from left to right. A for left and D for right. This is useful for when the player needs to dodge oncoming obstacles.

<b> Left and Right Arrows </b>
At certain points in the game the player will be faced with turning point where they will need to turn left or right to survive.
When the player enters these points they can turn left or right. These are the only points they will be able to turn left or right.

<b> Space bar </b>
The space bar is used to enable the player to jump over obstacles and enemies.

***
#### Lives
The player is given 3 lives at the start of the game and if they collide with enemies or obstacles they die, loose a life and start from the first platform. Each time the player dies the skybox changes
***
#### Scoring
The score the player gets is added to a score count called "previous score". If the score of the previous run is the new High score it is added as the high score. Each time the player collides with a coin they are given 5 points towards their total score. The difficulty of the game increases when the player has reached a certain amount of coins. This is done by increasing the players speed, which requires them to think faster and try to plan ahead while playing at an elevated speed. The difficulty is displayed in the top left and corner and changes as the difficulty increases.
***

#### Menus
When the player first starts the game they are presented with a main menu this consists of several buttons that the player can interact with. The buttons are as follows:

##### Play
If this button is chosen it will take the player from the main menu into the game.
***

##### Scores
When this button is selected it shows the players previous score count and their highest score count.
***

##### Help
When this button is chosen it displays help on how to play the game.

##### Options

This enables the player to control the music and sound volume level.

##### Quit
When this button is chosen the application quits the game. The escape key can also be used to do this action.
***

### How to Play game.
- Download Unity 2019.4.11f1
- Download project
- Select project from location on machine
- Play
