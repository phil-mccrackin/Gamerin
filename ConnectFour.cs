using System;

namespace Gamerin
{
    public class ConnectFour
    {
        string[,] board = new string[,]{
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", "R", " ", " "},
            {" ", " ", " ", "Y", "R", " ", " "},
            {" ", " ", "Y", "R", "Y", " ", " "}
        };

        public void ConnectFourIntro()
        {
            PrintBoard();

            Console.ReadKey(false);
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