
namespace DotNetMvcEight.Core.Entities
{
    public class Game : BaseEntity
    {
        public string Description { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<GameDevice> gameDevices { get; set; } = new List<GameDevice>();
    }

}
