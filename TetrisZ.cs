using System;

namespace Gamerin
{
    public class TetrisZ : TetrisTetriminoManager
    {
        public override string[,] Spawn(string[,] board)
        {
            pieceType = "z";
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
            return board;
        }
    }
}