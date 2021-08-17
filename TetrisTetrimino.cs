using System;

namespace Gamerin
{
    public class TetrisTetrimino
    {
        string pieceType;
        
        string[,] Lock(string[,] board)
        {
            for(int x = 0; x < 41; x++)
            {
                for(int y = 0; y < 12; y++)
                {
                    if(board[x, y] == pieceType)
                    {
                        board[x, y] == pieceType + "f";
                    }
                }
            }
            this.Dispose();
        }
    }
}