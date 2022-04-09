using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Data.Entity;

public class Suggestions : GeneralEntity
{
    [Required, Display(Name = "Suggestion")]
    public string Content { get; set; }

    [Display(Name = "Expire By")]
    public DateTime ExpireBy { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Display(Name = "Has Time Limit")]
    public bool HasExpiryTime { get; set; }
   
}