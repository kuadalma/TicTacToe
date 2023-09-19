namespace TicTacToe
{
    internal class SI
    {
        public SI() { }
        public string FindBestMove(string[,] br)
        {
            int depth = 5;
            int bestScore = int.MinValue;
            int bestMove = -1;

            for (int i = 1; i <= 9; i++)
            {
                int row = (i - 1) / 3;
                int col = (i - 1) % 3;

                if (br[row, col] == "X" || br[row, col] == "O") continue;

                br[row, col] = "O";
                int score = MinValue(br, int.MinValue, int.MaxValue, depth -1);
                br[row, col] = (i).ToString();

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
            return (bestMove).ToString();
        }
        //private int Minimax(string[,] br, string who)
        //{
        //    int score = Evaluate(br, who);
        //    if (score != 0)
        //    {
        //        return score;
        //    }

        //    int bestScore = who == "O" ? int.MinValue : int.MaxValue;

        //    int CalcBest(int x, int y) => (who == "O" ? x > y : y > x) ? x : y;

        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if (br[i, j] != "X" && br[i, j] != "O")
        //            {
        //                br[i, j] = who;
        //                int currentScore = Minimax(br, who == "O" ? "X" : "O");
        //                br[i, j] = (i * 3 + j + 1).ToString();

        //                bestScore = CalcBest(bestScore, currentScore);
        //            }
        //        }
        //    }
        //    return bestScore;
        //}
        private int MaxValue(string[,] br, int alpha, int beta, int depth)
        {
            int result = Evaluate(br);

            if (result != 0 || depth == 0)
                return result;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (br[i, j] != "X" && br[i, j] != "O")
                    {
                        br[i, j] = "O";
                        alpha = Math.Max(alpha, MinValue(br, alpha, beta, depth - 1));
                        br[i, j] = (i * 3 + j + 1).ToString();
                        if (alpha >= beta)
                            return beta;
                    }
                }
            }
            return alpha;
        }
        private int MinValue(string[,] br, int alpha, int beta, int depth)
        {
            int result = Evaluate(br);
            if (result != 0 || depth == 0)
                return result;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (br[i, j] != "X" && br[i, j] != "O")
                    {
                        br[i, j] = "X";
                        beta = Math.Min(beta, MaxValue(br, alpha, beta, depth - 1));
                        br[i, j] = (i * 3 + j + 1).ToString();
                        if (alpha >= beta)
                            return alpha;
                    }
                }
            }
            return beta;
        }

        private int Evaluate(string[,] br)
        {
            for (int i = 0; i < 3; i++)
            {
                if (br[i, 0] == br[i, 1] && br[i, 1] == br[i, 2])
                {
                    if (br[i, 0] == "O") return +10;
                    return -10;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (br[0, i] == br[1, i] && br[1, i] == br[2, i])
                {
                    if (br[0, i] == "O") return +10;
                    return -10;
                }
            }
            if (br[0, 0] == br[1, 1] && br[1, 1] == br[2, 2])
            {
                if (br[0, 0] == "O") return +10;
                return -10;
            }
            if (br[0, 2] == br[1, 1] && br[1, 1] == br[2, 0])
            {
                if (br[0, 2] == "O") return +10;
                return -10;
            }
            return 0;
        }
    }
}
