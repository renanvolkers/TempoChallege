using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tempo.Common.Setup.Respository;
namespace Tempo.Common.Setup.Service
{

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
            return await context.Set<TEntity>().AsQueryable().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Key id)
        {
            return await context.FindAsync<TEntity>(id);
        }




    }

}
