using System;

namespace Gamerin
{
    public class TetrisJ : TetrisTetriminoManager
    {
        public string[,] Spawn(string[,] board)
        {
            pieceType = "j";
            if(board[18, 4] == "  " && board[19, 4] == "  " && board[19, 5] == "  " && board[19, 6] == "  ")
            {
                board[18, 4] = "j";
                board[19, 4] = "j";
                board[19, 5] = "j";
                board[19, 6] = "j";
            }
            else if(board[17, 4] == "  " && board[18, 4] == "  " && board[18, 5] == "  " && board[18, 6] == "  ")
            {
                board[17, 4] = "j";
                board[18, 4] = "j";
                board[18, 5] = "j";
                board[18, 6] = "j";
            }
            else
            {
                toppedOut = true;
            }
            return board;
        }
    }
}