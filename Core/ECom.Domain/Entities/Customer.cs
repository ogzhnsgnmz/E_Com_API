using ECom.Domain.Entities.Common;

namespace ECom.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    //  public ICollection<Order> Orders { get; set; }
}
