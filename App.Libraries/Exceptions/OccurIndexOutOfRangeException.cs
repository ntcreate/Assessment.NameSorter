using System;

namespace App.Libraries.Exceptions
{
    public class OccurIndexOutOfRangeException : Exception
    {
        public OccurIndexOutOfRangeException(string errMsg) : base(errMsg)
        {
        }
    }
}