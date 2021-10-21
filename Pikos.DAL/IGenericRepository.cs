using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pikos.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> Get(int id);
        public Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        public void Add(TEntity entity);
    }
}
