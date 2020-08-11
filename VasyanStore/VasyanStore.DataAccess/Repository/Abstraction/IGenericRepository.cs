using System;
using System.Collections.Generic;
using System.Linq;
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
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
