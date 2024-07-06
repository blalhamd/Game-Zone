

using System.Runtime.Serialization;

namespace DotNetMvcEight.Core.Interfaces.common
{
    public class ItemAlreadyExistExecption : BaseException
    {
        public ItemAlreadyExistExecption() : base("Item Already Exist Execption") { }

        public ItemAlreadyExistExecption(string message) : base(message) { }

        public ItemAlreadyExistExecption(int errorCode) : base(errorCode.ToString())
        {
        }

        public ItemAlreadyExistExecption(string message, int errorCode) : base(message)
        {
        }

        public ItemAlreadyExistExecption(string? message, Exception? innerException)
          : base(message, innerException)
        {
        }

        protected ItemAlreadyExistExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class BadRequestException : BaseException
    {
        public BadRequestException() : base("Bad Request Exception") { }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(int errorCode) : base(errorCode.ToString())
        {
        }

        public BadRequestException(string message, int errorCode) : base(message)
        {
        }

        public BadRequestException(string? message, Exception? innerException)
          : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
