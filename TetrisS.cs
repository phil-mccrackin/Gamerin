using System;

namespace Gamerin
{
    public class TetrisS : TetrisTetrimino
    {
        string[,] Spawn(string[,] board)
        {
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
        }
    }
}