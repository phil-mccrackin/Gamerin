using System;

namespace Gamerin
{
    public class TetrisI : TetrisTetrimino
    {
        string[,] Spawn(string[,] board)
        {
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
            return board;
        }
    }
}