using System;
using System.Threading;

namespace Gamerin
{
    public class ConnectFour
    {
        string currentPlayer = "Yellow";
        string hasWon = "none";
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
            Console.Clear();
            Console.WriteLine("Welcome to Connect Four!");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("Enter the column (from left to right 1-7) you would like to place your piece in to play.");
            Console.WriteLine("Press 'e' at any time to return to the menu. Press any key to start playing.");

            Console.ReadKey(true);

            RunConnectFour();
        }

        void RunConnectFour()
        {
            for(int i = 0; i < 42; i++)
            {
                PrintBoard();
                Console.Write($"{currentPlayer}: ");

                requestInput: 
                int columnInput;
                bool placeFound = false;
                bool columnFull = false;
                string pieceX = " ";
                string pieceY = " ";

                string userInput = Console.ReadLine().ToString();
                Console.Write("\n");
                
                if(userInput.ToLower() == "e")
                {
                    return;
                }
                if(Int32.TryParse(userInput, out columnInput))
                {
                    columnInput = Int32.Parse(userInput);
                }
                else
                {
                    Console.WriteLine("You did not enter the number of a column.");
                    goto requestInput;
                }
                if(columnInput < 1)
                {
                    Console.WriteLine("That is not an available column.");
                    goto requestInput;
                }
                if(columnInput > 7)
                {
                    Console.WriteLine("That is not an available column.");
                    goto requestInput;
                }
                for(int j = 0; j < 6; j++)
                {
                    if(board[j, columnInput - 1] != " ")
                    {
                        if(j == 0)
                        {
                            placeFound = false;
                            columnFull = true;
                        }
                        else
                        {
                            pieceX = (j - 1).ToString();
                            pieceY = (columnInput - 1).ToString();
                            placeFound = true;
                        }
                    }
                    if(placeFound)
                    {
                        break;
                    }
                }
                if(columnFull)
                {
                    Console.WriteLine("That column is full.");
                    goto requestInput;
                }
                if(placeFound == false)
                {
                    pieceX = 5.ToString();
                    pieceY = (columnInput - 1).ToString();
                }
                if(currentPlayer == "Yellow")
                {
                    board[Int32.Parse(pieceX), Int32.Parse(pieceY)] = "Y";
                }
                else if(currentPlayer == "Red")
                {
                    board[Int32.Parse(pieceX), Int32.Parse(pieceY)] = "R";
                }

                if(CheckWin())
                {
                    break;
                }

                if(currentPlayer == "Yellow")
                {
                    currentPlayer = "Red";
                }
                else
                {
                    currentPlayer = "Yellow";
                }
            }
            
            PrintBoard();
            switch(hasWon)
            {
                case "Yellow":
                    Console.WriteLine("Congratulations Yellow: you won!");
                    break;
                case "Red":
                    Console.WriteLine("Congratulations Red: you won!");
                    break;
                case "none":
                    Console.WriteLine("Nobody won.");
                    break;
                default:
                    break;
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(false);

            return;
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

        bool CheckWin()
        {
            string colour;
            for(int x = 0; x < 6; x++)
            {
                for(int y = 0; y < 7; y++)
                {
                    colour = board[x, y];

                    if(CheckVert(x, y, colour))
                    {
                        return true;
                    }
                    if(CheckHorz(x, y, colour))
                    {
                        return true;
                    }
                    if(CheckDiagonal(x, y, colour))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        bool CheckVert(int x, int y, string colour)
        {
            try
            {
                if(board[x, y] == board[x + 1, y])
                {
                    if(board[x + 1, y] == board[x + 2, y])
                    {
                        if(board[x + 2, y] == board[x + 3, y])
                        {
                            if(colour == "Y")
                            {
                                hasWon = "Yellow";
                                return true;
                            }
                            if(colour == "R")
                            {
                                hasWon = "Red";
                                return true;
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }

            try
            {
                if(board[x, y] == board[x - 1, y])
                {
                    if(board[x - 1, y] == board[x - 2, y])
                    {
                        if(board[x - 2, y] == board[x - 3, y])
                        {
                            if(colour == "Y")
                            {
                                hasWon = "Yellow";
                                return true;
                            }
                            if(colour == "R")
                            {
                                hasWon = "Red";
                                return true;
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }
            
            return false;
        }

        bool CheckHorz(int x, int y, string colour)
        {
            try
            {
                if(board[x, y] == board[x, y + 1])
                {
                    if(board[x, y + 1] == board[x, y + 2])
                    {
                        if(board[x, y + 2] == board[x, y + 3])
                        {
                            if(board[x, y] != " ")
                            {
                                if(colour == "Y")
                                {
                                    hasWon = "Yellow";
                                    return true;
                                }
                                if(colour == "R")
                                {
                                    hasWon = "Red";
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }

            try
            {
                if(board[x, y] == board[x, y - 1])
                {
                    if(board[x, y - 1] == board[x, y - 2])
                    {
                        if(board[x, y - 2] == board[x, y - 3])
                        {
                            if(board[x, y] != " ")
                            {
                                if(colour == "Y")
                                {
                                    hasWon = "Yellow";
                                    return true;
                                }
                                if(colour == "R")
                                {
                                    hasWon = "Red";
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }
            
            return false;
        }

        bool CheckDiagonal(int x, int y, string colour)
        {
            try
            {
                if(board[x, y] == board[x - 1, y - 1])
                {
                    if(board[x - 1, y - 1] == board[x - 2, y - 2])
                    {
                        if(board[x - 2, y - 2] == board[x - 3, y - 3])
                        {
                            if(board[x, y] != " ")
                            {
                                if(colour == "Y")
                                {
                                    hasWon = "Yellow";
                                    return true;
                                }
                                if(colour == "R")
                                {
                                    hasWon = "Red";
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }

            try
            {
                if(board[x, y] == board[x + 1, y - 1])
                {
                    if(board[x + 1, y - 1] == board[x + 2, y - 2])
                    {
                        if(board[x + 2, y - 2] == board[x + 3, y - 3])
                        {
                            if(board[x, y] != " ")
                            {
                                if(colour == "Y")
                                {
                                    hasWon = "Yellow";
                                    return true;
                                }
                                if(colour == "R")
                                {
                                    hasWon = "Red";
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }

            try
            {
                if(board[x, y] == board[x + 1, y + 1])
                {
                    if(board[x + 1, y + 1] == board[x + 2, y + 2])
                    {
                        if(board[x + 2, y + 2] == board[x + 3, y + 3])
                        {
                            if(board[x, y] != " ")
                            {
                                if(colour == "Y")
                                {
                                    hasWon = "Yellow";
                                    return true;
                                }
                                if(colour == "R")
                                {
                                    hasWon = "Red";
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }

            try
            {
                if(board[x, y] == board[x - 1, y + 1])
                {
                    if(board[x - 1, y + 1] == board[x - 2, y + 2])
                    {
                        if(board[x - 2, y + 2] == board[x - 3, y + 3])
                        {
                            if(board[x, y] != " ")
                            {
                                if(colour == "Y")
                                {
                                    hasWon = "Yellow";
                                    return true;
                                }
                                if(colour == "R")
                                {
                                    hasWon = "Red";
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }

            return false;
        }
    }
}