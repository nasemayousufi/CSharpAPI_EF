using System.ComponentModel.DataAnnotations;

namespace FinalProject1.Models
{
    public class Dress
    {
        public int Id { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Dress_EnsureCorrectSizing]
        public int? Size { get; set; }
        [Required]
        public string? Gender { get; set; }
        public double Price { get; set; }

    }
}

