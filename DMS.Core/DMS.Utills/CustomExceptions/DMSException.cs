using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Utills.CustomExceptions
{
    public class DMSException : Exception
    {
        public string CustomError { get; set; }

        public DMSException(string error)
        {
            CustomError = error;
        }

        public override string ToString()
        {
            return CustomError;
        }
    }
}
