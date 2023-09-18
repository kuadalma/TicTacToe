namespace TicTacToe
{
    internal class SI
    {
        public SI() { }
        public int FindBestMove(string[,] br)
        {
            int bestMoveValue = int.MinValue;
            int bestMovePosition = -1;

            for (int pos = 1; pos <= 9; pos++)
            {
                int row = (pos - 1) / 3;
                int col = (pos - 1) % 3;

                if (br[row, col] != "X" && br[row, col] != "O")
                {
                    br[row, col] = "O";
                    int moveValue = MinValue(br, int.MinValue, int.MaxValue);
                    br[row, col] = (pos).ToString();

                    if (moveValue > bestMoveValue)
                    {
                        bestMoveValue = moveValue;
                        bestMovePosition = pos;
                    }
                }
            }
            return bestMovePosition;
        }
        private int MaxValue(string[,] br, int alpha, int beta)
        {
            int result = Evaluate(br);

            if (result != 0)
                return result;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (br[i, j] != "X" && br[i, j] != "O")
                    {
                        br[i, j] = "O";
                        alpha = Math.Max(alpha, MinValue(br, alpha, beta));
                        br[i, j] = (i * 3 + j + 1).ToString();
                        if (alpha >= beta)
                            return beta;
                    }
                }
            }
            return alpha;
        }
        private int MinValue(string[,] br, int alpha, int beta)
        {
            int result = Evaluate(br);
            if (result != 0)
                return result;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (br[i, j] != "X" && br[i, j] != "O")
                    {
                        br[i, j] = "X";
                        beta = Math.Min(beta, MaxValue(br, alpha, beta));
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
