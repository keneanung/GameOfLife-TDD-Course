using System;

namespace GameLibrary.Domain
{
    public class EmptyArrayException: Exception
    {
        public EmptyArrayException():
            base("Given 2 dimensional must not be empty or contain empty arrays")
        {
        }
    }
}