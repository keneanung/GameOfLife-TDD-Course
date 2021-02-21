using System.Collections.Generic;
using GameLibrary.Domain;

namespace GameLibrary.Logic
{
    public interface ICoreRule
    {
        Cell NextState(Cell thisCell, IEnumerable<Cell> neighbors);
    }
}