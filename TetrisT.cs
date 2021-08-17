using System;

namespace Gamerin
{
    public class TetrisT : TetrisTetriminoManager
    {
        public string[,] Spawn(string[,] board)
        {
            pieceType = "t";
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
            return board;
        }
    }
}