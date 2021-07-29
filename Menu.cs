using System;
using System.Threading;
using System.Collections.Generic;

namespace Gamerin
{
    public class Menu
    {
        public static IDictionary<int, int> tailLocations = new Dictionary<int, int>();

        static Tictactoe TictactoeGame = new Tictactoe();


        static string gameInput;

        static void Main(string[] args)
        {
            Console.WriteLine("Time to do some gamerin");
            Thread.Sleep(1500);
            requestInput: gameInput = null;
            Console.Clear();
            Console.WriteLine("(Changing the size of your player window will damage the display of colours in the terminal) \n \n \n");
            Console.WriteLine("Press 'e' to exit.");
            Console.WriteLine("Select game: tictactoe - snake");

            gameInput = Console.ReadLine().ToLower();

            if(gameInput == "tictactoe")
            {
                Tictactoe.RunTictactoe();
                goto requestInput;
            }
            if(gameInput == "snake")
            {
                Snake SnakeGame = new Snake();
                tailLocations.Clear();

                Snake.SnakeIntro();
                goto requestInput;
            }
            if(gameInput == "e")
            {
                return;
            }
            else
            {
                Console.WriteLine("Thats not a game.");
                Thread.Sleep(1000);
                goto requestInput;
            }
        }
    }
}