using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask.Models.Reposetories
{
    public interface ICustomerRepository<TEntity>
    {
        IList<TEntity> List();
        IEnumerable<TEntity> FindAll();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
        List<TEntity> Search(string term);
 
    }
}
