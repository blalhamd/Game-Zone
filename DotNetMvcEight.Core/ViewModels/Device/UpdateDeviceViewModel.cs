
namespace DotNetMvcEight.Core.ViewModels.Device
{
    public class UpdateDeviceViewModel
    {
		[Required]
		[RegularExpression(@"[a-zA-Z ]{5,250}", ErrorMessage = "Name must be letters only and length between 5 and 250.")]
		public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;

    }
}
