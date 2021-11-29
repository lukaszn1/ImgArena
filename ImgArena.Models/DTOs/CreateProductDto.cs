using System.ComponentModel.DataAnnotations;

namespace ImgArena.Models.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }//todo should be enum type

        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal Price { get; set; }
    }
}