using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        private const int rows = 3;
        private const int cols = 3;
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
                    guess[i, j] = ((i + 1) + (3 * j)).ToString();
                }
            }
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
