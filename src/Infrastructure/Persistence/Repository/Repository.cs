using ByteShare.Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Persistence;

public class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> dbSet = context.Set<TEntity>();

    public async Task Create(TEntity entity)
    {
        dbSet.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(object id)
    {
        var entity = await GetById(id);
        if (entity is null)
        {
            return;
        }

        if(context.Entry(entity).State == EntityState.Detached)
        {
            dbSet.Attach(entity);
        }

        dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<ICollection<TEntity>> GetAll()
    {
        return await dbSet.ToListAsync<TEntity>();
    }

    public async Task<TEntity?> GetById(object id)
    {
        return await context.FindAsync<TEntity>(id);
    }

    public async Task Update(TEntity entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}
