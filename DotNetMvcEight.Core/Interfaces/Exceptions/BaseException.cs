
using System.Runtime.Serialization;

namespace DotNetMvcEight.Core.Interfaces.common
{
    public class BaseException : ApplicationException
    {
        public int ErrorCode { get; set; }
        public BaseException() { }

        public BaseException(string message) : base(message) { }

        public BaseException(int errorCode) : base(errorCode.ToString())
        {
            ErrorCode = errorCode;
        }

        public BaseException(string message,int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public BaseException(string? message, Exception? innerException)
          : base(message, innerException)
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
