## Description
```
Othello game as a Windows application.
The source code can be compiled in Visual Studio
 * Displays potential plays
 * In the end of round- showing the results
 * Allows the user to play against a real or virtual player
```

## Rules
```
Each of the disks' two sides corresponds to one player; they are referred to here as red and yellow after the sides of Othello pieces.

The game begins with four disks placed in a square in the middle of the grid, two facing red side up, two pieces with the yellow side up, with same-colored disks on a diagonal with each other. 

Red must place a piece with the red side up on the board, in such a position that there exists at least one straight (horizontal, vertical, or diagonal) occupied line between the new piece and another red piece, with one or more contiguous yellow pieces between them.

After placing the piece, red turns over (flips) all yellow pieces lying on a straight line between the new piece and any anchoring red pieces. All reversed pieces now show the red side, and red can use them in later moves—unless yellow has reversed them back in the meantime. In other words, a valid move is one where at least one piece is reversed.

Now yellow plays. This player operates under the same rules, with the roles reversed: yellow lays down a yellow piece, causing a red piece to flip. 

Players take alternate turns. If one player can not make a valid move, play passes back to the other player. When neither player can move, the game ends. This occurs when the grid has filled up or when neither player can legally place a piece in any of the remaining squares. This means the game may end before the grid is completely filled. This possibility may occur because one player has no pieces remaining on the board in that player's color.

```
