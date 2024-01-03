using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class ProductAttribute : BaseEntity
{
    public string Value { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid AttributeId { get; set; }
    public Attribute Attribute { get; set; }
}
