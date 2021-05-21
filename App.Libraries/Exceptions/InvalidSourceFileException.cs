using System;

namespace App.Libraries.Exceptions
{
    public class InvalidSourceFileException : Exception
    {
        public InvalidSourceFileException(string errMsg) : base(errMsg)
        {
        }
    }
}