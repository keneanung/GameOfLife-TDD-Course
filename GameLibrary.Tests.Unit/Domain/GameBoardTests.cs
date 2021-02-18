using System;
using System.Collections.Generic;
using FluentAssertions;
using GameLibrary.Domain;
using Xunit;

namespace GameLibrary.Tests.Unit.Domain
{
    public class GameBoardTests
    {
        [Fact]
        public void GetCellAt_Should_ReturnCellAtGivenCoordinates()
        {
            var cell = new Cell();
            var systemUnderTest = new GameBoard(new[] {new[] {cell}});

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
            var systemUnderTest = new GameBoard(cellArray);

            Cell returnedCell = systemUnderTest.GetCellAt(1, 3);

            returnedCell.Should().BeSameAs(cell);
        }

        [Fact]
        public void GetCellAt_Should_ThrowIndexOutOfBoundsExceptionWithSensibleMessage_If_XCoordinateIsOUtOfBounds()
        {
            var systemUnderTest = new GameBoard(new[] {new[] {new Cell()}});

            Action throwingAction = () => systemUnderTest.GetCellAt(1, 0);

            throwingAction.Should()
                .Throw<IndexOutOfRangeException>()
                .WithMessage("Expected X coordinate to be on the board [(0,0) - (0,0)], but got 1");
        }

        [Fact]
        public void GetCellAt_Should_ThrowIndexOutOfBoundsExceptionWithSensibleMessage_If_YCoordinateIsOUtOfBounds()
        {
            var systemUnderTest = new GameBoard(new[] {new[] {new Cell()}});

            Action throwingAction = () => systemUnderTest.GetCellAt(0, 1);

            throwingAction.Should()
                .Throw<IndexOutOfRangeException>()
                .WithMessage("Expected Y coordinate to be on the board [(0,0) - (0,0)], but got 1");
        }

        [Fact]
        public void Constructor_Should_ThrowJaggedArrayException_If_CellArrayDoesNotContainInnerArraysOfSameLength()
        {
            Cell[][] wrongCellArray =
            {
                new[] {new Cell(), new Cell()},
                new[] {new Cell()},
            };

            Func<GameBoard> throwingFunc = () => new GameBoard(wrongCellArray);

            throwingFunc.Should().Throw<JaggedArrayException>();
        }

        [Fact]
        public void Constructor_Should_EmptyArrayException_If_OuterArrayIsEmpty()
        {
            Cell[][] wrongCellArray = Array.Empty<Cell[]>();

            Func<GameBoard> throwingFunc = () => new GameBoard(wrongCellArray);

            throwingFunc.Should().Throw<EmptyArrayException>();
        }

        [Fact]
        public void Constructor_Should_EmptyArrayException_If_OuterArrayContainsEmptyArray()
        {
            Cell[][] wrongCellArray =
            {
                Array.Empty<Cell>(),
            };

            Func<GameBoard> throwingFunc = () => new GameBoard(wrongCellArray);

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
            var systemUnderTest = new GameBoard(cells);

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
            var systemUnderTest = new GameBoard(cells);

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
            var systemUnderTest = new GameBoard(cells);

            IEnumerable<Cell> returnedNeighbours = systemUnderTest.GetNeighbours(1, 1);

            returnedNeighbours.Should()
                .Contain(neighbours)
                .And.HaveSameCount(neighbours);
        }

        [Fact]
        public void GetNeighbours_Should_ThrowIndexOutOfBoundsExceptionWithSensibleMessage_If_XCoordinateIsOUtOfBounds()
        {
            var systemUnderTest = new GameBoard(new[] {new[] {new Cell()}});

            Action throwingAction = () => systemUnderTest.GetNeighbours(1, 0);

            throwingAction.Should()
                .Throw<IndexOutOfRangeException>()
                .WithMessage("Expected X coordinate to be on the board [(0,0) - (0,0)], but got 1");
        }

        [Fact]
        public void GetNeighbours_Should_ThrowIndexOutOfBoundsExceptionWithSensibleMessage_If_YCoordinateIsOUtOfBounds()
        {
            var systemUnderTest = new GameBoard(new[] {new[] {new Cell()}});

            Action throwingAction = () => systemUnderTest.GetNeighbours(0, 1);

            throwingAction.Should()
                .Throw<IndexOutOfRangeException>()
                .WithMessage("Expected Y coordinate to be on the board [(0,0) - (0,0)], but got 1");
        }
    }
}