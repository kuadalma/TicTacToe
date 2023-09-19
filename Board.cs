<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

=======
>>>>>>> dev
namespace TicTacToe
{
    internal class Board
    {
<<<<<<< HEAD
        private const int rows = 3;
        private const int cols = 3;
        private const string player1 = "X";
        private const string player2 = "O";
        private const string hline = " + - - - + - - - + - - - + \n";
        private const string vline = " |       |       |       | \n";
        private string[,] guess;
=======
        private string[,] br;
>>>>>>> dev

        public Board() 
        {
            br = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
<<<<<<< HEAD
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
=======
                    br[i, j] = ((j + 1) + (3 * i)).ToString();
                    //br[i, j] = " ";
                }
            }
        }
        public void EnterMove(string input,string znak = "O")
>>>>>>> dev
        {
            int number;
            while (true)
            {
                if (int.TryParse(input, out number)) break;
                Console.WriteLine("liczba poza zakresem :");
                input = Console.ReadLine();
            }
            while (true)
            {
                if (number > 9 || number < 1)
                {
                    Console.WriteLine("liczba poza zakresem :");
                    number = int.Parse(Console.ReadLine());
                    continue;
                }
                if (br[(number - 1) / 3, (number - 1) % 3] == "X" || br[(number - 1) / 3, (number - 1) % 3] == "O")
                {
                    Console.WriteLine("Pole jest już zajęte :");
                    number = int.Parse(Console.ReadLine());
                    continue;
                }
                break;
            }
            br[(number - 1) / 3, (number - 1) % 3] = znak;
        }
        private bool DrawCheak()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (br[i, j] != "X" && br[i, j] != "O") return false;
                }
            }
            Console.WriteLine("Remis");
            return true;
        }
        public bool VictoryCheck()
        {
            List<string> sign = new List<string> { "X", "O" };
            for (int i = 0; i < sign.Count; i++)
            {
                if ((br[0, 0] == sign[i] && br[1, 1] == sign[i] && br[2, 2] == sign[i]) ||
                (br[0, 2] == sign[i] && br[1, 1] == sign[i] && br[2, 0] == sign[i]))
                {
                    Console.WriteLine("ZWYCIESTWO " + sign[i]);
                    return true;
                }
                for (int j = 0; j < 3; j++)
                {
                    int hpass = 0;
                    int vpass = 0;
                    for (int l = 0; l < 3; l++)
                    {
                        if (br[j, l] == sign[i]) hpass++;
                        if (br[l, j] == sign[i]) vpass++;
                    }
                    if (hpass == 3 || vpass == 3)
                    {
                        Console.WriteLine("ZWYCIESTWO " + sign[i]);
                        return true;
                    }
                }
            }
            if (DrawCheak()) return true;
            return false;
        }

        public string[,] GetBoard()
        {
            return br;
        }
        private string Draw_board()
        {
            const string hline = " + - - - + - - - + - - - + \n";
            const string vline = " |       |       |       | \n";
            string res = "";
            for (int i = 0; i < 3; i++)
            {
                res += hline + vline;
                for (int j = 0; j < 3; j ++)
                {
                    res += $" |   {br[i, j]}"  + @"  ";
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
