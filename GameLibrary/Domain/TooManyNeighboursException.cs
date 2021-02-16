using System;

namespace GameLibrary.Domain
{
    public class TooManyNeighboursException : Exception
    {
        public TooManyNeighboursException(int count) :
            base($"Expected up to 8 neighbours, but got {count}")
        {
        }
    }
}