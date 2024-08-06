namespace ByteShare.Application.Persistence;

public interface IRepository<TEntity> where TEntity : class
{
    Task Create(TEntity entity);
    Task<TEntity?> GetById(object id);
    Task Update(TEntity entity);
    Task Delete(object id);
    Task<ICollection<TEntity>> GetAll();
}
