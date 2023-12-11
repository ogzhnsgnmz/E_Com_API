using ECom.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Domain.Entities;

public class File : BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public decimal Price { get; set; }
    public string storage { get; set; }
    public string Showcase { get; set; }
    [NotMapped]
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}
