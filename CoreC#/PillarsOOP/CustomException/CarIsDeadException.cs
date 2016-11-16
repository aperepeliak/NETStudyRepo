using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class CarIsDeadException : ApplicationException
    {
        //private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException(string message, string cause, DateTime time)
            : base(message)
        {
            //messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        // No need in overriding any more
        //public override string Message
        //{
        //    get
        //    {
        //        return string.Format("Car Error Message: {0}", messageDetails);
        //    }
        //}
    }

    /// <summary>
    /// The code below is provided by Visual Studio's "exception" (Tab key twice) code snippet template
    /// The snippet autogenerates a new exception class that adheres to .NET best practices
    /// </summary>
    [Serializable]
    public class CarBestPracticeException : Exception
    {
        public CarBestPracticeException() { }
        public CarBestPracticeException(string message) : base(message) { }
        public CarBestPracticeException(string message, Exception inner) : base(message, inner) { }
        protected CarBestPracticeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
