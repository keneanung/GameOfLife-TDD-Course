using System.Collections.Generic;
using System.Linq;
using GameOfLife.Lib.Domain;

namespace GameOfLife.Lib.Logic
{
    public class CoreRule : ICoreRule
    {
        private const int MAXIMUM_NUMBER_OF_NEIGHBOURS = 8;
        private const int NUMBER_OF_NEIGHBOURS_FOR_ACCEPTABLE_LIFE_CONDITIONS = 2;
        private const int NUMBER_OF_NEIGHBOURS_FOR_THRIVING_LIVE_CONDITIONS = 3;

        public Cell NextState(Cell thisCell, IEnumerable<Cell> neighbors)
        {
            var neighbourList = neighbors.ToList();
            if (neighbourList.Count > MAXIMUM_NUMBER_OF_NEIGHBOURS)
            {
                throw new TooManyNeighboursException(neighbourList.Count);
            }

            return neighbourList.Count(cell => cell.Alive) switch
            {
                NUMBER_OF_NEIGHBOURS_FOR_ACCEPTABLE_LIFE_CONDITIONS =>
                    new Cell
                    {
                        Alive = thisCell.Alive
                    },
                NUMBER_OF_NEIGHBOURS_FOR_THRIVING_LIVE_CONDITIONS =>
                    new Cell
                    {
                        Alive = true
                    },
                _ =>
                    new Cell
                    {
                        Alive = false
                    },
            };
        }
    }
}