namespace ECom.Application.Repositories.Address;

public interface IAddressReadRepository : IReadRepository<Domain.Entities.Address>
{
    Task<Domain.Entities.Address> GetByUserIdAsync(string UserId, bool tracking = true);
}
