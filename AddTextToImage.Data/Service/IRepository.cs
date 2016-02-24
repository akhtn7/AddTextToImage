using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddTextToImage.Domain.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        
        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithInclude(string include);

        IQueryable<T> GetAllWithInclude(string include1, string include2);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        
        T Add(T o);

        void Delete(T o);

        void SetStateModified(T o);

        void SetStateUnchanged(T o);

        void Save();
    }
}
