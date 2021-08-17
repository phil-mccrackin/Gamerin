using System;

namespace Gamerin
{
    public class TetrisO : TetrisTetriminoManager
    {
        public override string[,] Spawn(string[,] board)
        {
            pieceType = "o";
            if(board[19, 5] == "  " && board[19, 6] == "  " && board[18, 5] == "  " && board[18, 6] == "  ")
            {
                board[19, 5] = "o";
                board[19, 6] = "o";
                board[18, 5] = "o";
                board[18, 6] = "o";
            }
            else if(board[18, 5] == "  " && board[18, 6] == "  " && board[17, 5] == "  " && board[17, 6] == "  ")
            {
                board[18, 5] = "o";
                board[18, 6] = "o";
                board[17, 5] = "o";
                board[17, 6] = "o";
            }
            else
            {
                toppedOut = true;
            }
            return board;
        }
    }
}