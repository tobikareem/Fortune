namespace Core.Models
{
    public class User: GeneralEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Identifier { get; set; } = null!;
        public string? Phone { get; set; }

    }
}
