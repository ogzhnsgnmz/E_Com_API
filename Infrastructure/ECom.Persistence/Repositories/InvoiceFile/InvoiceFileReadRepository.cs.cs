using ECom.Application.Repositories.InvoiceFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.InvoiceFile
{
    public class InvoiceFileReadRepository : ReadRepository<Domain.InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
