using System;
using System.Buffers;
using System.ComponentModel.Design;
using System.Threading.Channels;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)


        {
            char currentPlayer = 'X';
            bool gameOver = false;

            char[,] board = new char[3, 3];     // Declare and initiating the board(2D Array)
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }

            while (!gameOver)
            {


                // Tic Tac Toe Game
                                
                DisplayBoard(board);
                if (MakeMove(board, currentPlayer))
                {
                    DisplayBoard(board); // ⬅️ Show move just made
                    if (CheckWinner(board, currentPlayer))
                    {
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameOver = true;
                    }
                    else
                    {
                        currentPlayer = SwitchPlayer(currentPlayer); // ✅ Now switch turn
                    }
                }
              
                //To display the board
                //double for loop 

                static void DisplayBoard(char[,] board)
                {
                    Console.WriteLine("Current Board:");
                    Console.WriteLine("-------------");

                    // Loop through the board and print each cell

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i, j] == 'X')
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write('X');
                                Console.ResetColor();
                            }
                            else if (board[i, j] == 'O')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write('O');
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(' ');
                            }


                            if (j < 2) Console.Write("|");  // Add | between columns
                        }

                        Console.WriteLine();               // Move to next row
                        if (i < 2) Console.WriteLine("-+-+-"); // Add separator between rows


                    }
                }

                //For Move system 

                static bool MakeMove(char[,] board, char currentPlayer)
                {
                    int move;
                    Console.WriteLine($"Player {(currentPlayer == 'X' ? "1" : "2")}: Make a Move (1-9) and you are {currentPlayer}");
                    move = Convert.ToInt32(Console.ReadLine());

                    if (move < 1 || move > 9)
                    {
                        Console.WriteLine("Move invalid enter a valid one");
                        return false;
                    }
                    else
                    {
                        move = move - 1;
                        int row = move / 3;
                        int col = move % 3;
                        if (board[row, col] == ' ')
                        {
                            board[row, col] = currentPlayer;
                            Console.WriteLine("Move was successful");
                            currentPlayer = SwitchPlayer(currentPlayer);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Cell occupied try again");
                            return false;
                        }
                    }
                }
                static char SwitchPlayer(char currentPlayer)
                {
                    return (currentPlayer == 'X') ? 'O' : 'X';
                }

                // Win condtions 
                static bool CheckWinner(char[,] board, char currentPlayer)
                {
                    // Check rows and columns
                    for (int i = 0; i < 3; i++)
                    {
                        // Check row
                        if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                            return true;

                        // Check column
                        if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                            return true;
                    }

                    // Check diagonals
                    if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                        return true;

                    if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                        return true;

                    // No winner
                    return false;
                }


            }
        }  
            
        
    }
}