using System;
using System.Threading;

namespace Gamerin
{
    public class Tetris
    {
        string heldPiece = "o";
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
            {"W", "o", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W"},
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

            switch(heldPiece)
            {
                case "l":
                case "j":
                case "t":
                case "z":
                case "s":
                case "o":
                case "none":
                    PrintSomeBoard(4, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "i":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.Cyan);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                default:
                    break;
            }
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
            switch(heldPiece)
            {
                case "none":
                    PrintSomeBoard(4, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "i":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.Cyan);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "l":
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    PrintSomeBoard(1, ConsoleColor.DarkYellow);
                    PrintSomeBoard(2, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "j":
                    PrintSomeBoard(2, ConsoleColor.DarkCyan);
                    PrintSomeBoard(1, ConsoleColor.Blue);
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "t":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.DarkMagenta);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "z":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" ");
                    PrintSomeBoard(2, ConsoleColor.Red);
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    Console.Write("  ");
                    break;
                case "s":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  ");
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    PrintSomeBoard(2, ConsoleColor.DarkGreen);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" ");
                    break;
                case "o":
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    PrintSomeBoard(2, ConsoleColor.Yellow);
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    break;
                default:
                    break;
            }
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
            switch(heldPiece)
            {
                case "none":
                    PrintSomeBoard(4, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "i":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.Cyan);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "l":
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    PrintSomeBoard(1, ConsoleColor.DarkYellow);
                    PrintSomeBoard(2, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "j":
                    PrintSomeBoard(2, ConsoleColor.DarkCyan);
                    PrintSomeBoard(1, ConsoleColor.Blue);
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "t":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" ");
                    PrintSomeBoard(3, ConsoleColor.DarkMagenta);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "z":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" ");
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    PrintSomeBoard(2, ConsoleColor.Red);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  ");
                    break;
                case "s":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  ");
                    PrintSomeBoard(2, ConsoleColor.DarkGreen);
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    Console.Write(" ");
                    break;
                case "o":
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    PrintSomeBoard(2, ConsoleColor.Yellow);
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    break;
                default:
                    break;
            }
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
            switch(heldPiece)
            {
                case "z":
                case "s":
                case "t":
                case "o":
                case "none":
                    PrintSomeBoard(4, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "i":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.Cyan);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "l":
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    PrintSomeBoard(2, ConsoleColor.DarkYellow);
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    break;
                case "j":
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    PrintSomeBoard(2, ConsoleColor.Blue);
                    PrintSomeBoard(1, ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                default:
                    break;
            }
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Rotate - Q & E    ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan);//this is where the next piece printing should go
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
            PrintSomeBoard(4, ConsoleColor.DarkCyan);//this is where the next piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(14, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan); //this is where the next piece printing should go
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
            PrintSomeBoard(4, ConsoleColor.DarkCyan); //this is where the next piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            for(int i = 40; i > 21; i--)
            {
                PrintThatLine(i);
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

        void PrintThatLine(int x)
        {
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            for(int i = 1; i < 11; i++)
            {
                switch(board[x, i])
                {
                    case " ":
                        PrintSomeBoard(1, ConsoleColor.Cyan);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "i":
                    case "if":
                        PrintSomeBoard(1, ConsoleColor.Cyan);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "j":
                    case "jf":
                        PrintSomeBoard(1, ConsoleColor.Blue);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "l":
                    case "lf":
                        PrintSomeBoard(1, ConsoleColor.DarkYellow);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "t":
                    case "tf":
                        PrintSomeBoard(1, ConsoleColor.DarkMagenta);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "o":
                    case "of":
                        PrintSomeBoard(1, ConsoleColor.Yellow);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "s":
                    case "sf":
                        PrintSomeBoard(1, ConsoleColor.DarkGreen);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "z":
                    case "zf":
                        PrintSomeBoard(1, ConsoleColor.Red);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                }
            }
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkCyan); //this is where the next piece printing should go
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