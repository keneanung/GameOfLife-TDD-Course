using System;

namespace GameLibrary.Domain
{
    internal class Coordinate
    {
        private const int ORIGIN = 0;
        private readonly int _value;

        private Coordinate(int value)
        {
            if (value < ORIGIN)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Coordinates must lay within the first quadrant");
            }
            _value = value;
        }

        public static implicit operator int(Coordinate coordinate)
        {
            return coordinate._value;
        }

        public static implicit operator Coordinate(int value)
        {
            return new(value);
        }

        public bool IsWithinBoard(int boardSize)
        {
            return _value < boardSize;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}