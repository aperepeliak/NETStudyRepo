using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialType.Model.CustomExceptions
{
    [Serializable]
    public class InvalidInputParamsForPolinomException : Exception
    {
        public InvalidInputParamsForPolinomException()
            : base("The input parameters for polinomial object were invalid.")
        { }
    }
}
