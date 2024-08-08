using ByteShare.Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Persistence.Repository;

public class Repository<TEntity, Id> : IRepository<TEntity, Id> where TEntity : class
{
    protected readonly ApplicationDbContext context;
    protected readonly DbSet<TEntity> dbSet;

    public Repository(ApplicationDbContext context) {
        this.context = context;
        dbSet = context.Set<TEntity>();
    }

    public virtual async Task Create(TEntity entity)
    {
        dbSet.Add(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task Delete(Id id)
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

    public  virtual async Task<ICollection<TEntity>> GetAll()
    {
        return await dbSet.ToListAsync<TEntity>();
    }

    public virtual async Task<TEntity?> GetById(Id id)
    {
        return await context.FindAsync<TEntity>(id);
    }

    public virtual async Task Update(TEntity entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}
