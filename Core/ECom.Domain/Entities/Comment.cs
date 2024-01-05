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
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public int Ratings { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
