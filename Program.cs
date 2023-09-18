using TicTacToe;
Board board = new();
SI SI = new();


Console.WriteLine(board);
while (true)
{
    board = new();
    while (true)
    {
        board.EnterMove(SI.FindBestMove(board.GetBoard()));
        Console.Clear();
        Console.WriteLine(board);
        if (board.VictoryCheck()) break;
        board.EnterMove(int.Parse(Console.ReadLine()), "X");
        Console.Clear();
        Console.WriteLine(board);
        if (board.VictoryCheck()) break;
    }
    Console.ReadLine();
}
