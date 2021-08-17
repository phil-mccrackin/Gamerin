using System;

namespace Gamerin
{
    public class TetrisL : TetrisTetrimino
    {
        string[,] Spawn(string[,] board)
        {
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
        }
    }
}