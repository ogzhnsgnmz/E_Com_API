﻿using ECom.Application.Abstractions.Services;
using ECom.Application.Abstractions.Token;
using ECom.Application.DTOs.Facebook;
using ECom.Application.DTOs;
using ECom.Application.Exceptions;
using ECom.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using ECom.Application.Helpers;

namespace ECom.Persistence.Services;

public class AuthService : IAuthService
{
    readonly HttpClient _httpClient;
    readonly IConfiguration _configuration;
    readonly IUserService _userService;
    readonly UserManager<AppUser> _userManager;
    readonly ITokenHandler _tokenHandler;
    readonly SignInManager<AppUser> _signInManager;
    readonly IMailService _mailService;


    public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IUserService userService, ITokenHandler tokenHandler, UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<AppUser> signInManager, IMailService mailService)
    {
        _httpClient = httpClientFactory.CreateClient();
        _configuration = configuration;
        _userService = userService;
        _tokenHandler = tokenHandler;
        _userManager = userManager;
        _signInManager = signInManager;
        _mailService = mailService;
    }
    async Task<Token> CreateUserExternalAsync(AppUser user, string email, string firstName, string lastName, UserLoginInfo info, int accessTokenLifeTime)
    {
        bool result = user != null;
        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new()
                {
                    Email = email,
                    UserName = email
                };
                var identityResult = await _userManager.CreateAsync(user);
                result = identityResult.Succeeded;
            }
        }

        if (result)
        {
            await _userManager.AddLoginAsync(user, info); //AspNetUserLogins

            Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 100);
            return token;
        }
        throw new Exception("Invalid external authentication.");
    }

    public async Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
    {
        string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_configuration["ExternalLoginSettings:Facebook:Client_ID"]}&client_secret={_configuration["ExternalLoginSettings:Facebook:Client_Secret"]}&grant_type=client_credentials");

        FacebookAccessTokenResponse? facebookAccessTokenResponse = JsonSerializer.Deserialize<FacebookAccessTokenResponse>(accessTokenResponse);

        string userAccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={authToken}&access_token={facebookAccessTokenResponse?.AccessToken}");

        FacebookUserAccessTokenValidation? validation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(userAccessTokenValidation);

        if (validation?.Data.IsValid != null)
        {
            string userInfoResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={authToken}");

            FacebookUserInfoResponse? userInfo = JsonSerializer.Deserialize<FacebookUserInfoResponse>(userInfoResponse);

            var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
            Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            return await CreateUserExternalAsync(user, userInfo.Email, userInfo.Name, userInfo.Name, info, accessTokenLifeTime);
        }
        throw new Exception("Invalid external authentication.");
    }

    public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> { _configuration["ExternalLoginSettings:Google:Client_ID"] }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

        var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
        Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

        return await CreateUserExternalAsync(user, payload.Email, payload.Name, payload.Name, info, accessTokenLifeTime);
    }

    public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
    {
        AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);

        if (user == null)
            user = await _userManager.FindByEmailAsync(usernameOrEmail);
        if (user == null)
            throw new NotFoundUserException("Kullanıcı veya şifre hatalı...");

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

        if (result.Succeeded)
        {
            Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 100);
            return token;
        }
        throw new AuthenticationErrorException();
    }


    public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
    {
        AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
        {
            Token token = _tokenHandler.CreateAccessToken(15, user);
            _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 100);
            return token;
        }
        else
            throw new NotFoundUserException();
    }
    public async Task PasswordResetAsnyc(string email)
    {
        AppUser user = await _userManager.FindByEmailAsync(email);
        if(user != null)
        {
            string resetToken = 
                await _userManager.GeneratePasswordResetTokenAsync(user);

            resetToken = resetToken.UrlEncode();

            await _mailService.SendPasswordResetMailAsync(email, user.Id, resetToken);
        }
    }

    public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            resetToken = resetToken.UrlDecode();

            return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
        }
        return false;
    }
}