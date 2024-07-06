
namespace DotNetMvcEight.Core.Entities
{
    public class Category : BaseEntity
    {
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
