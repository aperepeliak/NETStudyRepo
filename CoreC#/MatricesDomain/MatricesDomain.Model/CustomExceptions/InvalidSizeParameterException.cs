using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatricesDomain.Model.CustomExceptions
{
    [Serializable]
    public class InvalidSizeParameterException : Exception
    {
        public InvalidSizeParameterException()
            : base("Matrix size cannot be null or negative") { }
    }
}
