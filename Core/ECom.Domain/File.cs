using ECom.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public decimal Price { get; set; }
        public string storage { get; set; }
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
