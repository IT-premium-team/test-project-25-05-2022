namespace Data.Models
{
    public class Comment : IEntity, IKeyEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Body { get; set; }
        public int? PostId { get; set; }
        virtual public Post? Post { get; set; }
    }
}
