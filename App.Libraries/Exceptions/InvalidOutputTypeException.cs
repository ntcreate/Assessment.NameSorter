using System;

namespace App.Libraries.Exceptions
{
    public class InvalidOutputTypeException : Exception
    {
        public InvalidOutputTypeException(string errMsg) : base(errMsg)
        {
        }
    }
}