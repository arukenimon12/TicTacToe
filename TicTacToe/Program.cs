using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static string[,] board = new string[3, 3];

        static void ResetBoard()
        {
            int index = 1; ;
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = $"{index}";
                    index++;
                }
            }
        }

        static int playerTurn = 1;
        static char[] pSign = { 'X', 'O' };

        static char currPlayer() => (playerTurn == 1) ? pSign[0] : pSign[1];

        static bool isOver = false;

        static void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0,0], board[0, 1], board[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |     ");
        }

        static bool isValidInput(int choice)
        {
            int index = 1; ;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(choice == index)
                    {
                        if (board[i,j] != "X" && board[i, j] != "O")
                        {
                            return true;
                        }
                    }
                    index++;
                }
            }
            return false;
        }

        static void UpdateBoard(int boardIndex)
        {
            int index = 1; ;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(index == boardIndex)
                    {
                        board[i, j] = currPlayer().ToString();
                    }
                    index++;
                }
            }
        }
        static void SwitchTurn()
        {
            playerTurn = (playerTurn == 1) ? 2 : 1;
        }

        static bool CheckWin()
        {
            
            foreach(char PSIGN in pSign)
            {
                //Hori
                if ((board[0, 0] == PSIGN.ToString() && board[0, 1] == PSIGN.ToString() && board[0, 2] == PSIGN.ToString()) ||
                    (board[1, 0] == PSIGN.ToString() && board[1, 1] == PSIGN.ToString() && board[1, 2] == PSIGN.ToString()) ||
                    (board[2, 0] == PSIGN.ToString() && board[2, 1] == PSIGN.ToString() && board[2, 2] == PSIGN.ToString()))
                {
                    return true;
                }
                if ((board[0, 0] == PSIGN.ToString() && board[1, 0] == PSIGN.ToString() && board[2, 0] == PSIGN.ToString()) ||
                   (board[0, 1] == PSIGN.ToString() && board[1, 1] == PSIGN.ToString() && board[2, 1] == PSIGN.ToString()) ||
                   (board[0, 2] == PSIGN.ToString() && board[1, 2] == PSIGN.ToString() && board[2, 2] == PSIGN.ToString()))
                {
                    return true;
                }
                if ((board[0, 0] == PSIGN.ToString() && board[1, 1] == PSIGN.ToString() && board[2, 2] == PSIGN.ToString()) ||
                   (board[0, 2] == PSIGN.ToString() && board[1, 1] == PSIGN.ToString() && board[2, 0] == PSIGN.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        static bool isGameOver()
        {
            bool isGameOver_ = false;

            for(int i = 0; )

            return false;
        }

        static void Main(string[] args)
        {
            ResetBoard();
            do
            {
                Console.Clear();
                DrawBoard();

                back:
                Console.WriteLine($"Player {playerTurn}'s turn: ");
                string choice = Console.ReadLine();

                try
                {
                    int iChoice = Convert.ToInt32(choice);

                    if (iChoice > 9 || iChoice < 1)
                        throw new Exception();

                    if (isValidInput(iChoice))
                    {
                        UpdateBoard(iChoice);

                        if(CheckWin())
                        {
                            isOver = true;
                            Console.Clear();
                            DrawBoard();
                            Console.WriteLine($"Player {playerTurn} wins!");
                        }else if()



                        SwitchTurn();
                    }
                }
                catch(Exception e)
                {
                    goto back;
                }

            } while (!isOver);
            
            Console.ReadKey();
        }
    }
}
