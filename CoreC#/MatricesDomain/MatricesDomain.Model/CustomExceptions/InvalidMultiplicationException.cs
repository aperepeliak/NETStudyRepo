using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatricesDomain.Model.CustomExceptions
{
    [Serializable]
    public class InvalidMultiplicationException : Exception
    {
        public InvalidMultiplicationException()
            : base("Matrices have invalid sizes.")
        {
            HelpLink = @"For more info: https://en.wikipedia.org/wiki/Matrix_(mathematics)";
        }

        public InvalidMultiplicationException(string message)
            : base(message)
        {
            HelpLink = @"For more info: https://en.wikipedia.org/wiki/Matrix_(mathematics)";
        }
    }
}
