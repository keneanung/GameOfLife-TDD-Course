using System;
using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.Lib.Domain;
using GameOfLife.Lib.Logic;
using Xunit;

namespace GameOfLife.Lib.Tests.Unit.Domain
{
    public class GameBoardTests
    {
        [Fact]
        public void GetCellAt_Should_ReturnCellAtGivenCoordinates()
        {
            var cell = new Cell();
            var systemUnderTest = new GameBoard(new[] {new[] {cell}}, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            Cell returnedCell = systemUnderTest.GetCellAt(0, 0);

            returnedCell.Should().BeSameAs(cell);
        }

        [Fact]
        public void GetCellAt_Should_ReturnCellAtGivenCoordinates_If_MultipleCellsAreInBoard()
        {
            var cell = new Cell
            {
                Alive = true,
            };
            Cell[][] cellArray =
            {
                new[] {new Cell(), new Cell(), new Cell()},
                new[] {new Cell(), new Cell(), new Cell()},
                new[] {new Cell(), new Cell(), new Cell()},
                new[] {new Cell(), cell, new Cell()},
            };
            var systemUnderTest = new GameBoard(cellArray, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            Cell returnedCell = systemUnderTest.GetCellAt(1, 3);

            returnedCell.Should().BeSameAs(cell);
        }

        [Fact]
        public void GetCellAt_Should_ThrowIndexOutOfBoundsExceptionWithSensibleMessage_If_XCoordinateIsOutOfBounds()
        {
            var systemUnderTest = new GameBoard(new[] {new[] {new Cell()}}, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            Action throwingAction = () => systemUnderTest.GetCellAt(1, 0);

            throwingAction.Should()
                .Throw<IndexOutOfRangeException>()
                .WithMessage("Expected coordinates to be on the board [(0,0) - (0,0)], but got (1,0)");
        }

        [Fact]
        public void GetCellAt_Should_ThrowIndexOutOfBoundsExceptionWithSensibleMessage_If_YCoordinateIsOutOfBounds()
        {
            var systemUnderTest = new GameBoard(new[] {new[] {new Cell()}}, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            Action throwingAction = () => systemUnderTest.GetCellAt(0, 1);

            throwingAction.Should()
                .Throw<IndexOutOfRangeException>()
                .WithMessage("Expected coordinates to be on the board [(0,0) - (0,0)], but got (0,1)");
        }

        [Fact]
        public void Constructor_Should_ThrowJaggedArrayException_If_CellArrayDoesNotContainInnerArraysOfSameLength()
        {
            Cell[][] wrongCellArray =
            {
                new[] {new Cell(), new Cell()},
                new[] {new Cell()},
            };

            Func<GameBoard> throwingFunc = () => new GameBoard(wrongCellArray, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            throwingFunc.Should().Throw<JaggedArrayException>();
        }

        [Fact]
        public void Constructor_Should_EmptyArrayException_If_OuterArrayIsEmpty()
        {
            Cell[][] wrongCellArray = Array.Empty<Cell[]>();

            Func<GameBoard> throwingFunc = () => new GameBoard(wrongCellArray, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            throwingFunc.Should().Throw<EmptyArrayException>();
        }

        [Fact]
        public void Constructor_Should_EmptyArrayException_If_OuterArrayContainsEmptyArray()
        {
            Cell[][] wrongCellArray =
            {
                Array.Empty<Cell>(),
            };

            Func<GameBoard> throwingFunc = () => new GameBoard(wrongCellArray, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            throwingFunc.Should().Throw<EmptyArrayException>();
        }

        [Fact]
        public void GetNeighbours_Should_ReturnAllNeighboursForGivenCoordinate()
        {
            Cell[] neighbours =
            {
                new(),
                new(),
                new(),
                new(),
                new(),
                new(),
                new(),
                new(),
            };

            Cell[][] cells =
            {
                new[] {neighbours[0], neighbours[1], neighbours[2]},
                new[] {neighbours[3], new(), neighbours[4]},
                new[] {neighbours[5], neighbours[6], neighbours[7]},
            };
            var systemUnderTest = new GameBoard(cells, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            IEnumerable<Cell> returnedNeighbours = systemUnderTest.GetNeighbours(1, 1);

            returnedNeighbours.Should()
                .Contain(neighbours)
                .And.HaveSameCount(neighbours);
        }

        [Fact]
        public void GetNeighbours_Should_ReturnAllNeighboursForGivenCoordinate_UpperLeftCoordinateIsCorner()
        {
            Cell[] neighbours =
            {
                new(),
                new(),
                new(),
            };

            Cell[][] cells =
            {
                new[] {new(), neighbours[0]},
                new[] {neighbours[1], neighbours[2]},
            };
            var systemUnderTest = new GameBoard(cells, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            IEnumerable<Cell> returnedNeighbours = systemUnderTest.GetNeighbours(0, 0);

            returnedNeighbours.Should()
                .Contain(neighbours)
                .And.HaveSameCount(neighbours);
        }

        [Fact]
        public void GetNeighbours_Should_ReturnAllNeighboursForGivenCoordinate_LowerRightCoordinateIsCorner()
        {
            Cell[] neighbours =
            {
                new(),
                new(),
                new(),
            };

            Cell[][] cells =
            {
                new[] {neighbours[0], neighbours[1]},
                new[] {neighbours[2], new()},
            };
            var systemUnderTest = new GameBoard(cells, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            IEnumerable<Cell> returnedNeighbours = systemUnderTest.GetNeighbours(1, 1);

            returnedNeighbours.Should()
                .Contain(neighbours)
                .And.HaveSameCount(neighbours);
        }

        [Fact]
        public void GetNeighbours_Should_ThrowIndexOutOfBoundsExceptionWithSensibleMessage_If_XCoordinateIsOutOfBounds()
        {
            var systemUnderTest = new GameBoard(new[] {new[] {new Cell()}}, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            Action throwingAction = () => systemUnderTest.GetNeighbours(1, 0);

            throwingAction.Should()
                .Throw<IndexOutOfRangeException>()
                .WithMessage("Expected coordinates to be on the board [(0,0) - (0,0)], but got (1,0)");
        }

        [Fact]
        public void GetNeighbours_Should_ThrowIndexOutOfBoundsExceptionWithSensibleMessage_If_YCoordinateIsOutOfBounds()
        {
            var systemUnderTest = new GameBoard(new[] {new[] {new Cell()}}, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            Action throwingAction = () => systemUnderTest.GetNeighbours(0, 1);

            throwingAction.Should()
                .Throw<IndexOutOfRangeException>()
                .WithMessage("Expected coordinates to be on the board [(0,0) - (0,0)], but got (0,1)");
        }        [Fact]
        public void NextRound_Should_ReturnDeadCell_If_BoardConsistsOfASingleCell()
        {
            GameBoard systemUnderTest = new(new[] {new[] {new Cell {Alive = true}}}, new CoreRule(), new GameOfLifeFactory(new CoreRule()));

            GameBoard returnedBoard = systemUnderTest.NextRound();

            returnedBoard.GetCellAt(0, 0).Should().BeDead();
        }

        [Fact]
        public void NextRound_Should_ReturnAliveCell_If_ThreeOfFourCellsAreAlive()
        {
            GameBoard systemUnderTest = new(
                new[]
                {
                    new[] {new Cell {Alive = false}, new Cell {Alive = true}},
                    new[] {new Cell {Alive = true}, new Cell {Alive = true}},
                }, new CoreRule(),
                new GameOfLifeFactory(new CoreRule()));

            GameBoard returnedBoard = systemUnderTest.NextRound();

            returnedBoard.GetCellAt(0, 0).Should().BeAlive();
        }

        [Fact]
        public void NextRound_Should_ReturnVerticalLine_If_HorizontalLineWasStart()
        {
            GameBoard systemUnderTest = new(
                new[]
                {
                    new[] {new Cell {Alive = false}, new Cell {Alive = false}, new Cell {Alive = false}},
                    new[] {new Cell {Alive = true}, new Cell {Alive = true}, new Cell {Alive = true}},
                    new[] {new Cell {Alive = false}, new Cell {Alive = false}, new Cell {Alive = false}},
                }, new CoreRule(),
                new GameOfLifeFactory(new CoreRule()));

            GameBoard returnedBoard = systemUnderTest.NextRound();

            returnedBoard.GetCellAt(1, 0).Should().BeAlive();
            returnedBoard.GetCellAt(1, 1).Should().BeAlive();
            returnedBoard.GetCellAt(1, 2).Should().BeAlive();
        }
    }
}