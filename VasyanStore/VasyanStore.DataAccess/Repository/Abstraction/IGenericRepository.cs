using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VasyanStore.DataAccess.Repository.Abstraction
{
    //TEntity - це якась сутність з бази данних, наприклад Game
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        // Витягує всі моделі з БД
        IEnumerable<TEntity> GetAll();
        // Витягує всі моделі з БД разом з якимись підв'язаними таблицями
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        TEntity GetById(int id);
    }
}
