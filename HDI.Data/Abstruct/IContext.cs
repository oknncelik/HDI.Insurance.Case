using HDI.Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Data.Abstruct
{
    public interface IContext<TEntity> where TEntity : class, IEntity, new()
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(long id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
