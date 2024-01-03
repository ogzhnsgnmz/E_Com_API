using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class Attribute : BaseEntity
{
    public string Name { get; set; }
    public ICollection<ProductAttribute> Attributes { get; set; }
}
