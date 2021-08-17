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
        ConsoleKeyInfo key = new ConsoleKeyInfo();
        IDictionary<int, string> bagPieces = new Dictionary<int, string>();
        string[] pieceList = new string[]{"i", "l", "j", "s", "z", "t", "o"};
        int[] activePieceLocations = new int[8];
        string holdPiece = "i";
        bool toppedOut = false;
        bool gameOver = false;
        bool printingDone = true;
        int gravityFrequency = 1000;

        bool pieceActive = true;
        
        
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

            TetrisBagGenerator BagGenerator = new TetrisBagGenerator();

            bagPieces = BagGenerator.GenerateFirstBag(bagPieces);
            bagPieces = BagGenerator.GenerateAnotherBag(bagPieces);
            nextPiece = BagGenerator.bagNextPiece;
            SpawnPiece();

            //Timer refreshTimer = new Timer(Gravity, null, 0, gravityFrequency);

            while(toppedOut == false)
            {
                if(Console.KeyAvailable)
                {
                    key = Console.ReadKey(true);
                }

                if(printingDone)
                {
                    GameLoop(key);
                }
            }

            SpinWait.SpinUntil(() => gameOver == true);
        }
        
        void GameLoop(ConsoleKeyInfo input)
        {
            TetrisBoardPrinter LoopBoardPrinter = new TetrisBoardPrinter();
            TetrisBagGenerator LoopBagGenerator = new TetrisBagGenerator();

            if(bagPieces.Count < 7)
            {
                bagPieces = LoopBagGenerator.GenerateAnotherBag(bagPieces);
            }
            if(pieceActive == false)
            {
                SpawnPiece();
                pieceActive = true;
            }

            if(input.Key == ConsoleKey.S)
            {
                gravityFrequency = gravityFrequency / 2;
            }
            else
            {
                gravityFrequency = 1000;
            }
            Gravity();

            LoopBoardPrinter.PrintBoard(board, holdPiece);
            printingDone = true;
            Thread.Sleep(100);
        
    }
//wake
//pizza
//cry
//work
//pizza
//work
//cry
//pizza

//FREE TIME YAY

//cereal
//cry
//sleep
//cry
//cry in your sleep
//repeat
}
