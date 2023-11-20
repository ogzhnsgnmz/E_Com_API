using ECom.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECom.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
