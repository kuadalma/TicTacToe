using TicTacToe;
Board board = new();
while (true)
{
    Console.WriteLine(board);
    board.SetGuess();
}