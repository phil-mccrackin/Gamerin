using System;

namespace Gamerin
{
    public class TetrisL : TetrisTetriminoManager
    {
        public string[,] Spawn(string[,] board)
        {
            pieceType = "i";
            if(board[19, 4] == "  " && board[19, 5] == "  " && board[19, 6] == "  " && board[18, 6] == "  ")
            {
                board[19, 4] = "l";
                board[19, 5] = "l";
                board[19, 6] = "l";
                board[18, 6] = "l";
            }
            else if(board[18, 4] == "  " && board[18, 5] == "  " && board[18, 6] == "  " && board[17, 6] == "  ")
            {
                board[18, 4] = "l";
                board[18, 5] = "l";
                board[18, 6] = "l";
                board[17, 6] = "l";
            }
            else
            {
                toppedOut = true;
            }
            return board;
        }
    }
}