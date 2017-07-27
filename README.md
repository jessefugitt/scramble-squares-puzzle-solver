# scramble-squares-puzzle-solver


## Output
dotnet ScrambleSquaresPuzzleSolver.dll

### Puzzle Solver (full backtracking that only validates after board is full)
~~~~
Puzzle solver started at: 7/24/2017 8:46:39 PM
Solved puzzle!
Position 0 is Tile { ID=B, Rotations=2}
Position 1 is Tile { ID=H, Rotations=4}
Position 2 is Tile { ID=C, Rotations=4}
Position 3 is Tile { ID=I, Rotations=4}
Position 4 is Tile { ID=A, Rotations=4}
Position 5 is Tile { ID=E, Rotations=1}
Position 6 is Tile { ID=G, Rotations=4}
Position 7 is Tile { ID=F, Rotations=4}
Position 8 is Tile { ID=D, Rotations=3}
Puzzle solver finished at: 7/24/2017 8:51:53 PM
~~~~

### Pruning Puzzle Solver (checks tile during each placement to see if it is allowed while building board)
~~~~
Puzzle solver started at: 7/26/2017 11:06:35 PM
Solved puzzle!
Position 0 is Tile { ID=B, Rotations=2}
Position 1 is Tile { ID=H, Rotations=4}
Position 2 is Tile { ID=C, Rotations=4}
Position 3 is Tile { ID=I, Rotations=4}
Position 4 is Tile { ID=A, Rotations=4}
Position 5 is Tile { ID=E, Rotations=1}
Position 6 is Tile { ID=G, Rotations=4}
Position 7 is Tile { ID=F, Rotations=4}
Position 8 is Tile { ID=D, Rotations=3}
Puzzle solver finished at: 7/26/2017 11:06:36 PM
~~~~
