
namespace DotNetMvcEight.Core.ViewModels.Game
{
    public class UpdateGameViewModel
    {
		[Required]
        [RegularExpression(@"[a-zA-Z0-9 ]{5,250}", ErrorMessage = "length must be between 5 and 250.")]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        [FileExtension([".jpg", ".png", ".jpeg"])]
        [FileSize(1048576)]
        public IFormFile Image { get; set; }
		public string? ImagePath { get; set; } = null!;
        [Required]
		[RegularExpression(@"[1-9]+", ErrorMessage = "Must Select Category.")]
        [Display(Name = "Category")]
		public int CategoryId { get; set; }
    }
}
