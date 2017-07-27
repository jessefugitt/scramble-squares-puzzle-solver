using System;
using System.Collections.Generic;
using System.Text;

namespace ScrambleSquaresPuzzleSolver
{
    class PuzzleSolver
    {
        public virtual bool Solve(PuzzleState puzzleState)
        {
            bool solved  = SolvePosition(puzzleState, 0);

            if(solved)
            {
                Console.WriteLine("Solved puzzle!");
                for (int j = 0; j < puzzleState.Tiles.Length; j++)
                {
                    Tile solvedTile = puzzleState.TilesByPosition[j];
                    Console.WriteLine("Position " + j + " is Tile " + solvedTile.ToString());
                }
            }
            else
            {
                Console.WriteLine("Did not find a solution!");
            }

            return solved;
        }

        public virtual bool SolvePosition(PuzzleState puzzleState, int pos)
        {
            bool solved = false;
            
            for(int i = 0; i < puzzleState.Tiles.Length && !solved; i++)
            {
                Tile tile = puzzleState.Tiles[i];
                if(!tile.IsUsed)
                {
                    tile.IsUsed = true;
                    puzzleState.TilesByPosition[pos] = tile;
                    for (int r = 0; r < 4 && !solved; r++)
                    {
                        if (pos == 8)
                        {
                            solved = ValidatePuzzle(puzzleState);
                        }
                        else
                        {
                            solved = SolvePosition(puzzleState, pos + 1);
                        }

                        tile.RotateClockwise();
                    }

                    if(!solved)
                    {
                        tile.Reset();
                        puzzleState.TilesByPosition[pos] = null;
                    }
                }
            }
            
            return solved;
        }

        public virtual bool ValidatePuzzle(PuzzleState puzzleState)
        {
            bool solved =
                puzzleState.TilesByPosition[0].CurrentRightGraphic.Name == puzzleState.TilesByPosition[1].CurrentLeftGraphic.Name &&
                puzzleState.TilesByPosition[0].CurrentRightGraphic.IsFront != puzzleState.TilesByPosition[1].CurrentLeftGraphic.IsFront &&

                puzzleState.TilesByPosition[1].CurrentRightGraphic.Name == puzzleState.TilesByPosition[2].CurrentLeftGraphic.Name &&
                puzzleState.TilesByPosition[1].CurrentRightGraphic.IsFront != puzzleState.TilesByPosition[2].CurrentLeftGraphic.IsFront &&


                puzzleState.TilesByPosition[0].CurrentBottomGraphic.Name == puzzleState.TilesByPosition[3].CurrentTopGraphic.Name &&
                puzzleState.TilesByPosition[0].CurrentBottomGraphic.IsFront != puzzleState.TilesByPosition[3].CurrentTopGraphic.IsFront &&

                puzzleState.TilesByPosition[1].CurrentBottomGraphic.Name == puzzleState.TilesByPosition[4].CurrentTopGraphic.Name &&
                puzzleState.TilesByPosition[1].CurrentBottomGraphic.IsFront != puzzleState.TilesByPosition[4].CurrentTopGraphic.IsFront &&

                puzzleState.TilesByPosition[2].CurrentBottomGraphic.Name == puzzleState.TilesByPosition[5].CurrentTopGraphic.Name &&
                puzzleState.TilesByPosition[2].CurrentBottomGraphic.IsFront != puzzleState.TilesByPosition[5].CurrentTopGraphic.IsFront &&


                puzzleState.TilesByPosition[3].CurrentRightGraphic.Name == puzzleState.TilesByPosition[4].CurrentLeftGraphic.Name &&
                puzzleState.TilesByPosition[3].CurrentRightGraphic.IsFront != puzzleState.TilesByPosition[4].CurrentLeftGraphic.IsFront &&

                puzzleState.TilesByPosition[4].CurrentRightGraphic.Name == puzzleState.TilesByPosition[5].CurrentLeftGraphic.Name &&
                puzzleState.TilesByPosition[4].CurrentRightGraphic.IsFront != puzzleState.TilesByPosition[5].CurrentLeftGraphic.IsFront &&


                puzzleState.TilesByPosition[3].CurrentBottomGraphic.Name == puzzleState.TilesByPosition[6].CurrentTopGraphic.Name &&
                puzzleState.TilesByPosition[3].CurrentBottomGraphic.IsFront != puzzleState.TilesByPosition[6].CurrentTopGraphic.IsFront &&

                puzzleState.TilesByPosition[4].CurrentBottomGraphic.Name == puzzleState.TilesByPosition[7].CurrentTopGraphic.Name &&
                puzzleState.TilesByPosition[4].CurrentBottomGraphic.IsFront != puzzleState.TilesByPosition[7].CurrentTopGraphic.IsFront &&

                puzzleState.TilesByPosition[5].CurrentBottomGraphic.Name == puzzleState.TilesByPosition[8].CurrentTopGraphic.Name &&
                puzzleState.TilesByPosition[5].CurrentBottomGraphic.IsFront != puzzleState.TilesByPosition[8].CurrentTopGraphic.IsFront &&


                puzzleState.TilesByPosition[6].CurrentRightGraphic.Name == puzzleState.TilesByPosition[7].CurrentLeftGraphic.Name &&
                puzzleState.TilesByPosition[6].CurrentRightGraphic.IsFront != puzzleState.TilesByPosition[7].CurrentLeftGraphic.IsFront &&

                puzzleState.TilesByPosition[7].CurrentRightGraphic.Name == puzzleState.TilesByPosition[8].CurrentLeftGraphic.Name &&
                puzzleState.TilesByPosition[7].CurrentRightGraphic.IsFront != puzzleState.TilesByPosition[8].CurrentLeftGraphic.IsFront;

            return solved;
        }
    }
}
