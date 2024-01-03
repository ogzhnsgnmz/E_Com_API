using ECom.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
