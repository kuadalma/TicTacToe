using TicTacToe;
Board board = new();

Console.WriteLine(board);
while (true)
{
    board.EnterMove(int.Parse(Console.ReadLine()));
    Console.Clear();
    Console.WriteLine(board);
    if (board.VictoryCheck()) break;
}