using System;
using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.Lib.Domain;
using GameOfLife.Lib.Logic;
using Xunit;

namespace GameOfLife.Lib.Tests.Unit.Logic
{
    public class CoreRuleTests
    {
        [Fact]
        public void NextState_Should_ReturnDeadCell_If_LivingCellHasNoNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>();

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NexState_Should_ReturnDeadCell_If_DeadCellHasNoNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>();

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NextState_Should_ReturnDeadCell_If_LivingCellHasOneAliveNeighbour()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true}
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NexState_Should_ReturnDeadCell_If_DeadCellHasOneAliveNeighbour()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true}
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NextState_Should_ReturnLivingCell_If_LivingCellHasTwoAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeAlive();
        }

        [Fact]
        public void NexState_Should_ReturnDeadCell_If_DeadCellHasTwoAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NextState_Should_ReturnLivingCell_If_LivingCellHasThreeAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeAlive();
        }

        [Fact]
        public void NexState_Should_ReturnLivingCell_If_DeadCellHasThreeAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeAlive();
        }

        [Fact]
        public void NextState_Should_ReturnDeadCell_If_LivingCellHasFourAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NexState_Should_ReturnDeadCell_If_DeadCellHasFourAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NextState_Should_ReturnDeadCell_If_LivingCellHasFiveAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NexState_Should_ReturnDeadCell_If_DeadCellHasFiveAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NextState_Should_ReturnDeadCell_If_LivingCellHasSixAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NexState_Should_ReturnDeadCell_If_DeadCellHasSixAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NextState_Should_ReturnDeadCell_If_LivingCellHasSevenAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NexState_Should_ReturnDeadCell_If_DeadCellHasSevenLiveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NextState_Should_ReturnDeadCell_If_LivingCellHasEightAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = true,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NexState_Should_ReturnDeadCell_If_DeadCellHasEightAliveNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
                new() {Alive = true},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeDead();
        }

        [Fact]
        public void NexState_Should_ReturnLivingCell_If_DeadCellHasThreeLivingAndFiveDeadNeighbours()
        {
            var systemUnderTest = new CoreRule();
            var cell = new Cell
            {
                Alive = false,
            };
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = false},
                new() {Alive = true},
                new() {Alive = false},
                new() {Alive = true},
                new() {Alive = false},
                new() {Alive = false},
                new() {Alive = false},
            };

            Cell cellInNextRound = systemUnderTest.NextState(cell, neighbours);

            cellInNextRound.Should().BeAlive();
        }

        [Fact]
        public void NexState_Should_ThrowTooManyNeighboursException_If_MoreThanEightNeighborsAreGiven()
        {
            var systemUnderTest = new CoreRule();
            var anyCell = new Cell();
            var neighbours = new List<Cell>
            {
                new() {Alive = true},
                new() {Alive = false},
                new() {Alive = true},
                new() {Alive = false},
                new() {Alive = true},
                new() {Alive = false},
                new() {Alive = false},
                new() {Alive = false},
                new() {Alive = false},
            };

            Action throwingAction = () => systemUnderTest.NextState(anyCell, neighbours);

            throwingAction.Should().Throw<TooManyNeighboursException>();
        }
    }
}