using System.ComponentModel.DataAnnotations;


namespace Core.Models
{
    public class GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedBy { get; set; }
        public bool Enabled { get; set; }
    }
}
