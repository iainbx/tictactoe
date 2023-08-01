using TicTacToeLib;

Game game = new();

Console.WriteLine($"Enter XY square number to make a move, 00 is top left, 22 is bottom right.");
DisplayBoard();


// game loop
do
{
    if (NextMove(game))
    {
        DisplayBoard();

        if (game.Status == Game.GameStatus.GameOver)
        {
            Console.WriteLine($"{game.Result}");
            break;
        }
    }

}
while (true);

// display game board
void DisplayBoard()
{
    Console.WriteLine("\n");
    for (int y = 0; y < 3; y++)
    {
        for (int x = 0; x < 3; x++)
        {
            Console.Write(game.Board[x, y]);
            if (x < 2)
            {
                Console.Write(" | ");
            }
        }
        if (y < 2)
        {
            Console.WriteLine("\n---------");
        }
        else {
             Console.WriteLine("\n");
        }
    }
}

// input move and play move
bool NextMove(Game game)
{
    try
    {
        string? input = null;

        Console.Write($"Player {game.CurrentPlayer}:");

        input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine($"Invalid move");
            return false; ;
        }

        if (input.Length == 2 && int.TryParse(input, out _))
        {
            game.Move(int.Parse(input[0].ToString()), int.Parse(input[1].ToString()));
            return true;
        }
        else
        {
            Console.WriteLine($"Invalid move");
            return false;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
}