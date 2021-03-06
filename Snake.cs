using System;
using System.Threading;
using System.Collections.Generic;

namespace Gamerin
{
    public class Snake
    {
        int lastLocation;

        string x;
        string y;

        int xInt;
        int yInt;

        int headOne;
        int headTwo;

        
        bool True = true;
        bool True2 = true;
        bool playerDead = false;
        bool gameOver = false;
        bool headTailSwap = false;

        string convertString = "";
        string motionDirection = "left";
        ConsoleKeyInfo key;

        Random RNG = new Random();
        public IDictionary<int, int> tailLocations = new Dictionary<int, int>();
        AutoResetEvent autoEvent = new AutoResetEvent(false);

        string[,] board = new string[,]{
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
        
        public void SnakeIntro()
        {
            //Game intro, requests command to start game
            Console.Clear();
            Console.WriteLine("Welcome to Snake!");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("Use the arrow keys or WASD to move.");
            Console.WriteLine("Press any key to begin playing.");

            Console.ReadKey(true);
            RunSnake();
        }
        void RunSnake()
        {
            //Runs Initialisation then creates refreshTimer to time board prints
            Initialisation();
            Timer refreshTimer = new Timer(MoveStuff, autoEvent, 0, 1000);

            //While loop ends when the player is dead, otherwise reads player's input
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
                    refreshTimer.Dispose();
                }
            }
            
            //Kills refreshTimer, then checks if the player's snake is 98 segments long (in which case they 
            //have filled the board) and if it is then they win.
            //Otherwise the player loses, and the player is returned to the menu after awaiting input
            if(tailLocations.Count > 96)
            {
                Thread.Sleep(2000);
                Console.WriteLine("How in the...");
                Thread.Sleep(1000);
                Console.WriteLine("You won, I guess...");
                Thread.Sleep(500);

                Console.WriteLine("");
                Console.WriteLine("Press any key to return to the menu.");

                Console.ReadKey();

                goto gameEnd;
            }

            Console.WriteLine("");
            Console.WriteLine("You died. Press any key to return to the menu.");

            Console.ReadKey();
            
            //Ends the game. SpinWait bocks Menu.Main()
            gameEnd: gameOver = true;
            SpinWait.SpinUntil(() => gameOver == true);
        }

