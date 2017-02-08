using System;
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
            : base("Summation Error - Cannot add two matrices with different sizes.")
        {
            HelpLink = @"For more info: https://en.wikipedia.org/wiki/Matrix_(mathematics)";
        }

        public InvalidMatricesSizesException(string message)
            : base(message)
        {
            HelpLink = @"For more info: https://en.wikipedia.org/wiki/Matrix_(mathematics)";
        }
    }
}
