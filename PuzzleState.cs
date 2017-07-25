using System;
using System.Collections.Generic;
using System.Text;

namespace ScrambleSquaresPuzzleSolver
{
    public class PuzzleState
    {
        public PuzzleState(Tile[] puzzleTiles)
        {
            Tiles = puzzleTiles;
            TilesByPosition = new Tile[puzzleTiles.Length];
        }

        public Tile[] Tiles { get; }
        public Tile[] TilesByPosition { get; }
    }
}
