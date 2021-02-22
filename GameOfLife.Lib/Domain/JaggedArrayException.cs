using System;

namespace GameOfLife.Lib.Domain
{
    public class JaggedArrayException : Exception
    {
        public JaggedArrayException() :
            base("All inner arrays of cells must have the same length")
        {
        }
    }
}