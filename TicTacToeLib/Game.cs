namespace TicTacToeLib;

public class Game
{
    public Game()
    {
        Start();
    }

    public readonly char[,] Board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
    public char CurrentPlayer { get; set; }
    public string? Result { get; set; }

    public short RemainingMoves = 9;

    public enum GameStatus { GameInProgress, GameOver };
    public GameStatus Status { get; set; }

    public void Start()
    {
        ClearBoard();
        CurrentPlayer = 'X';
        Result = "unknown";
        Status = GameStatus.GameInProgress;
    }

    /// <summary>
    /// Clear moves from board
    /// </summary>
    private void ClearBoard()
    {
        for (int x = 0; x < Board.GetLength(0); x++) {
            for (int y = 0; y < Board.GetLength(1); y++) {
                Board[x, y] = ' ';
            }
        }
        RemainingMoves = 9;
    }

    /// <summary>
    /// Make a move in the game
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <exception cref="ArgumentException"></exception>
    public void Move(int x, int y)
    {
        if (RemainingMoves == 0)
        {
            throw new ArgumentException("There are no moves left");
        }
        if (x > 2 || y > 2)
        {
            throw new ArgumentException("Argument should be less than 3");
        }
        else if (Board[x, y] != ' ')
        {
            throw new ArgumentException("Square is not empty, try again");
        }

        Board[x, y] = CurrentPlayer;
        RemainingMoves = --RemainingMoves;

        UpdateStatus();

        if (Status == GameStatus.GameInProgress)
        {
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
        }

    }

    /// <summary>
    /// Update game status and set result if game over
    /// </summary>
    public void UpdateStatus()
    {
        // check vertical win
        for (int x = 0; x < 3; x++)
        {
            if (Board[x, 0] == Board[x, 1] && Board[x, 0] == Board[x, 2])
            {
                if (Board[x, 0] != ' ')
                {
                    Status = GameStatus.GameOver;
                    Result = $"Winner {Board[x, 0]}";
                    return;
                }
            }
        }

        // check horizontal win
        for (int y = 0; y < 3; y++)
        {
            if (Board[0, y] == Board[1, y] && Board[0, y] == Board[2, y])
            {
                if (Board[0, y] != ' ')
                {
                    Status = GameStatus.GameOver;
                    Result = $"Winner {Board[0, y]}";
                    return;
                }
            }
        }

        // check diagonal win
        if (Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
        {
            if (Board[0, 0] != ' ')
            {
                Status = GameStatus.GameOver;
                Result = $"Winner {Board[0, 0]}";
                return;
            }
        }
        if (Board[2, 0] == Board[1, 1] && Board[2, 0] == Board[0, 2])
        {
            if (Board[2, 0] != ' ')
            {
                Status = GameStatus.GameOver;
                Result = $"Winner {Board[2, 0]}";
                return;
            }
        }

        // check remaining moves
        if (RemainingMoves == 0)
        {
            // draw
            Status = GameStatus.GameOver;
            Result = $"Draw";
            return;
        }

    }

}
