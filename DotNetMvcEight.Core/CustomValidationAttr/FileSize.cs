
namespace DotNetMvcEight.Core.CustomValidationAttr
{
    public class FileSize : ValidationAttribute
    {
        private readonly int _size;

        public FileSize(int size)
        {
            _size = size;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if(file is not null)
            {
                var size = file.Length;

                if(size > 1048576)
                {
                    return new ValidationResult("Size of File must be 1Mb or less.");
                }
            }

            return ValidationResult.Success;
        }


    }
}
