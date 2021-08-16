using System;

namespace Gamerin
{
    public class TetrisBoardPrinter
    {
        public string[,] newBoard = new string[41, 12] {
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"W", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "W"},
            {"F", "F", "F", "F", "F", "F", "F", "F", "F", "F", "F", "F"}
        };

        string newHeldPiece;
        public void PrintBoard(string[,] newBoard, string newHeldPiece)
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

            switch(newHeldPiece)
            {
                case "l":
                case "j":
                case "t":
                case "z":
                case "s":
                case "o":
                case "none":
                    PrintSomeBoard(4, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "i":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.Cyan);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
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
            PrintSomeBoard(4, ConsoleColor.DarkGray);//This is where the next piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            switch(newHeldPiece)
            {
                case "none":
                    PrintSomeBoard(4, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "i":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.Cyan);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "l":
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    PrintSomeBoard(1, ConsoleColor.DarkYellow);
                    PrintSomeBoard(2, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "j":
                    PrintSomeBoard(2, ConsoleColor.DarkGray);
                    PrintSomeBoard(1, ConsoleColor.Blue);
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "t":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.DarkMagenta);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "z":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");
                    PrintSomeBoard(2, ConsoleColor.Red);
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    Console.Write("  ");
                    break;
                case "s":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ");
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    PrintSomeBoard(2, ConsoleColor.DarkGreen);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");
                    break;
                case "o":
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    PrintSomeBoard(2, ConsoleColor.Yellow);
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    break;
                default:
                    break;
            }
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Hard Drop - W     ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkGray);//This is where the next piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            switch(newHeldPiece)
            {
                case "none":
                    PrintSomeBoard(4, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "i":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.Cyan);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "l":
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    PrintSomeBoard(1, ConsoleColor.DarkYellow);
                    PrintSomeBoard(2, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "j":
                    PrintSomeBoard(2, ConsoleColor.DarkGray);
                    PrintSomeBoard(1, ConsoleColor.Blue);
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "t":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");
                    PrintSomeBoard(3, ConsoleColor.DarkMagenta);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "z":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    PrintSomeBoard(2, ConsoleColor.Red);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ");
                    break;
                case "s":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ");
                    PrintSomeBoard(2, ConsoleColor.DarkGreen);
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    Console.Write(" ");
                    break;
                case "o":
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    PrintSomeBoard(2, ConsoleColor.Yellow);
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    break;
                default:
                    break;
            }
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Soft Drop - S     ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkGray); //This is where the next piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            switch(newHeldPiece)
            {
                case "z":
                case "s":
                case "t":
                case "o":
                case "none":
                    PrintSomeBoard(4, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "i":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("    ");
                    PrintSomeBoard(1, ConsoleColor.Cyan);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "l":
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    PrintSomeBoard(2, ConsoleColor.DarkYellow);
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    break;
                case "j":
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    PrintSomeBoard(2, ConsoleColor.Blue);
                    PrintSomeBoard(1, ConsoleColor.DarkGray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                default:
                    break;
            }
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Rotate - Q & E    ");
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkGray);//this is where the next piece printing should go
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
            PrintSomeBoard(4, ConsoleColor.DarkGray);//this is where the next piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(14, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkGray); //this is where the next piece printing should go
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
            PrintSomeBoard(4, ConsoleColor.DarkGray); //this is where the next piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");

            for(int i = 0; i < 21; i++)
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

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
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
            PrintBoardLine(x);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(4, ConsoleColor.DarkGray); //this is where the next piece printing should go
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            PrintSomeBoard(1, ConsoleColor.DarkCyan);
            PrintSomeBoard(1, ConsoleColor.DarkBlue);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
        }
        void PrintBoardLine(int x)
        {
            for(int y = 1; y < 11; y++)
            {
                switch(newBoard[19 + x, y])
                {
                    case "  ":
                        PrintSomeBoard(1, ConsoleColor.DarkGray);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "i":
                    case "if":
                        PrintSomeBoard(1, ConsoleColor.Cyan);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "l":
                    case "lf":
                        PrintSomeBoard(1, ConsoleColor.DarkYellow);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "j":
                    case "jf":
                        PrintSomeBoard(1, ConsoleColor.Blue);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "z":
                    case "zf":
                        PrintSomeBoard(1, ConsoleColor.Red);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "s":
                    case "sf":
                        PrintSomeBoard(1, ConsoleColor.DarkGreen);
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
                }
            }
        }
    }
}