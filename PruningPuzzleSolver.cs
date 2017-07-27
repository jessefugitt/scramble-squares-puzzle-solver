using System;
using System.Collections.Generic;
using System.Text;

namespace ScrambleSquaresPuzzleSolver
{
    class PruningPuzzleSolver : PuzzleSolver
    {
        public bool IsTileAllowedAtPosition(PuzzleState puzzleState, Tile tile, int pos)
        {
            bool isAllowed = true;
            switch (pos)
            {
                case 1:
                    isAllowed =
                        puzzleState.TilesByPosition[0].CurrentRightGraphic.Name == tile.CurrentLeftGraphic.Name &&
                        puzzleState.TilesByPosition[0].CurrentRightGraphic.IsFront != tile.CurrentLeftGraphic.IsFront;
                    break;
                case 2:
                    isAllowed =
                        puzzleState.TilesByPosition[1].CurrentRightGraphic.Name == tile.CurrentLeftGraphic.Name &&
                        puzzleState.TilesByPosition[1].CurrentRightGraphic.IsFront != tile.CurrentLeftGraphic.IsFront;
                    break;
                case 3:
                    isAllowed =
                        puzzleState.TilesByPosition[0].CurrentBottomGraphic.Name == tile.CurrentTopGraphic.Name &&
                        puzzleState.TilesByPosition[0].CurrentBottomGraphic.IsFront != tile.CurrentTopGraphic.IsFront;
                    break;
                case 4:
                    isAllowed =
                        puzzleState.TilesByPosition[1].CurrentBottomGraphic.Name == tile.CurrentTopGraphic.Name &&
                        puzzleState.TilesByPosition[1].CurrentBottomGraphic.IsFront != tile.CurrentTopGraphic.IsFront &&
                        
                        puzzleState.TilesByPosition[3].CurrentRightGraphic.Name == tile.CurrentLeftGraphic.Name &&
                        puzzleState.TilesByPosition[3].CurrentRightGraphic.IsFront != tile.CurrentLeftGraphic.IsFront;
                    break;
                case 5:
                    isAllowed =
                        puzzleState.TilesByPosition[2].CurrentBottomGraphic.Name == tile.CurrentTopGraphic.Name &&
                        puzzleState.TilesByPosition[2].CurrentBottomGraphic.IsFront != tile.CurrentTopGraphic.IsFront &&

                        puzzleState.TilesByPosition[4].CurrentRightGraphic.Name == tile.CurrentLeftGraphic.Name &&
                        puzzleState.TilesByPosition[4].CurrentRightGraphic.IsFront != tile.CurrentLeftGraphic.IsFront;
                    break;
                case 6:
                    isAllowed =
                        puzzleState.TilesByPosition[3].CurrentBottomGraphic.Name == tile.CurrentTopGraphic.Name &&
                        puzzleState.TilesByPosition[3].CurrentBottomGraphic.IsFront != tile.CurrentTopGraphic.IsFront;
                    break;
                case 7:
                    isAllowed =
                        puzzleState.TilesByPosition[4].CurrentBottomGraphic.Name == tile.CurrentTopGraphic.Name &&
                        puzzleState.TilesByPosition[4].CurrentBottomGraphic.IsFront != tile.CurrentTopGraphic.IsFront &&

                        puzzleState.TilesByPosition[6].CurrentRightGraphic.Name == tile.CurrentLeftGraphic.Name &&
                        puzzleState.TilesByPosition[6].CurrentRightGraphic.IsFront != tile.CurrentLeftGraphic.IsFront;
                    break;
                case 8:
                    isAllowed =
                        puzzleState.TilesByPosition[5].CurrentBottomGraphic.Name == tile.CurrentTopGraphic.Name &&
                        puzzleState.TilesByPosition[5].CurrentBottomGraphic.IsFront != tile.CurrentTopGraphic.IsFront &&

                        puzzleState.TilesByPosition[7].CurrentRightGraphic.Name == tile.CurrentLeftGraphic.Name &&
                        puzzleState.TilesByPosition[7].CurrentRightGraphic.IsFront != tile.CurrentLeftGraphic.IsFront;
                    break;
                default:
                    break;
            }
            return isAllowed;
        }

        public override bool SolvePosition(PuzzleState puzzleState, int pos)
        {
            bool solved = false;

            for (int i = 0; i < puzzleState.Tiles.Length && !solved; i++)
            {
                Tile tile = puzzleState.Tiles[i];
                if (!tile.IsUsed)
                {
                    tile.IsUsed = true;
                    puzzleState.TilesByPosition[pos] = tile;
                    for (int r = 0; r < 4 && !solved; r++)
                    {
                        if (IsTileAllowedAtPosition(puzzleState, tile, pos))
                        {
                            if (pos == 8)
                            {
                                solved = ValidatePuzzle(puzzleState);
                            }
                            else
                            {
                                solved = SolvePosition(puzzleState, pos + 1);
                            }
                        }

                        tile.RotateClockwise();
                    }

                    if (!solved)
                    {
                        tile.Reset();
                        puzzleState.TilesByPosition[pos] = null;
                    }
                }
            }

            return solved;
        }
    }
}
