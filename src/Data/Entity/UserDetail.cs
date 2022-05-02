using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Data.Entity
{
    public class UserDetail : GeneralEntity
    {

        [Display(Name = "Job Title, Career Field")]
        public string? Title { get; set; }

        [Display(Name = "Company, School, Industry")]
        public string? Company { get; set; }

        public DateTime? Birthday { get; set; }

        [Url]
        [Display(Name = "Have a website?")]
        public string? WebsiteUrl { get; set; }

        [Url]
        [Display(Name = "Have a Youtube channel?")]
        public string? YoutubeLink { get; set; }

        [Url]
        [Display(Name = "Have a Facebook page?")]
        public string? FacebookLink { get; set; }

        [Display(Name = "Have a Twitter page?")]
        public string? TwitterLink { get; set; }

        [Display(Name = "Have an Instagram page?")]
        public string? InstagramLink { get; set; }

        [Url]
        [Display(Name = "Have a LinkedIn page?")]
        public string? LinkedInLink { get; set; }

        public string? UserId { get; set; }

        public string DriveFileId { get; set; }

        public bool IsSubscribed { get; set; }

        public string? Location { get; set; }

        public virtual ApplicationUser? User { get; set; } = null!;
    }
}
