using GameOfLife.Lib.Logic;

namespace GameOfLife.Lib.Domain
{
    public interface IGameOfLifeFactory
    {
        BoardBuilder BoardBuilder { get; }
        GameBoard GameBoard(Cell[][] cells);
    }
}