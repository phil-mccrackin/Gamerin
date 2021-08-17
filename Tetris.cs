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
        
        void SpawnPiece()
        {
            switch(nextPiece)
            {
                case "i":
                    if(board[19, 4] == "  " && board[19, 5] == "  " && board[19, 6] == "  " && board[19, 7] == "  ")
                    {
                        board[19, 4] = "i";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[19, 5] = "i";
                        activePieceLocations[2] = 19;
                        activePieceLocations[3] = 5;
                        board[19, 6] = "i";
                        activePieceLocations[4] = 19;
                        activePieceLocations[5] = 6;
                        board[19, 7] = "i";
                        activePieceLocations[6] = 19;
                        activePieceLocations[7] = 7;
                    }
                    else if(board[18, 4] == "  " && board[18, 5] == "  " && board[18, 6] == "  " && board[18, 7] == "  ")
                    {
                        board[18, 4] = "i";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[18, 5] = "i";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[18, 6] = "i";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[18, 7] = "i";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                    }
                    else
                    {
                        toppedOut = true;
                    }
                    break;
                case "l":
                    if(board[19, 4] == "  " && board[19, 5] == "  " && board[19, 6] == "  " && board[18, 6] == "  ")
                    {
                        board[19, 4] = "l";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[19, 5] = "l";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[19, 6] = "l";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[18, 6] = "l";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                    }
                    else if(board[18, 4] == "  " && board[18, 5] == "  " && board[18, 6] == "  " && board[17, 6] == "  ")
                    {
                        board[18, 4] = "l";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[18, 5] = "l";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[18, 6] = "l";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[17, 6] = "l";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                    }
                    else
                    {
                        toppedOut = true;
                    }
                    break;
                case "j":
                    if(board[18, 4] == "  " && board[19, 4] == "  " && board[19, 5] == "  " && board[19, 6] == "  ")
                    {
                        board[18, 4] = "j";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[19, 4] = "j";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[19, 5] = "j";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[19, 6] = "j";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                    }
                    else if(board[17, 4] == "  " && board[18, 4] == "  " && board[18, 5] == "  " && board[18, 6] == "  ")
                    {
                        board[17, 4] = "j";
                        activePieceLocations[0] = 19;
                        activePieceLocations[1] = 4;
                        board[18, 4] = "j";
                        
                        board[18, 5] = "j";
                        board[18, 6] = "j";
                    }
                    else
                    {
                        toppedOut = true;
                    }
                    break;
                case "s":
                    if(board[19, 4] == "  " && board[19, 5] == "  " && board[18, 5] == "  " && board[18, 6] == "  ")
                    {
                        board[19, 4] = "s";
                        board[19, 5] = "s";
                        board[18, 5] = "s";
                        board[18, 6] = "s";
                    }
                    else if(board[18, 4] == "  " && board[18, 5] == "  " && board[17, 5] == "  " && board[17, 6] == "  ")
                    {
                        board[18, 4] = "s";
                        board[18, 5] = "s";
                        board[17, 5] = "s";
                        board[17, 6] = "s";
                    }
                    else
                    {
                        toppedOut = true;
                    }
                    break;
                case "z":
                    if(board[18, 4] == "  " && board[18, 5] == "  " && board[19, 5] == "  " && board[19, 6] == "  ")
                    {
                        board[18, 4] = "z";
                        board[18, 5] = "z";
                        board[19, 5] = "z";
                        board[19, 6] = "z";
                    }
                    else if(board[17, 4] == "  " && board[17, 5] == "  " && board[18, 5] == "  " && board[18, 6] == "  ")
                    {
                        board[17, 4] = "z";
                        board[17, 5] = "z";
                        board[18, 5] = "z";
                        board[18, 6] = "z";
                    }
                    else
                    {
                        toppedOut = true;
                    }
                    break;
                case "t":
                    if(board[19, 4] == "  " && board[19, 5] == "  " && board[18, 5] == "  " && board[19, 6] == "  ")
                    {
                        board[19, 4] = "t";
                        board[19, 5] = "t";
                        board[18, 5] = "t";
                        board[19, 6] = "t";
                    }
                    else if(board[18, 4] == "  " && board[18, 5] == "  " && board[17, 5] == "  " && board[18, 6] == "  ")
                    {
                        board[18, 4] = "t";
                        board[18, 5] = "t";
                        board[17, 5] = "t";
                        board[18, 6] = "t";
                    }
                    else
                    {
                        toppedOut = true;
                    }
                    break;
                case "o":
                    if(board[19, 5] == "  " && board[19, 6] == "  " && board[18, 5] == "  " && board[18, 6] == "  ")
                    {
                        board[19, 5] = "o";
                        board[19, 6] = "o";
                        board[18, 5] = "o";
                        board[18, 6] = "o";
                    }
                    else if(board[18, 5] == "  " && board[18, 6] == "  " && board[17, 5] == "  " && board[17, 6] == "  ")
                    {
                        board[18, 5] = "o";
                        board[18, 6] = "o";
                        board[17, 5] = "o";
                        board[17, 6] = "o";
                    }
                    else
                    {
                        toppedOut = true;
                    }
                    break;
            }
        }
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
