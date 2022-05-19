using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.Exceptions
{
    public class IdIsNullException : Exception
    {

        public IdIsNullException(string msg) : base(msg)
        {

        }
    }
}
