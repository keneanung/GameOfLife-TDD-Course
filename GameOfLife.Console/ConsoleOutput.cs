using GameOfLife.Lib.Domain;

namespace GameOfLife.Console
{
    internal class ConsoleOutput : IOutput
    {
        public void Output(GameBoard gameBoard)
        {
            System.Console.Clear();

            for (var y = 0; y < gameBoard.SizeY; y++)
            {
                for (var x = 0; x < gameBoard.SizeX; x++)
                {
                    Cell cell = gameBoard.GetCellAt(x, y);
                    System.Console.Write(cell.Alive ? "X" : " ");
                }

                System.Console.WriteLine();
            }
        }
    }
}