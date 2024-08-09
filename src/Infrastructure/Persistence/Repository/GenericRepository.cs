using ByteShare.Application.Repository;
using ByteShare.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Persistence.Repository;

public class GenericRepository<TEntity, Id> : IRepository<TEntity, Id> where TEntity : BaseEntity<Id>
{
    protected readonly ApplicationDbContext context;
    protected readonly DbSet<TEntity> dbSet;

    public GenericRepository(ApplicationDbContext context) {
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

    public virtual async Task<int> Update(TEntity _new)
    {
        Id? id = _new.Id;
        if(id is null)
        {
            return 0;
        }

        var _old = await GetById(id);
        if(_old is null)
        {
            return 0;
        }
        
        context.Entry(_old).CurrentValues.SetValues(_new);
        //context.Entry(entity).State = EntityState.Modified;
        return await context.SaveChangesAsync();
    }
}
