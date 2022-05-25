namespace Data.Models
{
    public class User : IEntity, IKeyEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Phone { get; set; }
        public string? Token { get; set; }
    }
}
