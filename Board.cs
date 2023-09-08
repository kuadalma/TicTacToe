using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        private const int rows = 3;
        private const int cols = 3;
        private const string player1 = "X";
        private const string player2 = "O";
        private const string hline = " + - - - + - - - + - - - + \n";
        private const string vline = " |       |       |       | \n";
        private string[,] guess;

        public Board() 
        {
            guess = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    guess[i, j] = ((j + 1) + (3 * i)).ToString();
                }
            }
        }
        public void SetGuess(string player = player1) 
        {
            int x = 11;
            while (true)
            {
                Console.Write(": ");
                try
                {
                    x = int.Parse(Console.ReadLine())-1;

                    if (x < 3)
                    {
                        guess[0, x] = player;
                        break;
                    }
                    if (x < 6)
                    {
                        guess[1, x - 3] = player;
                        break;

                    }
                    if (x < 9)
                    {
                        guess[2, x - 6] = player;
                        break;
                    }

                    Console.WriteLine("błędny ruch");
                }
                catch
                {
                    Console.WriteLine("błędny ruch");
                }
                
            }
            if (player == player1)
            {
                player = player2;
            }
            else
            {
                player = player1;
            }
        }
        public string[,] GetBoard()
        {
            return guess;
        }
        //łatane ne szybko
        private string gcell(string guess)
        {
            return $" |   {guess}";
        }
        public string Draw_board()
        {
            string res = "";
            for (int i = 0; i < rows; i++)
            {
                res += hline + vline;
                for (int j = 0; j < cols; j ++)
                {
                    res +=  gcell(guess[i, j]) + @"  ";
                }
                res += @" | " + '\n' + vline;
            }
            res += hline;
            return res;    
        }
        public override string ToString()
        {
            return Draw_board();
        }

    }
}
