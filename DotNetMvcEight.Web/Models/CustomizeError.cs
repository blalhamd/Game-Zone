namespace DotNetMvcEight.Web.Models
{
    public class CustomizeError
    {
        public int Error { get; set; }
        public int Status { get; set; }
        public string Message { get; set; } = null!;
        public string Details { get; set; } = null!;

        public override string ToString()
        {
            return $"Error: {Error}\nStatus: {Status}\nMessage: {Message}\nDetails: {Details}\n";
        }
    }
}
