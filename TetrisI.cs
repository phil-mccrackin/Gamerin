using System;

namespace Gamerin
{
    public class TetrisI : TetrisTetriminoManager
    {
        public override string[,] Spawn(string[,] board)
        {
            pieceType = "i";
            if(board[19, 4] == "  " && board[19, 5] == "  " && board[19, 6] == "  " && board[19, 7] == "  ")
            {
                board[19, 4] = "i";
                board[19, 5] = "i";
                board[19, 6] = "i";
                board[19, 7] = "i";
            }
            else if(board[18, 4] == "  " && board[18, 5] == "  " && board[18, 6] == "  " && board[18, 7] == "  ")
            {
                board[18, 4] = "i";
                board[18, 5] = "i";
                board[18, 6] = "i";
                board[18, 7] = "i";
            }
            else
            {
                toppedOut = true;
            }
            return board;
        }
    }
}