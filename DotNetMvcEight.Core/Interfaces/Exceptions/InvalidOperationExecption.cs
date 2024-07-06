

using System.Runtime.Serialization;

namespace DotNetMvcEight.Core.Interfaces.common
{
    public class InvalidOperationExecption : BaseException
    {
        public InvalidOperationExecption() : base("Invalid Operation Execption") { }

        public InvalidOperationExecption(string message) : base(message) { }

        public InvalidOperationExecption(int errorCode) : base(errorCode.ToString())
        {
        }

        public InvalidOperationExecption(string message, int errorCode) : base(message)
        {
        }

        public InvalidOperationExecption(string? message, Exception? innerException)
          : base(message, innerException)
        {
        }

        protected InvalidOperationExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
