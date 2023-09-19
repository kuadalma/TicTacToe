using TicTacToe;
Board board = new();
SI SI = new();


while (true)
{
    board = new();
    //board.EnterMove("5", "O");
    Console.WriteLine(board);
    while (true)
    {
        board.EnterMove(SI.FindBestMove(board.GetBoard()));
        Console.Clear();
        Console.WriteLine(board);
        if (board.VictoryCheck()) break;
        board.EnterMove(Console.ReadLine(), "X");
        Console.Clear();
        Console.WriteLine(board);
        if (board.VictoryCheck()) break;
    }
    Console.ReadLine();
}
