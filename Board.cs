using System.Numerics;

namespace TicTacToe
{
    internal class Board
    {
        private string[,] br;

        public Board() 
        {
            br = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    br[i, j] = ((j + 1) + (3 * i)).ToString();
                }
            }
        }
        public void EnterMove(int number,string znak = "O")
        {
            while (true)
            {
                if (number > 9 || number < 1)
                {
                    Console.WriteLine("liczba poza zakresem");
                    number = int.Parse(Console.ReadLine());
                    continue;
                }
                if (br[(number - 1) / 3, (number - 1) % 3] == "X" || br[(number - 1) / 3, (number - 1) % 3] == "O")
                {
                    Console.WriteLine("Pole jest już zajęte");
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
