using System;

namespace Gamerin
{
    public abstract class TetrisTetriminoManager
    {
        public string pieceType;
        public bool pieceActive = false;
        public bool toppedOut = false;

        public abstract string[,] Spawn(string[,] board);

        public string[,] Lock(string[,] board)
        {
            for(int x = 0; x < 41; x++)
            {
                for(int y = 0; y < 12; y++)
                {
                    if(board[x, y] == pieceType)
                    {
                        board[x, y] = pieceType + "f";
                    }
                }
            }
            pieceActive = false;
            return board;
        }
    }
}