using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VasyanStore.DataAccess.Repository.Abstraction;

namespace VasyanStore.DataAccess.Repository.Implementation
{
    public class FileRepository<TEntity> : IGenericRepository<TEntity> where TEntity :class
    {
        public void Create(TEntity entity)
        {
            var type = entity.GetType();
            var props = type.GetProperties();

            using (StreamWriter sw = new StreamWriter("D:\\games.txt"))
            {
                foreach(var prop in props)
                {
                    var value = prop.GetValue(entity);
                    sw.WriteLine(prop.Name + ": " + value);
                }
            }
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return new List<TEntity>(); 
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
