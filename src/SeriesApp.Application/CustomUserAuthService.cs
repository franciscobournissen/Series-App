using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using SeriesApp.Entities;

namespace SeriesApp;

public interface ICustomUserAuthService
{
    Task<ClaimsPrincipal> AuthenticateAsync(string userName, string password);
}

public class CustomUserAuthService : ICustomUserAuthService, ITransientDependency
{
    private readonly IRepository<User, Guid> _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public CustomUserAuthService(
        IRepository<User, Guid> userRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ClaimsPrincipal> AuthenticateAsync(string userName, string password)
    {
        var user = await _userRepository.FirstOrDefaultAsync(u => u.UserName == userName && u.IsActive);
        if (user == null)
        {
            throw new Exception("Invalid username or user is inactive.");
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (result != PasswordVerificationResult.Success)
        {
            throw new Exception("Invalid password.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user"),
            new Claim("full_name", user.FullName ?? ""),
            new Claim("is_admin", user.IsAdmin.ToString().ToLower())
        };

        var identity = new ClaimsIdentity(claims, "CustomAuth");
        return new ClaimsPrincipal(identity);
    }
}