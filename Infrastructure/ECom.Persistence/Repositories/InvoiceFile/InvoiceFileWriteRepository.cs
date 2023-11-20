using ECom.Application.Repositories.InvoiceFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.InvoiceFile
{
    public class InvoiceFileWriteRepository : WriteRepository<Domain.Entities.InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
