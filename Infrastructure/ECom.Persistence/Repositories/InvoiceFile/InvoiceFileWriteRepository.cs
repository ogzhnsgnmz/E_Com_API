using ECom.Application.Repositories.InvoiceFile;

namespace ECom.Persistence.Repositories.InvoiceFile
{
    public class InvoiceFileWriteRepository : WriteRepository<Domain.Entities.InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
