using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Comment : GeneralEntity
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "*Comment is required"), Display(Name = "Comment"), MinLength(3)]
        public string Content { get; set; } = null!;


    }
}
