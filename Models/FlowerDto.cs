using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    public class FlowerDto
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = "";


        [Required, MaxLength(200)]
        public string Category { get; set; } = "";

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = "";

        public IFormFile? ImageFile { get; set; }
    }
}
