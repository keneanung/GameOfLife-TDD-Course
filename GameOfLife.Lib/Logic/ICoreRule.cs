using System.Collections.Generic;
using GameOfLife.Lib.Domain;

namespace GameOfLife.Lib.Logic
{
    public interface ICoreRule
    {
        Cell NextState(Cell thisCell, IEnumerable<Cell> neighbors);
    }
}