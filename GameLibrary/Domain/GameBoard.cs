using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Domain
{
    public class GameBoard
    {
        private static CellCoordinates Origin { get; } = new(0, 0);
        private readonly Cell[][] _cells;
        private CellCoordinates LowerRightCorner { get; }


        public GameBoard(Cell[][] cells)
        {
            int ySize = cells.Length;
            CheckArraySize(ySize);

            int xSize = cells[0].Length;
            CheckArraySize(xSize);

            CheckAllInnerArraysForSameSize(cells, xSize);

            LowerRightCorner = new CellCoordinates(xSize - 1, ySize - 1);

            _cells = cells;
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
    }
}