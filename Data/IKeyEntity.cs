namespace Data
{
    public interface IKeyEntity<T> : IEntity
    {
        public T Id { get; set; }
    }
}
