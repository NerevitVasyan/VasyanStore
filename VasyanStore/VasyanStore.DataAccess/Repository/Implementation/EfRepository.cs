using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VasyanStore.DataAccess.Repository.Abstraction;

namespace VasyanStore.DataAccess.Repository.Implementation
{
    // CRUD - Create Read Update Delete
    public class EfRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _set;

        public EfRepository(DbContext context)
        {
            _context = context;
            // context.Games
            _set = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            //Get all entities from database, for example get all games
            return _set.AsEnumerable();
            //return _set.ToList()
        }

        public TEntity GetById(int id)
        {
            return _set.Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
