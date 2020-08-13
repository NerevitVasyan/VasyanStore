using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
            //return context.Games.ToList()
        }

        //  repos.GetAll(x=>x.Genre,x=>x.Developer);
        // params Expression<Func<TEntity,object>>[] includes - це массив лямбд типу x=>x.Genre
        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity,object>>[] includes)
        {
            // _set.AsQueriable().Include(x=>x.Genre).Include(x=>x.Developer).AsEnumerable();
            return includes.Aggregate(_set.AsQueryable(),
                (current, include) => current.Include(include)).AsEnumerable();
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
