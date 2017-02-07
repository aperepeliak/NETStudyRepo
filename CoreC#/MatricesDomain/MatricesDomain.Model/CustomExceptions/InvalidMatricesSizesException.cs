﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatricesDomain.Model.CustomExceptions
{
    [Serializable]
    public class InvalidMatricesSizesException : Exception
    {
        public InvalidMatricesSizesException()
            : base("Cannot add two matrices with different sizes.")
        { }

        public InvalidMatricesSizesException(string message)
            : base(message)
        { }
    }
}
