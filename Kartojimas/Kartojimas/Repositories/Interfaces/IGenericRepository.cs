using Kartojimas.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kartojimas.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
        public int Save(T entity);
    }
}
