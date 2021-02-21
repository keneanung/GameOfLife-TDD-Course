using GameLibrary.Logic;

namespace GameLibrary.Domain
{
    public interface IGameOfLifeFactory
    {
        BoardBuilder BoardBuilder { get; }
        GameBoard GameBoard(Cell[][] cells);
    }
}