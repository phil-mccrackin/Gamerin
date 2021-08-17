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
        List<string> bagPieces = new List<string>();
        string[] pieceList = new string[]{"i", "l", "j", "s", "z", "t", "o"};
        string holdPiece = "none";
        bool toppedOut = false;
        bool gameOver = false;
        bool printingDone = true;
        int gravityFrequency = 1000;

        bool pieceActive = false;


        //t piece locations
        int[] tCenterPieceLocations = new int[2];
        int[] tLeftEdgeLocations = new int[2];
        int[] tRightEdgeLocations = new int[2];
        int[] tTopEdgeLocations = new int[2];
        
        //o piece locations
        int[] oTopRightCornerLocations = new int[2];
        int[] oTopLeftCornerLocations = new int[2];
        int[] oBottomRightLocations = new int[2];
        int[] oBottomLeftLocations = new int[2];

        //i piece locations
        int[] iTopPieceLocations = new int[2];
        int[] iTopMiddlePieceLocations = new int[2];
        int[] iBottomMiddlePieceLocations = new int[2];
        int[] iBottomPieceLocations = new int[2];

        //s piece locations
        int[] sBottomLeftPieceLocations = new int[2];
        int[] sBottomMiddlePieceLocations = new int[2];
        int[] sTopMiddlePieceLocations = new int[2];
        int[] sTopRightPieceLocations = new int[2];

        //z piece locations
        int[] zTopLeftPieceLocations = new int[2];
        int[] zTopMiddlePieceLocations = new int[2];
        int[] zBottomMiddlePieceLocations = new int[2];
        int[] zBottomRightPieceLocations = new int[2];

        //l piece locations
        int[] lTopLeftPieceLocations = new int[2];
        int[] lMiddleLeftPieceLocations = new int[2];
        int[] lBottomLeftPieceLocations = new int[2];
        int[] lBottomRightPieceLocations = new int[2];

        //j piece locations
        int[] jTopRightPieceLocations = new int[2];
        int[] jMiddleRightPieceLocations = new int[2];
        int[] jBottomRightPieceLocations = new int[2];
        int[] jBottomLeftPieceLocations = new int[2];


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
                switch(nextPiece)
                {
                    case "i":
                        new TetrisI().Spawn(board);
                        if(board[19, 4] == "i")
                        {
                            iTopPieceLocations[0] = 19;
                            iTopPieceLocations[1] = 4;

                            iTopMiddlePieceLocations[0] = 19;
                            iTopMiddlePieceLocations[1] = 5;

                            iBottomMiddlePieceLocations[0] = 19;
                            iBottomMiddlePieceLocations[1] = 6;
                            
                            iBottomPieceLocations[0] = 19;
                            iBottomPieceLocations[1] = 7;
                        }
                        else if(board[18, 4] == "i")
                        {
                            iTopPieceLocations[0] = 18;
                            iTopPieceLocations[1] = 4;

                            iTopMiddlePieceLocations[0] = 18;
                            iTopMiddlePieceLocations[1] = 5;

                            iBottomMiddlePieceLocations[0] = 18;
                            iBottomMiddlePieceLocations[1] = 6;
                            
                            iBottomPieceLocations[0] = 18;
                            iBottomPieceLocations[1] = 7;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                    case "l":
                        new TetrisL().Spawn(board);
                        if(board[19, 4] == "l")
                        {
                            lTopLeftPieceLocations[0] = 19;
                            lTopLeftPieceLocations[1] = 4;

                            lMiddleLeftPieceLocations[0] = 19;
                            lMiddleLeftPieceLocations[1] = 5;

                            lBottomLeftPieceLocations[0] = 19;
                            lBottomLeftPieceLocations[1] = 6;

                            lBottomRightPieceLocations[0] = 18;
                            lBottomRightPieceLocations[1] = 6;
                        }
                        else if(board[18, 4] == "l")
                        {
                            lTopLeftPieceLocations[0] = 18;
                            lTopLeftPieceLocations[1] = 4;

                            lMiddleLeftPieceLocations[0] = 18;
                            lMiddleLeftPieceLocations[1] = 5;

                            lBottomLeftPieceLocations[0] = 18;
                            lBottomLeftPieceLocations[1] = 6;

                            lBottomRightPieceLocations[0] = 17;
                            lBottomRightPieceLocations[1] = 6;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                    case "j":
                        new TetrisJ().Spawn(board);
                        if(board[18, 4] == "l")
                        {
                            jBottomLeftPieceLocations[0] = 18;
                            jBottomLeftPieceLocations[1] = 4;

                            jBottomRightPieceLocations[0] = 19;
                            jBottomRightPieceLocations[1] = 4;

                            jMiddleRightPieceLocations[0] = 19;
                            jMiddleRightPieceLocations[1] = 5;

                            jTopRightPieceLocations[0] = 19;
                            jTopRightPieceLocations[1] = 6;
                        }
                        else if(board[17, 4] == "l")
                        {
                            jBottomLeftPieceLocations[0] = 17;
                            jBottomLeftPieceLocations[1] = 4;

                            jBottomRightPieceLocations[0] = 18;
                            jBottomRightPieceLocations[1] = 4;

                            jMiddleRightPieceLocations[0] = 18;
                            jMiddleRightPieceLocations[1] = 5;

                            jTopRightPieceLocations[0] = 18;
                            jTopRightPieceLocations[1] = 6;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                    case "s":
                        new TetrisS().Spawn(board);
                        if(board[19, 4] == "s")
                        {
                            sBottomLeftPieceLocations[0] = 19;
                            sBottomLeftPieceLocations[1] = 4;

                            sBottomMiddlePieceLocations[0] = 19;
                            sBottomMiddlePieceLocations[1] = 5;

                            sTopMiddlePieceLocations[0] = 18;
                            sTopMiddlePieceLocations[1] = 5;

                            sTopRightPieceLocations[0] = 18;
                            sTopRightPieceLocations[1] = 6;
                        }
                        else if(board[18, 4] == "s")
                        {
                            sBottomLeftPieceLocations[0] = 18;
                            sBottomLeftPieceLocations[1] = 4;

                            sBottomMiddlePieceLocations[0] = 18;
                            sBottomMiddlePieceLocations[1] = 5;

                            sTopMiddlePieceLocations[0] = 17;
                            sTopMiddlePieceLocations[1] = 5;

                            sTopRightPieceLocations[0] = 17;
                            sTopRightPieceLocations[1] = 6;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                    case "z":
                        new TetrisZ().Spawn(board);
                        if(board[18, 4] == "z")
                        {
                            zTopLeftPieceLocations[0] = 18;
                            zTopLeftPieceLocations[1] = 4;

                            zTopMiddlePieceLocations[0] = 18;
                            zTopMiddlePieceLocations[1] = 5;

                            zBottomMiddlePieceLocations[0] = 19;
                            zBottomMiddlePieceLocations[1] = 5;

                            zBottomRightPieceLocations[0] = 19;
                            zBottomRightPieceLocations[1] = 6;
                        }
                        else if(board[17, 4] == "z")
                        {
                            zTopLeftPieceLocations[0] = 17;
                            zTopLeftPieceLocations[1] = 4;

                            zTopMiddlePieceLocations[0] = 17;
                            zTopMiddlePieceLocations[1] = 5;

                            zBottomMiddlePieceLocations[0] = 18;
                            zBottomMiddlePieceLocations[1] = 5;

                            zBottomRightPieceLocations[0] = 18;
                            zBottomRightPieceLocations[1] = 6;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                    case "t":
                        new TetrisT().Spawn(board);
                        if(board[19, 4] == "t")
                        {
                            tLeftEdgeLocations[0] = 19;
                            tLeftEdgeLocations[1] = 4;

                            tCenterPieceLocations[0] = 19;
                            tCenterPieceLocations[0] = 5;

                            tRightEdgeLocations[0] = 19;
                            tRightEdgeLocations[1] = 4;

                            tTopEdgeLocations[0] = 18;
                            tTopEdgeLocations[0] = 5;
                        }
                        else if(board[18, 4] == "t")
                        {
                            tLeftEdgeLocations[0] = 18;
                            tLeftEdgeLocations[1] = 4;

                            tCenterPieceLocations[0] = 18;
                            tCenterPieceLocations[0] = 5;

                            tRightEdgeLocations[0] = 18;
                            tRightEdgeLocations[1] = 4;

                            tTopEdgeLocations[0] = 17;
                            tTopEdgeLocations[0] = 5;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                    case "o":
                        new TetrisO().Spawn(board);
                        if(board[19, 5] == "o")
                        {
                            oTopLeftCornerLocations[0] = 19;
                            oTopLeftCornerLocations[1] = 5;

                            oTopRightCornerLocations[0] = 19;
                            oTopRightCornerLocations[1] = 6;

                            oBottomLeftLocations[0] = 18;
                            oBottomLeftLocations[1] = 5;
                            
                            oBottomRightLocations[0] = 18;
                            oBottomRightLocations[1] = 6;
                        }
                        else if(board[18, 5] == "o")
                        {
                            oTopLeftCornerLocations[0] = 18;
                            oTopLeftCornerLocations[1] = 5;

                            oTopRightCornerLocations[0] = 18;
                            oTopRightCornerLocations[1] = 6;

                            oBottomLeftLocations[0] = 17;
                            oBottomLeftLocations[1] = 5;
                            
                            oBottomRightLocations[0] = 17;
                            oBottomRightLocations[1] = 6;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                }
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

            LoopBoardPrinter.PrintBoard(board, holdPiece);
            printingDone = true;
            Thread.Sleep(200);
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
