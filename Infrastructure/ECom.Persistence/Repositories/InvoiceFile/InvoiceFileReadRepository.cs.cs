using ECom.Application.Repositories.InvoiceFile;

namespace ECom.Persistence.Repositories.InvoiceFile
{
    public class InvoiceFileReadRepository : ReadRepository<Domain.Entities.InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
