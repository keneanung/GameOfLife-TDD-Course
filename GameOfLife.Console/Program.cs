using System;
using GameOfLife.Lib.Domain;
using GameOfLife.Lib.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace GameOfLife.Console
{
    public static class Program
    {
        public static int Main()
        {
            int numberOfRounds = GetNumberOfRounds();

            IServiceProvider serviceProvider = BuildServiceProvider();

            GameBoard board = CreateStartingBoard(serviceProvider);

            RunGameLoop(serviceProvider, board, numberOfRounds);

            return 0;
        }

        private static int GetNumberOfRounds()
        {
            System.Console.WriteLine("How many rounds?");
            string? numberOfRoundsString = System.Console.ReadLine();
            if (int.TryParse(numberOfRoundsString, out int numberOfRounds))
            {
                return numberOfRounds;
            }

            System.Console.WriteLine("This is not a number...");
            throw new Exception();
        }

        private static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .UseGameOfLife()
                .AddSingleton<GameLoop>()
                .AddSingleton<IOutput, ConsoleOutput>()
                .BuildServiceProvider();
        }

        private static GameBoard CreateStartingBoard(IServiceProvider serviceProvider)
        {
            BoardBuilder boardBuilder = serviceProvider
                .GetService<IGameOfLifeFactory>()
                !.BoardBuilder;

            GameBoard board = boardBuilder.SetSizeX(3)
                .SetSizeY(3)
                .SetAlive(0, 1)
                .SetAlive(1, 1)
                .SetAlive(2, 1)
                .GetBoard();
            return board;
        }

        private static void RunGameLoop(
            IServiceProvider serviceProvider,
            GameBoard board,
            int numberOfRounds)
        {
            GameLoop gameLoop = serviceProvider.GetService<GameLoop>()!;
            gameLoop.Run(board, numberOfRounds, 1);
        }
    }
}