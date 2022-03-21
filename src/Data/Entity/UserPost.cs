
namespace Data.Entity 
{
    public partial class UserPost: Core.Models.UserPost
    {
        public int Id { get; set; }
        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
