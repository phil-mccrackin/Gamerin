using System;
using System.Threading;

namespace Gamerin
{
    public class Menu
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Time to do some gamerin");
            Thread.Sleep(1500);
            requestInput: string gameInput;
            Console.Clear();
            Console.WriteLine("(Changing the size of your player window will damage the display of colours in the terminal) \n \n \n");
            Console.WriteLine("Press 'e' to exit.");
            Console.WriteLine("Select game: Tictactoe - Connect Four - Snake - Tetris");

            gameInput = Console.ReadLine().ToLower();

            if(gameInput == "tictactoe")
            {
                Tictactoe TictactoeGame = new Tictactoe();
                TictactoeGame.RunTictactoe();
                goto requestInput;
            }
            else if(gameInput == "connectfour" || gameInput == "connect four" || gameInput == "connect4" || gameInput == "connect 4")
            {
                ConnectFour ConnectFourGame = new ConnectFour();
                ConnectFourGame.ConnectFourIntro();
                goto requestInput;
            }
            else if(gameInput == "snake")
            {
                Snake SnakeGame = new Snake();
                SnakeGame.SnakeIntro();
                goto requestInput;
            }
            else if(gameInput == "tetris")
            {
                Tetris TetrisGame = new Tetris();
                TetrisGame.TetrisIntro();
                goto requestInput;
            }
            else if(gameInput == "e")
            {
                return;
            }
            else
            {
                Thread.Sleep(1000);
                goto requestInput;
            }
        }
    }
}