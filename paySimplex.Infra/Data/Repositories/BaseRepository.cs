using paySimplex.Domain.Interfaces.Repositories;

namespace paySimplex.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly PaySimplexDbContext _context;
        public BaseRepository(PaySimplexDbContext context)
        {
            _context = context;
        }

        public virtual void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
