using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Gamerin
{
    public class Snake
    {
        static string convertString = "oiseughfnsoiulbrniuwbrfwerf";
        static string x;
        static string y;
        static int xInt;
        static int yInt;
        static int headOne;
        static int headTwo;

        static int lastLocation = 2108387039;
        static ConsoleKeyInfo key;
        
        static bool True = true;
        static bool True2 = true;
        static bool playerDead = false;
        static bool gameOver = false;
        static string motionDirection = "left";

        static Random RNG = new Random();
        static AutoResetEvent autoEvent = new AutoResetEvent(false);

        static string[,] board = new string[,]{
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",},
            {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ",}
        };
        
        public static void SnakeIntro()
        {
            gameOver = false;
            Console.Clear();
            Console.WriteLine("Welcome to Snake!");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("Use the arrow keys to move.");
            Console.WriteLine("Press any key to begin playing.");

            Console.Read();
            RunSnake();
        }
        static void RunSnake()
        {
            Initialisation();
            Timer refreshTimer = new Timer(MoveStuff, autoEvent, 0, 1000);

            while(True2)
            {
                if(playerDead == false)
                {
                    if(Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true);
                    }
                }
                else
                {
                    True2 = false;
                }
            }

            refreshTimer.Dispose();

            if(Menu.tailLocations.Count > 97)
            {
                Thread.Sleep(2000);
                Console.WriteLine("How in the...");
                Thread.Sleep(1000);
                Console.WriteLine("You won, I guess...");
                Thread.Sleep(500);

                Console.WriteLine("");
                Console.WriteLine("Press any key to return to the menu.");

                Console.Read();

                goto gameEnd;
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the menu.");

            Console.Read();
            
            gameEnd: gameOver = true;
            SpinWait.SpinUntil(() => gameOver == true);

            
        }

        static void MoveStuff(object state)
        {
            if(playerDead)
            {
                Console.WriteLine("You died. Press any key to return to the menu.");
                Console.Read();
                autoEvent.Set();
            }
            bool reverseDirection = false;
            switch(key.Key)
            {
                case ConsoleKey.UpArrow:
                    if(motionDirection == "down")
                    {
                        reverseDirection = true;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(motionDirection == "up")
                    {
                        reverseDirection = true;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(motionDirection == "right")
                    {
                        reverseDirection = true;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(motionDirection == "left")
                    {
                        reverseDirection = true;
                    }
                    break;
            }

            if(reverseDirection == false)
            {
                switch(key.Key)
                {
                case ConsoleKey.UpArrow:
                    motionDirection = "up";
                    MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    motionDirection = "down";
                    MoveDown();
                    break;
                case ConsoleKey.LeftArrow:
                    motionDirection = "left";
                    MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    motionDirection = "right";
                    MoveRight();
                    break;
                default:
                    if(motionDirection == "left")
                    {
                        MoveLeft();
                    }
                    if(motionDirection == "right")
                    {
                        MoveRight();
                    }
                    if(motionDirection == "up")
                    {
                        MoveUp();
                    }
                    if(motionDirection == "down")
                    {
                        MoveDown();
                    }
                        
                    break;
                }
            }
            else
            {
                if(motionDirection == "up")
                {
                    MoveUp();
                }
                if(motionDirection == "down")
                {
                    MoveDown();
                }
                if(motionDirection == "left")
                {
                    MoveLeft();
                }
                if(motionDirection == "right")
                {
                    MoveRight();
                }
            }

            TailFollow();

            if(playerDead)
            {
                Console.WriteLine("You died. Press any key to return to the menu.");
                Console.Read();
                autoEvent.Set();
            }

            if(playerDead == false)
            {
                PrintBoard();
            }
        }
        static void MoveUp()
        {
            try
            {
                if(board[headOne - 1, headTwo] == "o")
                {
                    EatApple();
                }
                if(board[headOne - 1, headTwo] == "|" || board[headOne - 1, headTwo] == "-")
                {
                    playerDead = true;
                }
                if(board[headOne - 1, headTwo] == "=")
                {
                    int tailLocation = Int32.Parse(headOne.ToString() + headTwo.ToString());
                    var tailKey = Menu.tailLocations.FirstOrDefault(x => x.Value == tailLocation).Key;

                    if(tailKey != Menu.tailLocations.Count)
                    {
                        playerDead = true;
                    }
                }

                board[headOne - 1, headTwo] = "0";
                board[headOne, headTwo] = " ";
            }
            catch(IndexOutOfRangeException)
            {
                playerDead = true;
            }
            headOne = headOne - 1;
        }
        static void MoveDown()
        {
            try
            {
                if(board[headOne + 1, headTwo] == "o")
                {
                    EatApple();
                }
                if(board[headOne + 1, headTwo] == "|" || board[headOne + 1, headTwo] == "-")
                {
                    playerDead = true;
                }
                if(board[headOne + 1, headTwo] == "=")
                {
                    int tailLocation = Int32.Parse(headOne.ToString() + headTwo.ToString());
                    var tailKey = Menu.tailLocations.FirstOrDefault(x => x.Value == tailLocation).Key;

                    if(tailKey != Menu.tailLocations.Count)
                    {
                        playerDead = true;
                    }
                }

                board[headOne + 1, headTwo] = "0";
                board[headOne, headTwo] = " ";
            }
            catch(IndexOutOfRangeException)
            {
                playerDead = true;
            }
            headOne = headOne + 1;
        }
        static void MoveLeft()
        {
            try
            {
                if(board[headOne, headTwo - 1] == "o")
                {
                    EatApple();
                }
                if(board[headOne, headTwo - 1] == "|" || board[headOne, headTwo - 1] == "-")
                {
                    playerDead = true;
                }
                if(board[headOne, headTwo - 1] == "=")
                {
                    int tailLocation = Int32.Parse(headOne.ToString() + headTwo.ToString());
                    var tailKey = Menu.tailLocations.FirstOrDefault(x => x.Value == tailLocation).Key;

                    if(tailKey != Menu.tailLocations.Count)
                    {
                        playerDead = true;
                    }
                }

                board[headOne, headTwo - 1] = "0";
                board[headOne, headTwo] = " ";
            }
            catch(IndexOutOfRangeException)
            {
                playerDead = true;
            }
            headTwo = headTwo - 1;
        }
        static void MoveRight()
        {
            try
            {
                if(board[headOne, headTwo + 1] == "o")
                {
                    EatApple();
                }
                if(board[headOne, headTwo + 1] == "|" || board[headOne, headTwo + 1] == "-")
                {
                    playerDead = true;
                }
                if(board[headOne, headTwo + 1] == "=")
                {
                    int tailLocation = Int32.Parse(headOne.ToString() + headTwo.ToString());
                    var tailKey = Menu.tailLocations.FirstOrDefault(x => x.Value == tailLocation).Key;

                    if(tailKey != Menu.tailLocations.Count)
                    {
                        playerDead = true;
                    }
                }
            
                board[headOne, headTwo + 1] = "0";
                board[headOne, headTwo] = " ";
            }
            catch(IndexOutOfRangeException)
            {
                playerDead = true;
            }
            headTwo = headTwo + 1;
        }

        //Other function stuff
        static void EatApple()
        {
            TailGrow();
            CreateNewApple();
        }
        static void TailGrow()
        {
            convertString = lastLocation.ToString();
            x = convertString.Substring(0, 1);
            y = convertString.Substring(1, 1);

            xInt = Int32.Parse(x);
            yInt = Int32.Parse(y);

            board[xInt, yInt] = "=";

            Menu.tailLocations.Add(Menu.tailLocations.Count + 1, lastLocation);
        }
        static void TailFollow()
        {   
            switch(motionDirection)
            {
                case "up":
                    convertString = Menu.tailLocations[1].ToString();
                    lastLocation = Menu.tailLocations[1];

                    
                    y = convertString.Substring((convertString.Length - 1), 1);
                    x = convertString.Substring(0, 1);

                    try
                    {
                        xInt = Int32.Parse(x);
                        yInt = Int32.Parse(y);

                        board[xInt, yInt] = " ";

                        string newTail = (headOne + 1).ToString() + headTwo.ToString();
                        Menu.tailLocations[1] = Int32.Parse(newTail);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(convertString);
                        Thread.Sleep(1500);
                        playerDead = true;
                    }

                    
                    break;
                case "down":
                    convertString = Menu.tailLocations[1].ToString();
                    lastLocation = Menu.tailLocations[1];

                    y = convertString.Substring((convertString.Length - 1), 1);
                    x = convertString.Substring(0, 1);

                    try
                    {
                        xInt = Int32.Parse(x);
                        yInt = Int32.Parse(y);

                        board[xInt, yInt] = " ";

                        string newTail = (headOne - 1).ToString() + headTwo.ToString();
                        Menu.tailLocations[1] = Int32.Parse(newTail);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(convertString);
                        Thread.Sleep(1500);
                        playerDead = true;
                    }

                    
                    break;
                case "left":
                    convertString = Menu.tailLocations[1].ToString();
                    lastLocation = Menu.tailLocations[1];
                    
                    y = convertString.Substring((convertString.Length - 1), 1);
                    x = convertString.Substring(0, 1);

                    try
                    {
                        xInt = Int32.Parse(x);
                        yInt = Int32.Parse(y);

                        board[xInt, yInt] = " ";

                        string newTail = headOne.ToString() + (headTwo + 1).ToString();
                        Menu.tailLocations[1] = Int32.Parse(newTail);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(convertString);
                        Thread.Sleep(1500);
                        playerDead = true;
                    }
                    
                    
                    break;
                case "right":
                    convertString = Menu.tailLocations[1].ToString();
                    lastLocation = Menu.tailLocations[1];
                    
                    y = convertString.Substring((convertString.Length - 1), 1);
                    x = convertString.Substring(0, 1);

                    try
                    {
                        xInt = Int32.Parse(x);
                        yInt = Int32.Parse(y);

                        board[xInt, yInt] = " ";
                    
                        string newTail = headOne.ToString() + (headTwo - 1).ToString();
                        Menu.tailLocations[1] = Int32.Parse(newTail);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(convertString);
                        Thread.Sleep(1500);
                        playerDead = true;
                    }

                    
                    break;
                default:
                    break;
            }
            
            for(int i = 2; i <= Menu.tailLocations.Count; i++)
            {
                int preLast = Menu.tailLocations[i];
                convertString = Menu.tailLocations[i].ToString();
                string x2 = convertString.Substring(0, 1);
                string y2 = convertString.Substring((convertString.Length - 1), 1);

                int xInt2 = Int32.Parse(x2);
                int yInt2 = Int32.Parse(y2);

                board[xInt2, yInt2] = " ";
                Menu.tailLocations[i] = lastLocation;

                lastLocation = preLast;
            } 
        }
        



        //Did you get the board printed?
        //Bogos binted?
        //What?
        static void PrintBoard()
        {
            Console.Clear();
            foreach(KeyValuePair<int, int> kvp in Menu.tailLocations)
            {
                string convertString = kvp.Value.ToString();

                string x = convertString.Substring(0, 1);
                string y = convertString.Substring(convertString.Length - 1, 1);

                int xInt = Int32.Parse(x);
                int yInt = Int32.Parse(y);
                board[xInt, yInt] = "=";
            }

            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" +--------------------------------+ ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            for(int i = 0; i < 10; i++)
            {
                Console.Write("\n");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                for(int j = 0; j < 10; j++)
                {
                    switch(board[i, j])
                    {
                        case "0":
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "=":
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            break;
                        case " ":
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case "o":
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        default:
                            break;
                    }
                    Console.Write($" {board[i, j]} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" +--------------------------------+ ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
        }

        

        //all dat gud initialisation stuff
        static void Initialisation()
        {
            ResetVariables();
            CreateNewSnake();
            CreateNewTail();
            CreateNewApple();
            Console.WriteLine("apple");

            PrintBoard();
            Thread.Sleep(1000);
        }
        static void ResetVariables()
        {
            True = true;
            True2 = true;

            playerDead = false;
            gameOver = false;
            motionDirection = "left";
            for(int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 10; y++)
                {
                    board[x, y] = " ";
                }
            }
        }
        static void CreateNewSnake()
        {
            headOne = RNG.Next(2, 7);
            headTwo = RNG.Next(2, 7);
            board[headOne, headTwo] = "0";
            board[headOne, headTwo - 1] = "/";
        }
        static void CreateNewTail()
        {
            for(int i = 1; i <= 2; i++)
            {
                string tailOne = headOne.ToString();
                string tailTwo = (headTwo + i).ToString();

                string tail = tailOne + tailTwo;
                
                Menu.tailLocations.Add(i, Int32.Parse(tail));
            }
        }
        static void CreateNewApple()
        {
            int ranOne = RNG.Next(0, 9);
            int ranTwo = RNG.Next(0, 9);

            while(True)
            {
                if(board[ranOne, ranTwo] == " ")
                {
                    
                    bool stillWorks = true;
                    try
                    {
                        if(stillWorks && ranOne != (headOne - 1))
                        {
                                stillWorks = true;
                        }
                        else
                        {
                            stillWorks = false;
                        }
                        if(stillWorks && ranOne != (headOne + 1))
                        {
                            stillWorks = true;
                        }
                        else
                        {
                            stillWorks = false;
                        }
                        if(stillWorks && ranTwo != (headTwo - 1))
                        {
                            stillWorks = true;
                        }
                        else
                        {
                            stillWorks = false;
                        }
                        if(stillWorks && ranTwo != (headTwo + 1))
                        {
                            stillWorks = true;
                        }
                        else
                        {
                            stillWorks = false;
                        }
                    }
                    catch(IndexOutOfRangeException)
                    {
                        stillWorks = false;
                    }
                    
                    if(stillWorks)
                    {
                        board[ranOne, ranTwo] = "o";
                        True = false;
                    }
                    else
                    {
                        ranOne = RNG.Next(0, 9);
                        ranTwo = RNG.Next(0, 9);
                    }
                }
                else
                { 
                    ranOne = RNG.Next(0, 9);
                    ranTwo = RNG.Next(0, 9);
                }
            }
            True = true;
            board[headOne, headTwo - 1] = " ";
        }
    }
}