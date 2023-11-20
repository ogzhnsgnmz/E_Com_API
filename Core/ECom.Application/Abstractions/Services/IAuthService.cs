using ECom.Application.Abstractions.Services.Authentication;

namespace ECom.Application.Abstractions.Services;

public interface IAuthService : IInternalAuthentication, IExternalAuthentication
{
    Task PasswordResetAsnyc(string email);
    Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
}
