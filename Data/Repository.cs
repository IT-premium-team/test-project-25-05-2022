using Microsoft.EntityFrameworkCore;

namespace Data
{
    public interface IRepository
    {
        TestDbContext Context { get; }
        void Update(IEntity entity);
        Task AddAsync(IEntity entity);
    }

    public class Repository : IRepository
    {
        public TestDbContext Context {  get; set; }

        public Repository()
        {
            Context = new TestDbContext("");
        }

        public Repository(TestDbContext context)
        {
            Context = context;
        }
        public void Update(IEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Update(entity);
        }
        public async Task AddAsync(IEntity entity)
        {
            await Context.AddAsync(entity);
        }
    }
}
