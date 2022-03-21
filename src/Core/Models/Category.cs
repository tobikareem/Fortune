using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Category: GeneralEntity
    {
        [Required(ErrorMessage = "*Category is required"), Display(Name = "Category"), MinLength(3)]
        public string Category1 { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
