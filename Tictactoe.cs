using System;
using System.Linq;
using System.Threading;

namespace Gamerin
{
    public class Tictactoe
    {
        string[,] board = new string[3,3] {
            { " ", " ", " "},
            { " ", " ", " "},
            { " ", " ", " "}
        };

        string currentPlayer = "P1";
        string hasWon = "none";
        string p;

        string currentInput;
        string strInputX;
        string strInputY;
        int intInputX;
        int intInputY;

        public void RunTictactoe()
        {
            //Intro 
            Console.Clear();
            Console.WriteLine("Welcome to TicTacToe!");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("Use grid references to place your X or O. (E.g., 2, 2 is the middle square)");
            gameStart: Console.WriteLine("Press 'e' at any time to return to the menu. Press any key to start playing.");
            Console.ReadKey();

            //Loops through turns
            for(int i = 1; i <= 9; i++)
            {
                //Prints board state, turn number and current player
                Console.WriteLine($"Turn {i}:");
                PrintBoard();
                Console.Write($"{currentPlayer}: ");

                //Takes input, and ensures input contains comma to separate
                takeInput: currentInput = Console.ReadLine().ToLower();
                if(currentInput == "e")
                {
                    goto gameEnd;
                }
                if(currentInput.Contains(',') != true)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    goto takeInput;
                }

                //Splits input and checks only two numbers were supplied, then sends results to correct variables
                string[] split = currentInput.Split(',');
                if(split.Count() > 2)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    goto takeInput;
                }
                strInputX = split[0];
                strInputY = split[1];

                //Ensures remaining input contains only numbers, then parses them to check their values correctly
                //Otherwise returns to the input stage after printing an error
                if(Int32.TryParse(strInputX, out intInputX))
                {
                    intInputX = Int32.Parse(strInputX);
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    goto takeInput;
                }
                if(Int32.TryParse(strInputY, out intInputY))
                {
                    intInputY = Int32.Parse(strInputY);
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    goto takeInput;
                }

                //Ensures values provided are within range of the board array to prevent an error
                if(intInputY > 3 || intInputX > 3 || intInputY < 1 || intInputX < 1)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    goto takeInput;
                }
                else
                {
                    if(currentPlayer == "P1")
                    {
                        //Adds an X to the board if the turn's player is P1, then switches player
                        if(board[intInputX - 1, intInputY - 1] == " ")
                        {
                            board[intInputX - 1, intInputY - 1] = "X";
                            currentPlayer = "P2";
                        }
                        else
                        {
                            //Ensures the space provided by the player does not already contain a value
                            Console.WriteLine("Invalid input. Try again.");
                            goto takeInput;
                        }
                    }
                    else
                    {
                        if(board[intInputX - 1, intInputY - 1] == " ")
                        {
                            //Adds an O to the board if the turn's player is P2, then switches player
                            board[intInputX - 1, intInputY - 1] = "O";
                            currentPlayer = "P1";
                        }
                        else
                        {
                            //Ensures the space provided by the player does not already contain a value
                            Console.WriteLine("Invalid input. Try again.");
                            goto takeInput;
                        }
                    }
                }

                //Loop to check if a player has won at the conclusion of each turn
                for(int x = 0; x < 3; x++)
                {
                    //Checks verticals
                    if(board[x, 0].Equals(board[x, 1]) && board[x, 1].Equals(board[x, 2]) && board[x, 1] != " ")
                    {
                        //Sets the correct winner
                        if(currentPlayer == "P1")
                        {
                            hasWon = "P2";
                        }
                        else
                        {
                            hasWon = "P1";
                        }
                    }
                    //Checks horizontals
                    if(board[0, x].Equals(board[1, x]) && board[1, x].Equals(board[2, x]) && board[1, x] != " ")
                    {
                        //Sets the correct winner
                        if(currentPlayer == "P1")
                        {
                            hasWon = "P2";
                        }
                        else
                        {
                            hasWon = "P1";
                        }
                    }
                }
                //Checks diagonals from top-left to bottom-right
                if(board[0, 0].Equals(board[1, 1]) && board[1, 1].Equals(board[2, 2]) && board[2, 2] != " ")
                {
                    //Sets the correct winner
                    if(currentPlayer == "P1")
                    {
                         hasWon = "P2";
                    }
                    else
                    {
                        hasWon = "P1";
                    }
                }
                //Checks diagonals from top right to bottom-left
                if(board[2, 0].Equals(board[1, 1]) && board[1, 1].Equals(board[0, 2]) && board[0, 2] != " ")
                {
                    //Sets the correct winner
                    if(currentPlayer == "P1")
                    {
                         hasWon = "P2";
                    }
                    else
                    {
                        hasWon = "P1";
                    }
                }

                //Checks if anyone has won yet at the conclusion of the turn, if so ends the turn loop
                if(hasWon == "P1" || hasWon == "P2")
                {
                    break;
                }
            }
            PrintBoard();

            //Checks if the turn loop expired naturally, in which case the game tied - if not, prints hasWon as the winner
            if(hasWon == "none")
            {
                Console.WriteLine("The game was a tie.");
            }
            else
            {
                Console.WriteLine($"Congratulations {hasWon} - you won! What a gamer.");
            }

            Console.WriteLine("Press any key to return to the menu, press 'p' to play again");
            //Takes input to determine whether to end the function and return to Menu class, or restart the game
            p = Console.ReadLine().ToString();
            gameEnd: if(p == "p")
            {
                goto gameStart;
            }
        }

        void PrintBoard()
        {
            //Uses some funky ass stuff to print the board in a nice enclosed colourful box
            //Which often glitches and looks horrific

            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write($"  {board[0,0]} | {board[1,0]} | {board[2,0]}  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(" ---+---+--- ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write($"  {board[0,1]} | {board[1,1]} | {board[2,1]}  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(" ---+---+--- ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write($"  {board[0,2]} | {board[1,2]} | {board[2,2]}  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
