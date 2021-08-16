using System;
using System.Threading;
using System.Collections.Generic;

namespace Gamerin
{
    public class Tetris
    {
        string nextPiece;
        string heldPiece = "none";
        public string[,] board = new string[41, 12] {
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"F", "F", "F", "F", "F", "F", "F", "F", "F", "F", "F", "F"}
        };

        Random RNG = new Random();
        IDictionary<int, string> bagPieces = new Dictionary<int, string>();
        string[] pieceList = new string[]{"i", "l", "j", "s", "z", "t", "o"};
        
        
        public void TetrisIntro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Tetris!");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("If you haven't already, fullscreen your window now.");
            Console.WriteLine("Press any key to start playing.");
            Console.ReadKey(true);

            RunTetris();
        }

        void RunTetris()
        {
            Console.Clear();

            TetrisBoardPrinter BoardPrinter = new TetrisBoardPrinter(board, heldPiece);
            TetrisBagGenerator BagGenerator = new TetrisBagGenerator(bagPieces);

            BagGenerator.GenerateFirstBag();
            nextPiece = BagGenerator.newNextPiece;
            foreach(KeyValuePair<int, string> kvp in BagGenerator.newBagPieces)
            {
                bagPieces.Add(kvp.Key, kvp.Value);
            }

            BagGenerator.GenerateAnotherBag();
            bagPieces.Clear();
            foreach(KeyValuePair<int, string> kvp in BagGenerator.newBagPieces)
            {
                bagPieces.Add(kvp.Key, kvp.Value);
            }

            BoardPrinter.PrintBoard();

            Console.WriteLine(nextPiece);
            foreach(KeyValuePair<int, string> kvp in bagPieces)
            {
                Console.WriteLine(kvp.Value);
            }
            
            Console.WriteLine("");
            Console.ReadKey(true);
        }
        
        
    }
}