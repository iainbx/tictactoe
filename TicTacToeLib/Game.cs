namespace TicTacToeLib;

public class Game
{
    public Game()
    {
        Board = new char[3, 3];
        Start();
    }

    public char[,] Board { get; set; }
    public char Player { get; set; }
    public char Winner { get; set; }

    public void Start()
    {
        Board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        Player = 'X';
        Winner = ' ';
    }

    public void MakeMove(int x, int y)
    {
        if (x > 2 || y > 2)
        {
            throw new ArgumentException("argument should be less than 3");
        }
        else if (Board[x, y] != ' ')
        {
            throw new ArgumentException("cell is not empty, try again");
        }
        Board[x, y] = Player;

        // check for win or draw

        Player = Player == 'X' ? 'O' : 'X';

    }

    public bool IsGameOver()
    {
        // check vertical win
        for (int x = 0; x < 3; x++)
        {
            if (Board[x, 0] == Board[x, 1] && Board[x, 0] == Board[x, 2])
            {
                if (Board[x, 0] != ' ')
                {
                    Winner = Board[x, 0];
                    return true;
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
                    Winner = Board[0, y];
                    return true;
                }
            }
        }

        // check diagonal win
        if (Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
        {
            if (Board[0, 0] != ' ')
            {
                Winner = Board[0, 0];
                return true;
            }
        }
        if (Board[2, 0] == Board[1, 1] && Board[2, 0] == Board[0, 2])
        {
            if (Board[2, 0] != ' ')
            {
                Winner = Board[2, 0];
                return true;
            }
        }

        // check remaining moves
        short remainingMoves = 0;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (Board[x, y] == ' ')
                {
                    remainingMoves++;
                }
            }
        }
        if (remainingMoves == 0) {
            return true;
        }


        return false;
    }

}
