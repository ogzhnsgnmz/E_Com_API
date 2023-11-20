using ECom.Application.Repositories.BaseFiles;

namespace ECom.Persistence.Repositories.BaseFiles
{
    public class BaseFilesReadRepository : ReadRepository<Domain.Entities.Customer>, IBaseFilesReadRepository
    {
        public BaseFilesReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
