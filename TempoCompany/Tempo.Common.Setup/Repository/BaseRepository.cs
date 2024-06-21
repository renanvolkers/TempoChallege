using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tempo.Common.Setup.Respository;
namespace Tempo.Common.Setup.Service
{
    /// <summary>
    /// code reuse in entity repository classes, avoid repeating code
    /// This is class generic
    /// Signing of contracts
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="Key"></typeparam>
    public class BaseRepository<IDataBaseContext, TEntity, Key> : IBaseRepository<TEntity, Key>
        where TEntity : class
        where IDataBaseContext : DbContext
    {
        private readonly IDataBaseContext context;

        public BaseRepository(IDataBaseContext ctx)
        {
            this.context = ctx;
        }



        public async Task<TEntity> AddAsync(TEntity entity, params Expression<Func<TEntity, object?>>[] references)
        {

            await context.AddAsync<TEntity>(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Key id)
        {
            var item = await this.GetByIdAsync(id);
            if (item != null)
            {
                context.Entry(item).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<TEntity?> UpdateAsync(TEntity? entityUpdate, Expression<Func<TEntity, bool>>? where = null, params Expression<Func<TEntity, object?>>[] references)
        {
            if (entityUpdate == null) return entityUpdate;

            context.Entry(entityUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entityUpdate;

        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? where =null, params string[] includes)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Key id)
        {

            return await context.FindAsync<TEntity>(id);
        }





    }

}
