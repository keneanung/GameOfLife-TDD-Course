namespace GameLibrary.Domain
{
    internal record Coordinate
    {
        private readonly int _value;

        private Coordinate(int value)
        {
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

        public bool IsInRange(int min, int max)
        {
            return _value >= min && _value <= max;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}