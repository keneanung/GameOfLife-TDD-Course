using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Lib.Domain
{
    internal record CellCoordinates
    {
        public Coordinate X { get; }
        public Coordinate Y { get; }

        public CellCoordinates(Coordinate x, Coordinate y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<CellCoordinates> GetNeighbours()
        {
            return GetCluster().Where(location => location != this);
        }

        private IEnumerable<CellCoordinates> GetCluster()
        {
            ICollection<CellCoordinates> cluster = new List<CellCoordinates>(9);
            for (int x = X - 1;
                x <= X + 1;
                x++)
            {
                for (int y = Y - 1;
                    y <= Y + 1;
                    y++)
                {
                    cluster.Add(new CellCoordinates(x, y));
                }
            }

            return cluster;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public bool IsInRectangle(CellCoordinates upperLeftCorner, CellCoordinates lowerRightCorner)
        {
            return X.IsInRange(upperLeftCorner.X, lowerRightCorner.Y) &&
                   Y.IsInRange(upperLeftCorner.Y, lowerRightCorner.Y);
        }
    }
}