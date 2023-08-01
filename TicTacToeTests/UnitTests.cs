using TicTacToeLib;
using Xunit;



namespace TicTacToeTests;

public class UnitTests
{

        /// <summary>
        /// play a game which X wins
        /// </summary>
        [Fact]
        public void XWin()
        {
            Game game = new();
            game.Move(0, 0);
            Assert.Equal('X', game.Board[0, 0]);
            Assert.Equal('O', game.CurrentPlayer);
            Assert.Equal(8, game.RemainingMoves);
            Assert.Equal(Game.GameStatus.GameInProgress, game.Status);

            game.Move(1, 0);
            Assert.Equal('O', game.Board[1, 0]);
            Assert.Equal('X', game.CurrentPlayer);
            Assert.Equal(7, game.RemainingMoves);
            Assert.Equal(Game.GameStatus.GameInProgress, game.Status);

            game.Move(2, 0);
            Assert.Equal('X', game.Board[2, 0]);
            Assert.Equal('O', game.CurrentPlayer);
            Assert.Equal(6, game.RemainingMoves);
            Assert.Equal(Game.GameStatus.GameInProgress, game.Status);

            game.Move(0, 1);
            Assert.Equal('O', game.Board[0, 1]);
            Assert.Equal('X', game.CurrentPlayer);
            Assert.Equal(5, game.RemainingMoves);
            Assert.Equal(Game.GameStatus.GameInProgress, game.Status);

            game.Move(1, 1);
            Assert.Equal('X', game.Board[1, 1]);
            Assert.Equal('O', game.CurrentPlayer);
            Assert.Equal(4, game.RemainingMoves);
            Assert.Equal(Game.GameStatus.GameInProgress, game.Status);

            game.Move(2, 1);
            Assert.Equal('O', game.Board[2, 1]);
            Assert.Equal('X', game.CurrentPlayer);
            Assert.Equal(3, game.RemainingMoves);
            Assert.Equal(Game.GameStatus.GameInProgress, game.Status);

            game.Move(0, 2);
            Assert.Equal('X', game.Board[0, 2]);
            Assert.Equal('X', game.CurrentPlayer);
            Assert.Equal(2, game.RemainingMoves);
            Assert.Equal(Game.GameStatus.GameOver, game.Status);
            Assert.Equal("Winner X", game.Result);

         }


}