

using System.Runtime.Serialization;

namespace DotNetMvcEight.Core.Interfaces.common
{
    public class ItemNotFoundExecption : BaseException
    {
        public ItemNotFoundExecption() :base("Item Not Found Execption") { }

        public ItemNotFoundExecption(string message) : base(message) { }

        public ItemNotFoundExecption(int errorCode) : base(errorCode.ToString())
        {
        }

        public ItemNotFoundExecption(string message, int errorCode) : base(message)
        {
        }

        public ItemNotFoundExecption(string? message, Exception? innerException)
          : base(message, innerException)
        {
        }

        protected ItemNotFoundExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
