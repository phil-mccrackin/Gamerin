using System;
using System.Threading;

namespace Gamerin
{
    public class Tetris
    {
        string[,] board = new string[41, 12] {
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", "L", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", "L", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", "L", "L", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", " ", " ", "IF", " ", " ", " ", " ", "W"},
            {"W", " ", " ", " ", "JF", " ", "IF", "LF", "LF", " ", " ", "W"},
            {"W", " ", " ", " ", "JF", " ", "IF", " ", "LF", " ", " ", "W"},
            {"W", " ", " ", "JF", "JF", " ", "IF", " ", "LF", " ", " ", "W"},
            {"F", "F", "F", "F", "F", "F", "F", "F", "F", "F", "F", "F"}
        };
        
        public void TetrisIntro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Tetris!");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("If you haven't already, fullscreen your window now.");
            Console.WriteLine("Press 'e' at any time to exit. Press any key to start playing.");
            Console.ReadKey(true);

            RunTetris();
        }

        void RunTetris()
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine("");
            Console.ReadKey(true);
        }

        void PrintBoard()
        {
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("                ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            Console.Write("    ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("  TETRIS  ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
            
            PrintSomeBoard(23, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(21, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("   HOLD           ");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Move LEFT - A     ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("   NEXT           ");
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);//this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Move RIGHT - D    ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);//this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Hard Drop - W     ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);//this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Soft Drop - S     ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);//this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Rotate - Q & E    ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);//this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("                  ");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Hold - Space      ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);//this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(14, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan); //this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(12, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan); //this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            for(int i = 0; i < 20; i++)
            {
                PrintThatLine();
            }

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(12, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(6, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(21, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(23, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
        }
        void PrintSomeBoard(int blocks, ConsoleColor colour)
        {
            Console.BackgroundColor = colour;
            for(int i = 0; i < blocks; i++)
            {
                Console.Write("   ");
            }
        }

        void PrintThatLine()
        {
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(10, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan); //this is where the hold piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
        }

        void PrintBoardLine(int x)
        {
            for(int sqr = 0; sqr <= 11; sqr++)
            {
                switch(board[40 - x, sqr])
                {
                    case " ":
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black; 
                        break;
                    case "W":
                    case "F":
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("   ");
                        break;
                    case "I":
                    case "IF":
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "J":
                    case "JF":
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "L":
                    case "LF":
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                }
            }
            Console.Write("\n");
        }
    }
}