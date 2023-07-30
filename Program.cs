using TicTacToeLib;

Game game = new();

// game loop
do
{
    if (NextMove(game))
    {
        ShowBoard();

        if (game.IsGameOver())
        {
            Console.WriteLine($"Winner: {game.Winner}");
            break;
        }
    }
 
}
while (true);

// display game board
void ShowBoard()
{
    for (int y = 0; y < 3; y++)
    {
        for (int x = 0; x < 3; x++)
        {
            Console.Write(game.Board[x, y]);
            if (x < 2)
            {
                Console.Write('|');
            }
        }
        Console.WriteLine("\n-----");
    }
}

static bool NextMove(Game game)
{
    try
    {
        string? input = null;

        Console.Write($"Player {game.Player}:");

        input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            return false; ;
        }

        if (input.Length == 2 && int.TryParse(input, out _))
        {
            game.MakeMove(int.Parse(input[0].ToString()), int.Parse(input[1].ToString()));
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