using System;
using System.Diagnostics;

namespace ScrambleSquaresPuzzleSolver
{
    class Program
    {
        static Tile[] CreateTiles()
        {
            Graphic wolfFront = new Graphic { Name = "Wolf", IsFront = true };
            Graphic wolfBack = new Graphic { Name = "Wolf", IsFront = false };
            Graphic mooseFront = new Graphic { Name = "Moose", IsFront = true };
            Graphic mooseBack = new Graphic { Name = "Moose", IsFront = false };
            Graphic elkFront = new Graphic { Name = "Elk", IsFront = true };
            Graphic elkBack = new Graphic { Name = "Elk", IsFront = false };
            Graphic bearFront = new Graphic { Name = "Bear", IsFront = true };
            Graphic bearBack = new Graphic { Name = "Bear", IsFront = false };

            Tile[] puzzleTiles = new Tile[9];
            
            puzzleTiles[0] = new Tile(TileID.A, mooseBack, bearFront, elkBack, wolfBack);
            puzzleTiles[1] = new Tile(TileID.B, mooseBack, elkFront, wolfBack, bearFront);
            puzzleTiles[2] = new Tile(TileID.C, wolfBack, bearFront, mooseFront, elkFront);
            puzzleTiles[3] = new Tile(TileID.D, mooseFront, bearFront, wolfBack, elkBack);
            puzzleTiles[4] = new Tile(TileID.E, mooseBack, bearFront, wolfFront, elkFront);
            puzzleTiles[5] = new Tile(TileID.F, wolfBack, elkFront, mooseFront, bearBack);
            puzzleTiles[6] = new Tile(TileID.G, mooseFront, bearFront, elkFront, wolfFront);
            puzzleTiles[7] = new Tile(TileID.H, mooseFront, elkFront, bearBack, wolfFront);
            puzzleTiles[8] = new Tile(TileID.I, wolfBack, elkBack, bearBack, mooseFront);

            return puzzleTiles;
        }

        static void Main(string[] args)
        {
            Tile[] puzzleTiles = CreateTiles();
            PuzzleState puzzleState = new PuzzleState(puzzleTiles);
            PuzzleSolver puzzleSolver = new PuzzleSolver();

            Console.WriteLine("Puzzle solver started at: " + DateTime.Now);

            bool solved = puzzleSolver.Solve(puzzleState);

            Console.WriteLine("Puzzle solver finished at: " + DateTime.Now);
        }
    }
}