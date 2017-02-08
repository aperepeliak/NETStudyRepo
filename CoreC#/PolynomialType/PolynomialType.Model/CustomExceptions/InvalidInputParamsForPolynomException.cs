using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialType.Model.CustomExceptions
{
    [Serializable]
    public class InvalidInputParamsForPolynomException : Exception
    {
        public InvalidInputParamsForPolynomException()
            : base("The input parameters for polynomial object were invalid.")
        { }

        public InvalidInputParamsForPolynomException(string message)
            : base(message)
        { }
    }
}
