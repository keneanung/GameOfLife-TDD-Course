using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Domain
{
    public class GameBoard
    {
        private readonly int _xSize;
        private readonly int _ySize;
        private readonly Cell[][] _cells;

        private int MaxX => _xSize - 1;
        private int MaxY => _ySize - 1;


        public GameBoard(Cell[][] cells)
        {
            _ySize = cells.Length;
            CheckArraySize(_ySize);

            _xSize = cells[0].Length;
            CheckArraySize(_xSize);

            if (cells.Any(innerArray => innerArray.Length != _xSize))
            {
                throw new JaggedArrayException();
            }

            _cells = cells;
        }

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private static void CheckArraySize(int size)
        {
            if (size == 0)
            {
                throw new EmptyArrayException();
            }
        }

        public Cell GetCellAt(int x, int y)
        {
            return GetCellAt((Coordinate) x, (Coordinate) y);
        }

        private Cell GetCellAt(Coordinate x, Coordinate y)
        {
            CheckCoordinates(x, y);

            return _cells[y][x];
        }

        private void CheckCoordinates(Coordinate x, Coordinate y)
        {
            CheckCoordinate(x, _xSize, AxisName.X);
            CheckCoordinate(y, _ySize, AxisName.Y);
        }

        private void CheckCoordinate(Coordinate givenValue, int boardSize, AxisName axisName)
        {
            if (!givenValue.IsWithinBoard(boardSize))
            {
                throw new IndexOutOfRangeException(
                    $"Expected {axisName} coordinate to be on the board [(0,0) - ({MaxX},{MaxY})], but got {givenValue}");
            }
        }

        private enum AxisName
        {
            X,
            Y,
        }

        public IEnumerable<Cell> GetNeighbours(int x, int y)
        {
            return GetNeighbours((Coordinate) x, (Coordinate) y);
        }

        private IEnumerable<Cell> GetNeighbours(Coordinate x, Coordinate y)
        {
            CheckCoordinates(x, y);
            ICollection<Cell> neighbours = new List<Cell>(8);

            for (int xCoordinateOfNeighbour = Math.Max(0, x - 1);
                xCoordinateOfNeighbour <= Math.Min(x + 1, MaxX);
                xCoordinateOfNeighbour++)
            {
                for (int yCoordinateOfNeighbour = Math.Max(0, y - 1);
                    yCoordinateOfNeighbour <= Math.Min(y + 1, MaxY);
                    yCoordinateOfNeighbour++)
                {
                    if (xCoordinateOfNeighbour == x && yCoordinateOfNeighbour == y)
                    {
                        continue;
                    }

                    neighbours.Add(_cells[yCoordinateOfNeighbour][xCoordinateOfNeighbour]);
                }
            }

            return neighbours;
        }
    }
}