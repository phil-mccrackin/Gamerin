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

        ConsoleKeyInfo key = new ConsoleKeyInfo();
        List<string> bagPieces = new List<string>();
        string holdPiece = "none";
        bool toppedOut = false;
        bool gameOver = false;
        bool printingDone = true;
        bool frameGravity = false;
        bool pieceActive = false;
        int gravityFrequency = 1000;

        


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

            Timer gravityTimer = new Timer(GravityCallback, null, 0, gravityFrequency);

            while(toppedOut == false)
            {
                if(Console.KeyAvailable)
                {
                    key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.E)
                    {
                        frameGravity = true;
                    }
                }
                if(printingDone)
                {
                    GameLoop(key);
                }
            }
            SpinWait.SpinUntil(() => gameOver == true);
        }
        void GravityCallback(object state)
        {
            Gravity();
        }
        void Gravity()
        {
            for(int x = 0; x < 41; x++)
            {
                for(int y = 0; y < 12; y++)
                {
                    if(board[x, y] == "i" || board[x, y] == "l" || board[x, y] == "j" || board[x, y] == "s" || board[x, y] == "z" || board[x, y] == "t" || board[x, y] == "o")
                    {
                        if((board[x + 1, y].Length == 2 && board[x + 1, y] != "  ") || board[x + 1, y] == "F")
                        {
                            switch(board[x, y])
                            {
                                case "i":
                                    board[iTopPieceLocations[0], iTopPieceLocations[1]] = "if";
                                    board[iTopMiddlePieceLocations[0], iTopMiddlePieceLocations[1]] = "if";
                                    board[iBottomMiddlePieceLocations[0], iBottomMiddlePieceLocations[1]] = "if";
                                    board[iBottomPieceLocations[0], iBottomPieceLocations[1]] = "if";

                                    iTopPieceLocations[0] = -1;
                                    iTopPieceLocations[1] = -1;
                                    iTopMiddlePieceLocations[0] = -1;
                                    iTopMiddlePieceLocations[1] = -1;
                                    iBottomMiddlePieceLocations[0] = -1;
                                    iBottomMiddlePieceLocations[1] = -1;
                                    iBottomPieceLocations[0] = -1;
                                    iBottomPieceLocations[1] = -1;

                                    pieceActive = false;
                                    break;
                                case "l":
                                    board[lTopLeftPieceLocations[0], lTopLeftPieceLocations[1]] = "lf";
                                    board[lMiddleLeftPieceLocations[0], lMiddleLeftPieceLocations[1]] = "lf";
                                    board[lBottomLeftPieceLocations[0], lBottomLeftPieceLocations[1]] = "lf";
                                    board[lBottomRightPieceLocations[0], lBottomRightPieceLocations[1]] = "lf";
                                    
                                    lTopLeftPieceLocations[0] = -1;
                                    lTopLeftPieceLocations[1] = -1;
                                    lMiddleLeftPieceLocations[0] = -1;
                                    lMiddleLeftPieceLocations[1] = -1;
                                    lBottomLeftPieceLocations[0] = -1;
                                    lBottomLeftPieceLocations[1] = -1;
                                    lBottomRightPieceLocations[0] = -1;
                                    lBottomRightPieceLocations[1] = -1;

                                    pieceActive = false;
                                    break;
                                case "j":
                                    board[jTopRightPieceLocations[0], jTopRightPieceLocations[1]] = "jf";
                                    board[jMiddleRightPieceLocations[0], jMiddleRightPieceLocations[1]] = "jf";
                                    board[jBottomLeftPieceLocations[0], jBottomLeftPieceLocations[1]] = "jf";
                                    board[jBottomRightPieceLocations[0], jBottomRightPieceLocations[1]] = "jf";
                                    
                                    jTopRightPieceLocations[0] = -1;
                                    jTopRightPieceLocations[1] = -1;
                                    jMiddleRightPieceLocations[0] = -1;
                                    jMiddleRightPieceLocations[1] = -1;
                                    jBottomLeftPieceLocations[0] = -1;
                                    jBottomLeftPieceLocations[1] = -1;
                                    jBottomRightPieceLocations[0] = -1;
                                    jBottomRightPieceLocations[1] = -1;

                                    pieceActive = false;
                                    break;
                                case "s":
                                    board[sTopRightPieceLocations[0], sTopRightPieceLocations[1]] = "sf";
                                    board[sTopMiddlePieceLocations[0], sTopMiddlePieceLocations[1]] = "sf";
                                    board[sBottomLeftPieceLocations[0], sBottomLeftPieceLocations[1]] = "sf";
                                    board[sBottomMiddlePieceLocations[0], sBottomMiddlePieceLocations[1]] = "sf";
                                    
                                    sTopRightPieceLocations[0] = -1;
                                    sTopRightPieceLocations[1] = -1;
                                    sTopMiddlePieceLocations[0] = -1;
                                    sTopMiddlePieceLocations[1] = -1;
                                    sBottomLeftPieceLocations[0] = -1;
                                    sBottomLeftPieceLocations[1] = -1;
                                    sBottomMiddlePieceLocations[0] = -1;
                                    sBottomMiddlePieceLocations[1] = -1;

                                    pieceActive = false;
                                    break;
                                case "z":
                                    board[zTopLeftPieceLocations[0], zTopLeftPieceLocations[1]] = "zf";
                                    board[zTopMiddlePieceLocations[0], zTopMiddlePieceLocations[1]] = "zf";
                                    board[zBottomRightPieceLocations[0], zBottomRightPieceLocations[1]] = "zf";
                                    board[zBottomMiddlePieceLocations[0], zBottomMiddlePieceLocations[1]] = "zf";
                                    
                                    zTopLeftPieceLocations[0] = -1;
                                    zTopLeftPieceLocations[1] = -1;
                                    zTopMiddlePieceLocations[0] = -1;
                                    zTopMiddlePieceLocations[1] = -1;
                                    zBottomRightPieceLocations[0] = -1;
                                    zBottomRightPieceLocations[1] = -1;
                                    zBottomMiddlePieceLocations[0] = -1;
                                    zBottomMiddlePieceLocations[1] = -1;

                                    pieceActive = false;
                                    break;
                                case "t":
                                    board[tLeftEdgeLocations[0], tLeftEdgeLocations[1]] = "zf";
                                    board[tRightEdgeLocations[0], tRightEdgeLocations[1]] = "zf";
                                    board[tTopEdgeLocations[0], tTopEdgeLocations[1]] = "zf";
                                    board[tCenterPieceLocations[0], tCenterPieceLocations[1]] = "zf";
                                    
                                    tLeftEdgeLocations[0] = -1;
                                    tLeftEdgeLocations[1] = -1;
                                    tRightEdgeLocations[0] = -1;
                                    tRightEdgeLocations[1] = -1;
                                    tTopEdgeLocations[0] = -1;
                                    tTopEdgeLocations[1] = -1;
                                    tCenterPieceLocations[0] = -1;
                                    tCenterPieceLocations[1] = -1;

                                    pieceActive = false;
                                    break;
                                case "o":
                                    board[oTopRightCornerLocations[0], oTopRightCornerLocations[1]] = "zf";
                                    board[oTopLeftCornerLocations[0], oTopLeftCornerLocations[1]] = "zf";
                                    board[oBottomRightLocations[0], oBottomRightLocations[1]] = "zf";
                                    board[oBottomLeftLocations[0], oBottomLeftLocations[1]] = "zf";
                                    
                                    oTopRightCornerLocations[0] = -1;
                                    oTopRightCornerLocations[1] = -1;
                                    oTopLeftCornerLocations[0] = -1;
                                    oTopLeftCornerLocations[1] = -1;
                                    oBottomRightLocations[0] = -1;
                                    oBottomLeftLocations[1] = -1;
                                    oBottomLeftLocations[0] = -1;
                                    oBottomLeftLocations[1] = -1;

                                    pieceActive = false;
                                    break;
                            }
                        }
                        else
                        {
                            switch(board[x, y])
                            {
                                case "i":
                                    if(iTopPieceLocations[0] == x && iTopPieceLocations[1] == y)
                                    {
                                        iTopPieceLocations[0] += 1;
                                    }
                                    else if(iTopMiddlePieceLocations[0] == x && iTopMiddlePieceLocations[1] == y)
                                    {
                                        iTopMiddlePieceLocations[0] += 1;
                                    }
                                    else if(iBottomMiddlePieceLocations[0] == x && iBottomMiddlePieceLocations[1] == y)
                                    {
                                        iBottomMiddlePieceLocations[0] += 1;
                                    }
                                    else if(iBottomPieceLocations[0] == x && iBottomPieceLocations[1] == y)
                                    {
                                        iBottomPieceLocations[0] += 1;
                                    }
                                    break;
                                case "l":
                                    if(lTopLeftPieceLocations[0] == x && lTopLeftPieceLocations[1] == y)
                                    {
                                        lTopLeftPieceLocations[0] += 1;
                                    }
                                    else if(lMiddleLeftPieceLocations[0] == x && lMiddleLeftPieceLocations[1] == y)
                                    {
                                        lMiddleLeftPieceLocations[0] += 1;
                                    }
                                    else if(lBottomLeftPieceLocations[0] == x && lBottomLeftPieceLocations[1] == y)
                                    {
                                        lBottomLeftPieceLocations[0] += 1;
                                    }
                                    else if(lBottomRightPieceLocations[0] == x && lBottomRightPieceLocations[1] == y)
                                    {
                                        lBottomRightPieceLocations[0] += 1;
                                    }
                                    break;
                                case "j":
                                    if(jTopRightPieceLocations[0] == x && jTopRightPieceLocations[1] == y)
                                    {
                                        jTopRightPieceLocations[0] += 1;
                                    }
                                    else if(jMiddleRightPieceLocations[0] == x && jMiddleRightPieceLocations[1] == y)
                                    {
                                        jMiddleRightPieceLocations[0] += 1;
                                    }
                                    else if(jBottomRightPieceLocations[0] == x && jBottomRightPieceLocations[1] == y)
                                    {
                                        jBottomRightPieceLocations[0] += 1;
                                    }
                                    else if(jBottomLeftPieceLocations[0] == x && jBottomLeftPieceLocations[1] == y)
                                    {
                                        jBottomLeftPieceLocations[0] += 1;
                                    }
                                    break;
                                case "s":
                                    if(sTopRightPieceLocations[0] == x && sTopRightPieceLocations[1] == y)
                                    {
                                        sTopRightPieceLocations[0] += 1;
                                    }
                                    else if(sTopMiddlePieceLocations[0] == x && sTopMiddlePieceLocations[1] == y)
                                    {
                                        sTopMiddlePieceLocations[0] += 1;
                                    }
                                    else if(sBottomMiddlePieceLocations[0] == x && sBottomMiddlePieceLocations[1] == y)
                                    {
                                        sBottomMiddlePieceLocations[0] += 1;
                                    }
                                    else if(sBottomLeftPieceLocations[0] == x && sBottomLeftPieceLocations[1] == y)
                                    {
                                        sBottomLeftPieceLocations[0] += 1;
                                    }
                                    break;
                                case "z":
                                    if(zTopLeftPieceLocations[0] == x && zTopLeftPieceLocations[1] == y)
                                    {
                                        zTopLeftPieceLocations[0] += 1;
                                    }
                                    else if(zTopMiddlePieceLocations[0] == x && zTopMiddlePieceLocations[1] == y)
                                    {
                                        zTopMiddlePieceLocations[0] += 1;
                                    }
                                    else if(zBottomMiddlePieceLocations[0] == x && zBottomMiddlePieceLocations[1] == y)
                                    {
                                        zBottomMiddlePieceLocations[0] += 1;
                                    }
                                    else if(zBottomRightPieceLocations[0] == x && zBottomRightPieceLocations[1] == y)
                                    {
                                        zBottomRightPieceLocations[0] += 1;
                                    }
                                    break;
                                case "t":
                                    if(tLeftEdgeLocations[0] == x && tLeftEdgeLocations[1] == y)
                                    {
                                        tLeftEdgeLocations[0] += 1;
                                    }
                                    else if(tTopEdgeLocations[0] == x && tTopEdgeLocations[1] == y)
                                    {
                                        tTopEdgeLocations[0] += 1;
                                    }
                                    else if(tRightEdgeLocations[0] == x && tRightEdgeLocations[1] == y)
                                    {
                                        tRightEdgeLocations[0] += 1;
                                    }
                                    else if(tCenterPieceLocations[0] == x && tCenterPieceLocations[1] == y)
                                    {
                                        tCenterPieceLocations[0] += 1;
                                    }
                                    break;
                                case "o":
                                    if(oTopLeftCornerLocations[0] == x && oTopLeftCornerLocations[1] == y)
                                    {
                                        oTopLeftCornerLocations[0] += 1;
                                    }
                                    else if(oTopRightCornerLocations[0] == x && oTopRightCornerLocations[1] == y)
                                    {
                                        oTopRightCornerLocations[0] += 1;
                                    }
                                    else if(oBottomLeftLocations[0] == x && oBottomLeftLocations[1] == y)
                                    {
                                        oBottomLeftLocations[0] += 1;
                                    }
                                    else if(oBottomRightLocations[0] == x && oBottomRightLocations[1] == y)
                                    {
                                        oBottomRightLocations[0] += 1;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            RefreshLocations();
        }
        
        void RefreshLocations()
        {
            for(int x = 0; x < 41; x++)
            {
                for(int y = 0; y < 12; y++)
                {
                    if(board[x, y].Length == 1 && board[x, y] != "W" && board[x, y] != "F")
                    {
                        board[x, y] = "  ";
                    }
                }
            }
            try
            {
                board[oBottomLeftLocations[0], oBottomLeftLocations[1]] = "o";
                board[oBottomRightLocations[0], oBottomRightLocations[1]] = "o";
                board[oTopLeftCornerLocations[0], oTopLeftCornerLocations[1]] = "o";
                board[oTopRightCornerLocations[0], oTopRightCornerLocations[1]] = "o";
            }
            catch(IndexOutOfRangeException)
            {

            }
            try
            {
                board[tCenterPieceLocations[0], tCenterPieceLocations[1]] = "t";
                board[tLeftEdgeLocations[0], tLeftEdgeLocations[1]] = "t";
                board[tRightEdgeLocations[0], tRightEdgeLocations[1]] = "t";;
                board[tTopEdgeLocations[0], tTopEdgeLocations[1]] = "t";
            }
            catch(IndexOutOfRangeException)
            {
                
            }
            try
            {
                board[lTopLeftPieceLocations[0], lTopLeftPieceLocations[1]] = "l";
                board[lMiddleLeftPieceLocations[0], lMiddleLeftPieceLocations[1]] = "l";
                board[lBottomLeftPieceLocations[0], lBottomLeftPieceLocations[1]] = "l";
                board[lBottomRightPieceLocations[0], lBottomRightPieceLocations[1]] = "l";
            }
            catch(IndexOutOfRangeException)
            {

            }
            try
            {
                board[iTopPieceLocations[0], iTopPieceLocations[1]] = "i";
                board[iTopMiddlePieceLocations[0], iTopMiddlePieceLocations[1]] = "i";
                board[iBottomMiddlePieceLocations[0], iBottomMiddlePieceLocations[1]] = "i";
                board[iBottomPieceLocations[0], iBottomPieceLocations[1]] = "i";
            }
            catch(IndexOutOfRangeException)
            {

            }
            try
            {
                board[jTopRightPieceLocations[0], jTopRightPieceLocations[1]] = "j";
                board[jMiddleRightPieceLocations[0], jMiddleRightPieceLocations[1]] = "j";
                board[jBottomLeftPieceLocations[0], jBottomLeftPieceLocations[1]] = "j";
                board[jBottomRightPieceLocations[0], jBottomRightPieceLocations[1]] = "j";
            }
            catch(IndexOutOfRangeException)
            {

            }
            try
            {
                board[sTopRightPieceLocations[0], sTopRightPieceLocations[1]] = "s";
                board[sBottomMiddlePieceLocations[0], sBottomMiddlePieceLocations[1]] = "s";
                board[sBottomLeftPieceLocations[0], sBottomLeftPieceLocations[1]] = "s";
                board[sTopMiddlePieceLocations[0], sTopMiddlePieceLocations[1]] = "s";
            }
            catch(IndexOutOfRangeException)
            {
                
            }
            try
            {
                board[zTopLeftPieceLocations[0], zTopLeftPieceLocations[1]] = "z";
                board[zBottomMiddlePieceLocations[0], zBottomMiddlePieceLocations[1]] = "z";
                board[zBottomRightPieceLocations[0], zBottomRightPieceLocations[1]] = "z";
                board[zTopMiddlePieceLocations[0], zTopMiddlePieceLocations[1]] = "z";
            }
            catch(IndexOutOfRangeException)
            {
                
            }

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
                        if(board[18, 4] == "j")
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
                        else if(board[17, 4] == "j")
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
                            tCenterPieceLocations[1] = 5;

                            tRightEdgeLocations[0] = 19;
                            tRightEdgeLocations[1] = 6;

                            tTopEdgeLocations[0] = 18;
                            tTopEdgeLocations[1] = 5;
                        }
                        else if(board[18, 4] == "t")
                        {
                            tLeftEdgeLocations[0] = 18;
                            tLeftEdgeLocations[1] = 4;

                            tCenterPieceLocations[0] = 18;
                            tCenterPieceLocations[1] = 5;

                            tRightEdgeLocations[0] = 18;
                            tRightEdgeLocations[1] = 6;

                            tTopEdgeLocations[0] = 17;
                            tTopEdgeLocations[1] = 5;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                    case "o":
                        new TetrisO().Spawn(board);
                        if(board[19, 5] == "o")
                        {
                            oTopLeftCornerLocations[0] = 18;
                            oTopLeftCornerLocations[1] = 5;

                            oTopRightCornerLocations[0] = 18;
                            oTopRightCornerLocations[1] = 6;

                            oBottomLeftLocations[0] = 19;
                            oBottomLeftLocations[1] = 5;
                            
                            oBottomRightLocations[0] = 19;
                            oBottomRightLocations[1] = 6;
                        }
                        else if(board[18, 5] == "o")
                        {
                            oTopLeftCornerLocations[0] = 17;
                            oTopLeftCornerLocations[1] = 5;

                            oTopRightCornerLocations[0] = 17;
                            oTopRightCornerLocations[1] = 6;

                            oBottomLeftLocations[0] = 18;
                            oBottomLeftLocations[1] = 5;
                            
                            oBottomRightLocations[0] = 18;
                            oBottomRightLocations[1] = 6;
                        }
                        nextPiece = bagPieces[0];
                        bagPieces.RemoveAt(0);
                        break;
                }
                pieceActive = true;
            }

            if(frameGravity)
            {
                Gravity();
            }
        
            holdPiece = nextPiece;
            RefreshLocations();
            LoopBoardPrinter.PrintBoard(board, holdPiece);
            printingDone = true;
            frameGravity = false;
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
