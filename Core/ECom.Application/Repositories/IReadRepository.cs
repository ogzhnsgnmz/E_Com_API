using ECom.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECom.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true); // Hangi türdeysek hepsini geten method.
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true); // Özel tanımlı fonksiyona vermiş olduğum şart true ise getiren method.
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); // Özel tanımlı fonksiyona vermiş olduğum şart true olan ilk değeri getiren method.
    Task<T> GetByIdAsync(string id, bool tracking = true); // Id'ye uygun olan hangisi ise o değeri getiren method.
}
