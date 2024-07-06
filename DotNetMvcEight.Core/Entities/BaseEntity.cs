

namespace DotNetMvcEight.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z ]{5,250}", ErrorMessage = "Name must be letters only and length between 5 and 250.")]
        public string Name { get; set; } = string.Empty;
    }
}
