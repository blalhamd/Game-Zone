
namespace DotNetMvcEight.Core.ViewModels.Game
{
    public class GameViewModel 
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9 ]{5,250}", ErrorMessage = "length must be between 5 and 250.")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        [Required]
        [RegularExpression(@"[1-9]+", ErrorMessage = "Must Select Category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public DotNetMvcEight.Core.Entities.Category category { get; set; } = null!;
     
    }
}
