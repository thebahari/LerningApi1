using System.ComponentModel.DataAnnotations;

namespace LerningApi1.Models
{
    public class PlaceUpdateViewModel
    {
        [Required]
        [MaxLength(20, ErrorMessage = "20character")]

        public string Name { get; set; } = string.Empty;
        [MaxLength(200,ErrorMessage ="200character")]
        public string? Description { get; set; }
    }
}
