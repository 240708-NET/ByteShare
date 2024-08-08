namespace ByteShare.Application.Repository;

public interface IRepository<TEntity, Id> where TEntity : class
{
    Task Create(TEntity entity);
    Task<TEntity?> GetById(Id id);
    Task Update(TEntity entity);
    Task Delete(Id id);
    Task<ICollection<TEntity>> GetAll();
}