        void MoveStuff(object state)
        {
            headTailSwap = false;

            //Ensures the apple was created properly
            bool appleExists = false;
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if(board[i, j] == "o")
                    {
                        appleExists = true;
                    }
                }
            }
            if(appleExists == false)
            {
                CreateNewApple();
            }

            //The player might have died after MoveStuff() ended, so it should also be checked when it starts
            if(playerDead)
            {
                autoEvent.Set();
            }
            //If the player attempts to double back on themselves, they shouldnt be able to
            //If they try, they move in the opposite direction they attempted to (the direction they wouldve been going already)
            //If they didnt try to do this, they move as normal
            switch(key.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if(motionDirection == "down")
                    {
                        MoveDown();
                    }
                    else
                    {
                        motionDirection = "up";
                        MoveUp();
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if(motionDirection == "up")
                    {
                        MoveUp();
                    }
                    else
                    {
                        motionDirection = "down";
                        MoveDown();
                    }
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if(motionDirection == "right")
                    {
                        MoveRight();
                    }
                    else
                    {
                        motionDirection = "left";
                        MoveLeft();
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if(motionDirection == "left")
                    {
                        MoveLeft();
                    }
                    else
                    {
                        motionDirection = "right";
                        MoveRight();
                    }
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

            //Function that moves all the tail segments sequentially
            TailFollow();

            //Player death check at the end of the turn
            if(playerDead)
            {
                autoEvent.Set();
            }
            else
            {
                PrintBoard();
            }
        }
        void MoveUp()
        {
            try
            {
                if(board[headOne - 1, headTwo] == "o")
                { //If the square the player is attempting to enter contains an apple, the EatApple function is called
                    EatApple();
                }
                if(board[headOne - 1, headTwo] == "=")
                { //If the square the player is attempting to move to contains a tail segment, they should die
                    //However if it is the final tail segment, the tail should move forward just as the head moves
                    //into that square, so the square is checked to see if it contains the final segment of the tail
                    int tailLocation = Int32.Parse((headOne - 1).ToString() + headTwo.ToString());
                    foreach(KeyValuePair<int, int> kvp in tailLocations)
                    {
                        if(kvp.Key == tailLocations.Count - 1)
                        {
                            if(kvp.Value != tailLocation)
                            {
                                playerDead = true;
                            }
                        }
                    }
                    if(playerDead == false)
                    {
                        headTailSwap = true;
                    }
                }
                else
                {
                    //If none of these return true and kill the player, the player moves
                    board[headOne - 1, headTwo] = "0";
                    board[headOne, headTwo] = " ";
                }
            }
            catch(IndexOutOfRangeException)
            {
                playerDead = true;
            }

            //The head location changes to reflect the new location
            headOne = headOne - 1;
        }
        void MoveDown()
        {
            //Same as the other functions, but moves down
            try
            {
                if(board[headOne + 1, headTwo] == "o")
                {
                    EatApple();
                }
                if(board[headOne + 1, headTwo] == "=")
                {
                    int tailLocation = Int32.Parse((headOne + 1).ToString() + headTwo.ToString());
                    foreach(KeyValuePair<int, int> kvp in tailLocations)
                    {
                        if(kvp.Key == tailLocations.Count - 1)
                        {
                            if(kvp.Value != tailLocation)
                            {
                                playerDead = true;
                            }
                        }
                    }
                    if(playerDead == false)
                    {
                        headTailSwap = true;
                    }
                }
                else
                {
                    board[headOne + 1, headTwo] = "0";
                    board[headOne, headTwo] = " ";
                }
            }
            catch(IndexOutOfRangeException)
            {
                playerDead = true;
            }

            headOne = headOne + 1;
        }
        void MoveLeft()
        {
            //Same as the other functions, but moves left
            try
            {
                if(board[headOne, headTwo - 1] == "o")
                {
                    EatApple();
                }
                if(board[headOne, headTwo - 1] == "=")
                {
                    int tailLocation = Int32.Parse(headOne.ToString() + (headTwo - 1).ToString());
                    foreach(KeyValuePair<int, int> kvp in tailLocations)
                    {
                        if(kvp.Key == tailLocations.Count - 1)
                        {
                            if(kvp.Value != tailLocation)
                            {
                                playerDead = true;
                            }
                        }
                    }
                    if(playerDead == false)
                    {
                        headTailSwap = true;
                    }
                }
                else
                {
                    board[headOne, headTwo - 1] = "0";
                    board[headOne, headTwo] = " ";
                }
            }
            catch(IndexOutOfRangeException)
            {
                playerDead = true;
            }

            headTwo = headTwo - 1;
        }
        void MoveRight()
        {
            //Same as the other functions, but moves right
            try
            {
                if(board[headOne, headTwo + 1] == "o")
                {
                    EatApple();
                }
                if(board[headOne, headTwo + 1] == "=")
                {
                    int tailLocation = Int32.Parse(headOne.ToString() + (headTwo + 1).ToString());
                    foreach(KeyValuePair<int, int> kvp in tailLocations)
                    {
                        if(kvp.Key == tailLocations.Count - 1)
                        {
                            if(kvp.Value != tailLocation)
                            {
                                playerDead = true;
                            }
                        }
                    }
                    if(playerDead == false)
                    {
                        headTailSwap = true;
                    }
                }
                else
                {
                    board[headOne, headTwo + 1] = "0";
                    board[headOne, headTwo] = " ";
                }
            }
            catch(IndexOutOfRangeException)
            {
                playerDead = true;
            }

            headTwo = headTwo + 1;
        }

        //Other function stuff
        void EatApple()
        {
            //If the apple is eaten, a new apple is generated and the tail grows
            TailGrow();
            CreateNewApple();
        }
        void TailGrow()
        {
            //The function uses the last position of the last moved tail to add a new one at that location
            convertString = lastLocation.ToString();

            if(convertString.Length == 1)
            {
                x = "0";
                y = convertString;
            }
            else
            {
                x = convertString.Substring(0, 1);
                y = convertString.Substring((convertString.Length - 1), 1);
            }

            xInt = Int32.Parse(x);
            yInt = Int32.Parse(y);

            board[xInt, yInt] = "=";

            tailLocations.Add(tailLocations.Count, lastLocation);
        }
        void TailFollow()
        { //Function sequentially moves tail segments towards the head, following the path the head took
            //This part decides on the movement of the first segment (next to the head)
            switch(motionDirection)
            {
                case "up":
                    convertString = tailLocations[0].ToString();
                    lastLocation = tailLocations[0];

                    if(convertString.Length == 1)
                    {
                        x = "0";
                        y = convertString;
                    }
                    else
                    {
                        y = convertString.Substring((convertString.Length - 1), 1);
                        x = convertString.Substring(0, 1);
                    }

                    try
                    {
                        xInt = Int32.Parse(x);
                        yInt = Int32.Parse(y);

                        board[xInt, yInt] = " ";

                        string newTail = (headOne + 1).ToString() + headTwo.ToString();
                        tailLocations[0] = Int32.Parse(newTail);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(convertString);
                        Thread.Sleep(1500);
                        playerDead = true;
                    }

                    
                    break;
                case "down":
                    convertString = tailLocations[0].ToString();
                    lastLocation = tailLocations[0];

                    if(convertString.Length == 1)
                    {
                        x = "0";
                        y = convertString;
                    }
                    else
                    {
                        y = convertString.Substring((convertString.Length - 1), 1);
                        x = convertString.Substring(0, 1);
                    }

                    try
                    {
                        xInt = Int32.Parse(x);
                        yInt = Int32.Parse(y);

                        board[xInt, yInt] = " ";

                        string newTail = (headOne - 1).ToString() + headTwo.ToString();
                        tailLocations[0] = Int32.Parse(newTail);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(convertString);
                        Thread.Sleep(1500);
                        playerDead = true;
                    }

                    
                    break;
                case "left":
                    convertString = tailLocations[0].ToString();
                    lastLocation = tailLocations[0];
                    
                    if(convertString.Length == 1)
                    {
                        x = "0";
                        y = convertString;
                    }
                    else
                    {
                        y = convertString.Substring((convertString.Length - 1), 1);
                        x = convertString.Substring(0, 1);
                    }

                    try
                    {
                        xInt = Int32.Parse(x);
                        yInt = Int32.Parse(y);

                        board[xInt, yInt] = " ";

                        string newTail = headOne.ToString() + (headTwo + 1).ToString();
                        tailLocations[0] = Int32.Parse(newTail);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(convertString);
                        Thread.Sleep(1500);
                        playerDead = true;
                    }
                    
                    
                    break;
                case "right":
                    convertString = tailLocations[0].ToString();
                    lastLocation = tailLocations[0];
                    
                    if(convertString.Length == 1)
                    {
                        x = "0";
                        y = convertString;
                    }
                    else
                    {
                        y = convertString.Substring((convertString.Length - 1), 1);
                        x = convertString.Substring(0, 1);
                    }

                    try
                    {
                        xInt = Int32.Parse(x);
                        yInt = Int32.Parse(y);

                        board[xInt, yInt] = " ";
                    
                        string newTail = headOne.ToString() + (headTwo - 1).ToString();
                        tailLocations[0] = Int32.Parse(newTail);
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
            
            //This part decides on the movement of the rest of the segments
            for(int i = 1; i < tailLocations.Count; i++)
            {
                int preLast = tailLocations[i];
                convertString = tailLocations[i].ToString();

                string x2;
                string y2;

                if(convertString.Length == 1)
                {
                    x2 = "0";
                    y2 = convertString;
                }
                else
                {
                    x2 = convertString.Substring(0, 1);
                    y2 = convertString.Substring((convertString.Length - 1), 1);
                }

                int xInt2 = Int32.Parse(x2);
                int yInt2 = Int32.Parse(y2);

                board[xInt2, yInt2] = " ";
                tailLocations[i] = lastLocation;

                //Variables stores where the last segment was before movement, for the TailGrow() function to use
                lastLocation = preLast;
            }

            //This is where the head moves if it was shown earlier to be trying to move into the square its tail is leaving
            if(headTailSwap)
            {
                switch(motionDirection)
                {
                    case "up":
                        board[headOne, headTwo] = "0";
                        break;
                    case "down":
                        board[headOne, headTwo] = "0";
                        break;
                    case "left":
                        board[headOne, headTwo] = "0";
                        break;
                    case "right":
                        board[headOne, headTwo] = "0";
                        break;
                }
            }
        }
        


        //Did you get the board printed?
        //Bogos binted?
        //What?
        void PrintBoard()
        {
            Console.Clear();
            foreach(KeyValuePair<int, int> kvp in tailLocations)
            {
                string convertString = kvp.Value.ToString();
                string x;
                string y;

                if(convertString.Length == 1)
                {
                    x = "0";
                    y = convertString;
                }
                else
                {
                    x = convertString.Substring(0, 1);
                    y = convertString.Substring(convertString.Length - 1, 1);
                }
                
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
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Green;
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
        void Initialisation()
        {
            CreateNewSnake();
            CreateNewTail();
            CreateNewApple();

            PrintBoard();
            Thread.Sleep(1000);
        }
        void CreateNewSnake()
        {
            headOne = RNG.Next(2, 7);
            headTwo = RNG.Next(2, 7);
            board[headOne, headTwo] = "0";
            board[headOne, headTwo - 1] = "/";
        }
        void CreateNewTail()
        {
            for(int i = 0; i < 2; i++)
            {
                string tailOne = headOne.ToString();
                string tailTwo = (headTwo + i + 1).ToString();

                string tail = tailOne + tailTwo;
                
                tailLocations.Add(i, Int32.Parse(tail));
            }
        }
        void CreateNewApple()
        {
            int ranOne = RNG.Next(0, 10);
            int ranTwo = RNG.Next(0, 10);

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
            try
            {
                board[headOne, headTwo - 1] = " ";
            }
            catch
            {

            }
        }
    }
}