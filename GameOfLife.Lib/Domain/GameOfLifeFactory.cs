using GameOfLife.Lib.Logic;

namespace GameOfLife.Lib.Domain
{
    public class GameOfLifeFactory : IGameOfLifeFactory
    {
        private readonly ICoreRule _coreRule;

        public GameOfLifeFactory(ICoreRule coreRule)
        {
            _coreRule = coreRule;
        }

        public BoardBuilder BoardBuilder => new(this);
        public GameBoard GameBoard(Cell[][] cells)
        {
            return new(cells, _coreRule, this);
        }
    }
}