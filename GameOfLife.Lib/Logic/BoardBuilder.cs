using System.Collections.Generic;
using GameOfLife.Lib.Domain;

namespace GameOfLife.Lib.Logic
{
    public class BoardBuilder
    {
        private readonly IGameOfLifeFactory _gameOfLifeFactory;
        private int _sizeX;
        private int _sizeY;
        private readonly List<CellCoordinates> _aliveCoordinates = new();

        internal BoardBuilder(IGameOfLifeFactory gameOfLifeFactory)
        {
            _gameOfLifeFactory = gameOfLifeFactory;
        }

        public GameBoard GetBoard()
        {
            Cell[][] cellArray = new Cell[_sizeY][];
            InitializeRows(cellArray);

            return _gameOfLifeFactory.GameBoard(cellArray);
        }

        private void InitializeRows(Cell[][] cellArray)
        {
            for (var y = 0; y < _sizeY; y++)
            {
                cellArray[y] = new Cell[_sizeX];
                InitializeCells(cellArray, y);
            }
        }

        private void InitializeCells(IReadOnlyList<Cell[]> cellArray, int y)
        {
            for (var x = 0; x < _sizeX; x++)
            {
                cellArray[y][x] = new Cell
                {
                    Alive = _aliveCoordinates.Contains(
                        new CellCoordinates(x, y)),
                };
            }
        }

        public BoardBuilder SetSizeX(int size)
        {
            _sizeX = size;
            return this;
        }

        public BoardBuilder SetSizeY(int size)
        {
            _sizeY = size;
            return this;
        }

        public BoardBuilder SetDead(int x, int y)
        {
            _aliveCoordinates.Remove(new CellCoordinates(x, y));
            return this;
        }

        public BoardBuilder SetAlive(int x, int y)
        {
            _aliveCoordinates.Add(new CellCoordinates(x, y));
            return this;
        }

        public BoardBuilder SetCell(int x, int y, Cell cell)
        {
            BoardBuilder _ = cell.Alive
                ? SetAlive(x, y)
                : SetDead(x, y);
            return this;
        }
    }
}