using ECom.Domain.Entities.Identity;

namespace ECom.Application.Abstractions.Token;

public interface ITokenHandler
{
    DTOs.Token CreateAccessToken(int second, AppUser appUser);
    string CreateRefreshToken();
}
