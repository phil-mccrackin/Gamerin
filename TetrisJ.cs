using System;

namespace Gamerin
{
    public class TetrisJ : TetrisTetrimino
    {
        string[,] Spawn(string[,] board)
        {
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
        }
    }
}