using System;
using System.Collections.Generic;
using System.Linq;
using GameLibrary.Logic;

namespace GameLibrary.Domain
{
    public class GameBoard
    {
        private static CellCoordinates Origin { get; } = new(0, 0);

        private readonly Cell[][] _cells;
        private readonly ICoreRule _coreRule;
        private readonly IGameOfLifeFactory _gameOfLifeFactory;

        private CellCoordinates LowerRightCorner { get; }
        private int SizeX => LowerRightCorner.X + 1;
        private int SizeY => LowerRightCorner.Y + 1;

        public GameBoard(Cell[][] cells, ICoreRule coreRule, IGameOfLifeFactory gameOfLifeFactory)
        {
            int ySize = cells.Length;
            CheckArraySize(ySize);

            int xSize = cells[0].Length;
            CheckArraySize(xSize);

            CheckAllInnerArraysForSameSize(cells, xSize);

            LowerRightCorner = new CellCoordinates(xSize - 1, ySize - 1);

            _cells = cells;
            _coreRule = coreRule;
            _gameOfLifeFactory = gameOfLifeFactory;
        }

        private static void CheckArraySize(int size)
        {
            if (size == 0)
            {
                throw new EmptyArrayException();
            }
        }

        private static void CheckAllInnerArraysForSameSize(Cell[][] cells, int xSize)
        {
            if (cells.Any(innerArray => innerArray.Length != xSize))
            {
                throw new JaggedArrayException();
            }
        }

        public Cell GetCellAt(int x, int y)
        {
            return GetCellAt(new CellCoordinates(x, y));
        }

        private Cell GetCellAt(CellCoordinates coordinates)
        {
            CheckCoordinates(coordinates);

            return _cells[coordinates.Y][coordinates.X];
        }

        private void CheckCoordinates(CellCoordinates coordinates)
        {
            if (!AreValidCoordinatesForThisBoard(coordinates))
            {
                throw new IndexOutOfRangeException(
                    $"Expected coordinates to be on the board [{Origin} - {LowerRightCorner}], but got {coordinates}");
            }
        }

        private bool AreValidCoordinatesForThisBoard(CellCoordinates coordinates)
        {
            return coordinates.IsInRectangle(Origin, LowerRightCorner);
        }

        public IEnumerable<Cell> GetNeighbours(int x, int y)
        {
            return GetNeighbours(new CellCoordinates(x, y));
        }

        private IEnumerable<Cell> GetNeighbours(CellCoordinates coordinates)
        {
            CheckCoordinates(coordinates);
            IEnumerable<Cell> neighbours = CollectNeighbours(coordinates);
            return neighbours;
        }

        private IEnumerable<Cell> CollectNeighbours(CellCoordinates coordinates)
        {
            ICollection<Cell> neighbours = new List<Cell>(8);

            IEnumerable<CellCoordinates> coordinatesOfNeighbourCells =
                coordinates.GetNeighbours();

            foreach (CellCoordinates coordinatesOfNeighbourCell in
                coordinatesOfNeighbourCells.Where(AreValidCoordinatesForThisBoard))
            {
                neighbours.Add(_cells[coordinatesOfNeighbourCell.Y][coordinatesOfNeighbourCell.X]);
            }

            return neighbours;
        }

        private IEnumerable<CellCoordinates> EnumerateCoordinates()
        {
            for (int x = Origin.X; x <= LowerRightCorner.X; x++)
            {
                for (int y = Origin.Y; y <= LowerRightCorner.Y; y++)
                {
                    yield return new CellCoordinates(x, y);
                }
            }
        }

        public GameBoard NextRound()
        {
            BoardBuilder builder = _gameOfLifeFactory.BoardBuilder;
            builder.SetSizeX(SizeX)
                .SetSizeY(SizeY);

            foreach (CellCoordinates coordinates in EnumerateCoordinates())
            {
                Cell nextCellState = NextCellState(coordinates);
                builder.SetCell(coordinates.X, coordinates.Y, nextCellState);
            }

            return builder.GetBoard();
        }

        private Cell NextCellState(CellCoordinates coordinates)
        {
            Cell thisCell = GetCellAt(coordinates);
            IEnumerable<Cell> neighbours = GetNeighbours(coordinates);
            return _coreRule.NextState(thisCell, neighbours);
        }
    }
}