using HDI.Data.Abstruct;
using HDI.Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Data.Concreate
{
    //CRUD Operasyonları Generic olarak bu clasta gerçekleşir...
    public abstract class BaseContext<TEntity, TContext> : IContext<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public readonly  TContext _context;

        protected BaseContext()
        {
            _context = new TContext();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.CreateDate = DateTime.Now;
                var result = context.Entry(entity);
                result.State = EntityState.Added;
                await context.SaveChangesAsync();
                return result.Entity;
            }
        }

        /// <summary>
        /// Silme işlemi gerçekleştirilmez sadece Active Flag değeri False olarak setlenir.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.ActiveFlg = false; // Silme işlemi !!!!
                entity.UpdateDate = DateTime.Now;

                var result = context.Entry(entity);
                result.State = EntityState.Modified;
                return await context.SaveChangesAsync() > 0;
            }
        }

        /// <summary>
        /// Silme işlemi gerçekleştirilmez sadece Active Flag değeri False olarak setlenir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(long id)
        {
            using (var context = new TContext())
            {
                var entity = await GetAsync(x=> x.Id == id);
                entity.ActiveFlg = false; // Silme işlemi !!!!
                entity.UpdateDate = DateTime.Now;

                var result = context.Entry(entity);
                result.State = EntityState.Modified;
                return await context.SaveChangesAsync() > 0;
            }
        }

        /// <summary>
        /// Active Flag değeri True olan kaydı getirir. 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                if (filter != null)
                    return await context.Set<TEntity>().Where(x=> x.ActiveFlg == true).Where(filter).FirstOrDefaultAsync();
                return await context.Set<TEntity>().Where(x => x.ActiveFlg == true).FirstOrDefaultAsync();
            }
        }

        /// <summary>
        /// Active Flag değeri True olan kayıtları getirir. 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                if (filter != null)
                    return await context.Set<TEntity>().Where(x=> x.ActiveFlg == true).Where(filter).ToListAsync();
                return await context.Set<TEntity>().Where(x => x.ActiveFlg == true).ToListAsync();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.UpdateDate = DateTime.Now;
                var result = context.Entry(entity);
                result.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return result.Entity;
            }
        }
    }
}
