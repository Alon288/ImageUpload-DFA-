using Microsoft.Build.Framework;

namespace Image_Upload_DFA_.Models
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        [Required]
        public IFormFile Picture { get; set; } = null!;
    }
}
