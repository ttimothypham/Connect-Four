using System;

class Program
{

    public static int[,] board;

    public static int playerOne = 1;
    public static int playerTwo = 2;
    public static string p1Name = "Player One";
    public static string p2Name = "Player Two";
    public static int turn = 0;


    public static void Main(string[] args)
    {
        bool play = true;
        board = new int[6, 7];
        Console.WriteLine();
        Console.WriteLine("Welcome to Connect 4!");
        Console.Write("Do you want to use Usernames? (yes/no) : ");
        string userInput = Console.ReadLine();
        if (userInput.ToLower() == "yes")
        {
            Console.Write("Player One's Username: ");
            p1Name = Console.ReadLine();
            Console.Write("Player Two's Username: ");
            p2Name = Console.ReadLine();
        }
        //randomly selects who goes first.
        Console.Write("Do you want to randomly select who goes first? (yes/no) : ");
        userInput = Console.ReadLine();
        if (userInput.ToLower() == "yes")
        {
            Random rnd = new Random();
            int randTurn = rnd.Next(1, 3);
            turn = randTurn;
        }
        else
        {
            turn = 1;
        }

        Console.WriteLine("Enter a column number to place your piece! (0-6)");
        while (play)
        {
            Program.printBoard();
            Console.WriteLine();
            if (turn == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(p1Name + "'s move: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(p2Name + "'s move: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            int positionInput;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out positionInput))
            {
                Program.move(positionInput, turn);
                Program.changeTurn(turn);
            }
            else
            {
                Console.WriteLine("Invalid Input: Please enter a number between 0-6. Try again!");
                Console.WriteLine();
            }
            if (Program.winChecker(playerOne) == true)
            {
                Program.printBoard();
                Console.WriteLine();
                Console.WriteLine(p1Name + " Wins!");
                Console.WriteLine("                          oooo$$$$$$$$$$$$oooo");
                Console.WriteLine("                      oo$$$$$$$$$$$$$$$$$$$$$$$$o");
                Console.WriteLine("                   oo$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$o         o$   $$ o$");
                Console.WriteLine("   o $ oo        o$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$o       $$ $$ $$o$");
                Console.WriteLine("oo $ $ '$      o$$$$$$$$$    $$$$$$$$$$$$$    $$$$$$$$$o       $$$o$$o$");
                Console.WriteLine("'$$$$$$o$     o$$$$$$$$$      $$$$$$$$$$$      $$$$$$$$$$o    $$$$$$$$");
                Console.WriteLine("  $$$$$$$    $$$$$$$$$$$      $$$$$$$$$$$      $$$$$$$$$$$$$$$$$$$$$$$");
                Console.WriteLine("  $$$$$$$$$$$$$$$$$$$$$$$    $$$$$$$$$$$$$    $$$$$$$$$$$$$$  *'$$$");
                Console.WriteLine("   '$$$**$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$     '$$$");
                Console.WriteLine("    $$$   o$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$     '$$$o");
                Console.WriteLine("   o$$'   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$       $$$o");
                Console.WriteLine("   $$$    $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$* *$$$$$$ooooo$$$$o");
                Console.WriteLine("  o$$$oooo$$$$$  $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$   o$$$$$$$$$$$$$$$$$");
                Console.WriteLine("  $$$$$$$$'$$$$   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$     $$$$*******");
                Console.WriteLine(" **       $$$$    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$'      o$$$");
                Console.WriteLine("            '$$$o     **'$$$$$$$$$$$$$$$$$$$$$'         $$$");
                Console.WriteLine("              $$$o          '$$**$$$$$$****           o$$$");
                Console.WriteLine("               $$$$o                 oo             o$$$**");
                Console.WriteLine("                '$$$$o      o$$$$$$o'$$$$o        o$$$$");
                Console.WriteLine("                  '$$$$$oo     '$$$$o$$$$$o   o$$$$**  ");
                Console.WriteLine("                     **$$$$$oooo  '$$$o$$$$$$$$$**");
                Console.WriteLine("                        **$$$$$$$oo $$$$$$$$$$       ");
                Console.WriteLine("                                ****$$$$$$$$$$$        ");
                Console.WriteLine("                                    $$$$$$$$$$$$       ");
                Console.WriteLine("                                     $$$$$$$$$$'      ");
                Console.WriteLine("                                      '$$$****");
                Console.WriteLine("");
                Console.Write("GGs. Do you want to play again? (yes/no) : ");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "yes")
                {
                    Program.resetBoard();
                }
                else
                {
                    Console.Write("Thanks for playing");
                    play = false;
                }
            }

            if (Program.winChecker(playerTwo) == true)
            {
                Program.printBoard();
                Console.WriteLine();
                Console.WriteLine("                          oooo$$$$$$$$$$$$oooo");
                Console.WriteLine("                      oo$$$$$$$$$$$$$$$$$$$$$$$$o");
                Console.WriteLine("                   oo$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$o         o$   $$ o$");
                Console.WriteLine("   o $ oo        o$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$o       $$ $$ $$o$");
                Console.WriteLine("oo $ $ '$      o$$$$$$$$$    $$$$$$$$$$$$$    $$$$$$$$$o       $$$o$$o$");
                Console.WriteLine("'$$$$$$o$     o$$$$$$$$$      $$$$$$$$$$$      $$$$$$$$$$o    $$$$$$$$");
                Console.WriteLine("  $$$$$$$    $$$$$$$$$$$      $$$$$$$$$$$      $$$$$$$$$$$$$$$$$$$$$$$");
                Console.WriteLine("  $$$$$$$$$$$$$$$$$$$$$$$    $$$$$$$$$$$$$    $$$$$$$$$$$$$$  *'$$$");
                Console.WriteLine("   '$$$**$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$     '$$$");
                Console.WriteLine("    $$$   o$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$     '$$$o");
                Console.WriteLine("   o$$'   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$       $$$o");
                Console.WriteLine("   $$$    $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$* *$$$$$$ooooo$$$$o");
                Console.WriteLine("  o$$$oooo$$$$$  $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$   o$$$$$$$$$$$$$$$$$");
                Console.WriteLine("  $$$$$$$$'$$$$   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$     $$$$*******");
                Console.WriteLine(" **       $$$$    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$'      o$$$");
                Console.WriteLine("            '$$$o     **'$$$$$$$$$$$$$$$$$$$$$'         $$$");
                Console.WriteLine("              $$$o          '$$**$$$$$$****           o$$$");
                Console.WriteLine("               $$$$o                 oo             o$$$**");
                Console.WriteLine("                '$$$$o      o$$$$$$o'$$$$o        o$$$$");
                Console.WriteLine("                  '$$$$$oo     '$$$$o$$$$$o   o$$$$**  ");
                Console.WriteLine("                     **$$$$$oooo  '$$$o$$$$$$$$$**");
                Console.WriteLine("                        **$$$$$$$oo $$$$$$$$$$       ");
                Console.WriteLine("                                ****$$$$$$$$$$$        ");
                Console.WriteLine("                                    $$$$$$$$$$$$       ");
                Console.WriteLine("                                     $$$$$$$$$$'      ");
                Console.WriteLine("                                      '$$$****");
                Console.WriteLine("");
                Console.WriteLine(p2Name + " Wins!");
                Console.Write("GGs. Do you want to play again? (yes/no) : ");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "yes")
                {
                    Program.resetBoard();
                }
                else
                {
                    Console.Write("Thanks for playing");
                    play = false;
                }
            }
        }
    }

