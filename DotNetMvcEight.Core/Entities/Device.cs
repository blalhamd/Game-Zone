
namespace DotNetMvcEight.Core.Entities
{
    public class Device : BaseEntity
    {
        public string Icon { get; set; } = null!;
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
    }


}
