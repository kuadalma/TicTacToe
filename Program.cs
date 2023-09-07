using TicTacToe;
Board board = new();
while (true)
{
    Console.WriteLine(board);
    if (null != Console.ReadLine()) break;
}