    public static void printBoard()
    {
        Console.Clear();
        Console.WriteLine();
        for (int r = 0; r < board.GetLength(0); r++)
        {
            for (int c = 0; c < board.GetLength(1); c++)
            {
                if (board[r, c] == 0)
                {
                    Console.Write(" - ");
                }
                else if (board[r, c] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" O ", Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" O ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("");
        }
    }

    public static void resetBoard()
    {
        Console.Clear();
        Console.WriteLine();
        for(int r = 0; r < board.GetLength(0); r++)
        {
            for(int c = 0; c < board.GetLength(1); c++)
            {
                board[r, c] = 0;
            }
        }
    }

    public static bool winChecker(int player)
    {
        return ((checkHz(player) || checkVt(player)) || checkDiagonal(player));
    }

    public static bool emptyChecker()
    {
        bool ret = false;
        for (int r = 0; r < board.GetLength(0); r++)
        {
            for (int c = 0; c < board.GetLength(1); c++)
            {
                if (board[r,c] == 1 || board[r,c] == 2)
                {
                    ret = true;
                }
                else
                {
                    return false;
                }
            }
        }
        return ret;
    }

    public static bool checkHz(int player)
    {
        int count = 0;
        for (int x = 0; x < 6; x++)
        {
            for (int i = 0; i < 7; i++)
            {

                if (board[x, i] == player)
                {
                    count++;
                }
                if (count >= 4)
                {
                    return true;
                }
                else if (board[x, i] != player)
                {
                    count = 0;
                }
            }
        }
        return false;
    }

    public static bool checkVt(int player)
    {
        int count = 0;
        for (int i = 0; i < 7; i++)
        {
            for (int x = 5; x >= 0; x--)
            {
                if (board[x, i] == player)
                {
                    count++;
                }
                if (count >= 4)
                {
                    return true;
                }
                else if (board[x, i] != player)
                {
                    count = 0;
                }
            }
            count = 0;
        }
        return false;
    }

    public static bool checkDiagonal(int player)
    {
        return (checkRightDiagonal(player) || checkLeftDiagonal(player));
    }

    public static bool checkRightDiagonal(int player)
    {
        int count = 0;
        int i = 1;
        bool runner = true;
        for (int r = 5; r >= 0; r--)
        {
            for (int c = 0; c < 7; c++)
            {
                if (board[r, c] == player)
                {
                    count++;
                    while (runner)
                    {
                        if (c + 1 > 6)
                        {
                            return false;
                        }
                        if (board[r - i, c + i] == player)
                        {
                            count++;
                            i++;
                            if (count == 4)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            runner = false;
                        }
                    }

                }
            }
        }
        return false;
    }
    public static bool checkLeftDiagonal(int player)
    {
        int count = 0;
        int i = 1;
        bool runner = true;
        for (int r = 5; r >= 0; r--)
        {
            for (int c = 0; c < 7; c++)
            {
                if (board[r, c] == player)
                {
                    count++;
                    while (runner)
                    {
                        if (c - i < 0)
                        {
                            return false;
                        }
                        if (board[r - i, c - i] == player)
                        {
                            count++;
                            i++;
                            if (count == 4)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            runner = false;
                        }
                    }

                }
            }
        }
        return false;
    }

    public static void changeTurn(int num)
    {
        if (num == playerOne)
        {
            turn = playerTwo;
        }
        else
        {
            turn = playerOne;
        }
    }

    public bool playAgain(string answer)
    {
        if (answer.ToLower() == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void move(int position, int player)
    {
        if (position < 0 || position > 6)
        {
            Console.WriteLine("Invalid Input: Please enter a number between 0-6. Try again!");
            position = Int32.Parse(Console.ReadLine());
        }
        if (board[0, position] == 1 || board[0, position] == 2)
        {
            Console.WriteLine("That column is full. Try again!");
            position = Int32.Parse(Console.ReadLine());
        }
        int curr = 0;
        bool runner = true;
        while (runner)
        {
            if (curr == 5) //case if its the first piece in the col
            {
                board[curr, position] = player;
                runner = false;
            }
            else if (board[curr, position] == 0 && board[curr + 1, position] == 0)
            {
                curr++;
            }
            else
            {
                board[curr, position] = player;

                runner = false;
            }
        }
    }
    
}




