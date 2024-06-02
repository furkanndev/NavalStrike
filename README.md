# Naval Strike

## Project Description
Naval Strike is a naval combat game where the player controls a ship to shoot submarines and score points. Players have two different types of ammunition and face submarines that appear randomly from the edges of the game screen and move horizontally. The game starts after entering player information, difficulty level, and time limit from the entry screen.

## Game Features
- The player controls a ship to shoot submarines and score points.
- The player has two different types of ammunition.
- Enemy submarines are randomly spawned from the edges of the screen and move horizontally.
- The menu screen allows entering player information, difficulty level, and time limit before starting the game.

## Menu Screen
1. Press ENTER to start the game.
2. Game controls:
   - Use the arrow keys to move your ship.
   - Press the Space key to shoot.
   - Press the P key to pause the game.
3. View the best scores:
   - The top 5 scores are listed on a separate form screen (data is read from a text file).

## Game Screen
- The remaining time, the number of submarines hit, and the score are displayed.
- Each hit scores +5 points (the scoring method can be customized).
- After a certain period, the speed of incoming submarines increases (e.g., every 20 seconds).
- A mystery box appears every 10 seconds:
  - The mystery box has a 50% chance of providing a benefit or a detriment (e.g., add or subtract 10 points).

## Best Scores
- The top 5 highest scores are recorded and continuously updated with new scores.

## PAUSE Functionality
- Pressing the P key pauses the game (it does not end the game).

## Getting Started
1. Clone this repository:
   ```sh
   git clone https://github.com/furkanndev/naval-strike.git

2.Open the solution file in Visual Studio.

3.Build the solution to restore the necessary packages.

4.Run the project.
