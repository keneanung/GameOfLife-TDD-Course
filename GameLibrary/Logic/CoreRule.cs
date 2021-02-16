using System.Collections.Generic;
using System.Linq;
using GameLibrary.Domain;

namespace GameLibrary.Logic
{
    public class CoreRule
    {
        public Cell NextState(Cell thisCell, IEnumerable<Cell> neighbors)
        {
            var neighbourList = neighbors.ToList();
            if (neighbourList.Count > 8)
            {
                throw new TooManyNeighboursException(neighbourList.Count);
            }

            return neighbourList.Count(cell => cell.Alive) switch
            {
                2 => thisCell with {Alive = thisCell.Alive},
                3 => thisCell with {Alive = true},
                _ => thisCell with {Alive = false},
            };
        }
    }
}