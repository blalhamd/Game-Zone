

namespace DotNetMvcEight.Web.CustomValidationAttr
{
    public class FileExtension : ValidationAttribute
    {
        private readonly string[] extensions;

        public FileExtension(string[] extensions)
        {
            this.extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var IsContain = extensions.Contains(extension,StringComparer.OrdinalIgnoreCase);

                if (!IsContain)
                {
                    return new ValidationResult($"doesn't allow File with Extension {extension}");
                }
            }

            return ValidationResult.Success;
        }


    }
}
