using ECom.Domain.Entities.Common;

namespace ECom.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model); // gelen model neyse ekleyen method.
    Task<bool> AddRangeAsync(List<T> datas); // gelen model koleksiyonunu ekleyen method
    bool Remove(T model); // gelen modeli silen method.
    bool RemoveRange(List<T> datas); // gelen modeli silen method.
    Task<bool> RemoveAsync(string id); // gelen idyi silen method.
    bool Update(T model); // gelen modeli güncelleyen method.
    Task<int> SaveAsync();
}
