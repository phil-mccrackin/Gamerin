using System;
using System.Threading;

namespace Gamerin
{
    public class ConnectFour
    {
        string[,] board = new string[,]{
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", " ", " ", " "}
        };

        public void ConnectFourIntro()
        {
            Console.WriteLine("Welcome to Connect Four!");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("Enter the column (from left to right 1-7) you would like to place your piece in to play");
            Console.WriteLine("Press 'e' at any time to return to the menu. Press any key to start playing.");

            Console.ReadKey(true);

            RunConnectFour();
        }

        void RunConnectFour()
        {
            for(int i = 0; i < 42; i++)
            {
                PrintBoard();

                int columnInput;
                bool canPlace;
                requestInput: string userInput = Console.ReadKey(true).Key.ToString();
                
                if(Int32.TryParse(userInput, out columnInput))
                {
                    columnInput = Int32.Parse(userInput);
                }
                else
                {
                    goto requestInput;
                }
                if(columnInput < 1 || columnInput > 7)
                {
                    goto requestInput;
                }
                for(int i = 0; i < 6; i++)
                {
                    if(board[i, columnInput] != " ")
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        void PrintBoard()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("                                     ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            for(int i = 0; i < 6; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                for(int j = 0; j < 7; j++)
                {
                    switch(board[i, j])
                    {
                        case "R":
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" {board[i, j]} ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case "Y":
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {board[i, j]} ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case " ":
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write($" {board[i, j]} ");
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        default:
                            break;
                    }
                }
                Console.Write("\n");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("                                     ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
            }
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("                     ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("     \n");

            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("                 ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  \n");
        }
    }
}