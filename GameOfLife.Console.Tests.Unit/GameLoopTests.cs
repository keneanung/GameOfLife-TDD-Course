using GameOfLife.Lib.Domain;
using GameOfLife.Lib.Logic;
using NSubstitute;
using Xunit;

namespace GameOfLife.Console.Tests.Unit
{
    public class GameLoopTests
    {
        [Fact]
        public void Run_Should_CallOutput_SixTimes_If_Running5Rounds()
        {
            var gameBoard = new GameBoard(
                new[]
                {
                    new[]
                    {
                        new Cell
                        {
                            Alive = true
                        },
                    },
                },
                new CoreRule(),
                new GameOfLifeFactory(new CoreRule()));
            IOutput outputSubstitute = Substitute.For<IOutput>();
            var systemUnderTest = new GameLoop(outputSubstitute);

            systemUnderTest.Run(gameBoard, 5);

            outputSubstitute.Received(6).Output(Arg.Any<GameBoard>());
        }

        [Fact]
        public void Run_Should_CallOutput_OneTime_If_Running0Rounds()
        {
            var gameBoard = new GameBoard(
                new[]
                {
                    new[]
                    {
                        new Cell
                        {
                            Alive = true
                        },
                    },
                },
                new CoreRule(),
                new GameOfLifeFactory(new CoreRule()));
            IOutput outputSubstitute = Substitute.For<IOutput>();
            var systemUnderTest = new GameLoop(outputSubstitute);

            systemUnderTest.Run(gameBoard, 0);

            outputSubstitute.Received(1).Output(Arg.Any<GameBoard>());
        }

        [Fact]
        public void Run_Should_CallOutput_11Times_If_Running10Rounds()
        {
            var gameBoard = new GameBoard(
                new[]
                {
                    new[]
                    {
                        new Cell
                        {
                            Alive = true
                        },
                    },
                },
                new CoreRule(),
                new GameOfLifeFactory(new CoreRule()));
            IOutput outputSubstitute = Substitute.For<IOutput>();
            var systemUnderTest = new GameLoop(outputSubstitute);

            systemUnderTest.Run(gameBoard, 10);

            outputSubstitute.Received(11).Output(Arg.Any<GameBoard>());
        }
    }
}