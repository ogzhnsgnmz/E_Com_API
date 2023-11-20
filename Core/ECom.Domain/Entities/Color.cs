using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class Color : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
