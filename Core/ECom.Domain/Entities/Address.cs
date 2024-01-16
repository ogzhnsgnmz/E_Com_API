using ECom.Domain.Entities.Common;
using ECom.Domain.Entities.Identity;

namespace ECom.Domain.Entities;

public class Address:BaseEntity
{
    public Guid UserId { get; set; }
    public AppUser AppUser { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string PostalCode { get; set; }
    public string Title { get; set; }
}
