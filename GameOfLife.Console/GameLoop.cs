using System.Threading;
using GameOfLife.Lib.Domain;

namespace GameOfLife.Console
{
    public class GameLoop
    {
        private readonly IOutput _output;

        public GameLoop(IOutput output)
        {
            _output = output;
        }

        public void Run(
            GameBoard gameBoard,
            int numberOfRounds,
            int delayInSeconds = 0)
        {
            _output.Output(gameBoard);
            for (var i = 0; i < numberOfRounds; i++)
            {
                Thread.Sleep(delayInSeconds * 1000);
                gameBoard = gameBoard.NextRound();
                _output.Output(gameBoard);
            }
        }
    }
}