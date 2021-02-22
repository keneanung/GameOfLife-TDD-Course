using System;

namespace GameOfLife.Lib.Domain
{
    public class EmptyArrayException: Exception
    {
        public EmptyArrayException():
            base("Given 2 dimensional must not be empty or contain empty arrays")
        {
        }
    }
}