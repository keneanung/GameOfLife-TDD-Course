using GameOfLife.Lib.Domain;

namespace GameOfLife.Console
{
    public interface IOutput
    {
        void Output(GameBoard gameBoard);
    }
}