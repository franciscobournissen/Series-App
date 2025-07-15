using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;

namespace SeriesApp.Identity;

public class CustomSignInManager : SignInManager<Volo.Abp.Identity.IdentityUser>, ITransientDependency
{
    private readonly ICustomUserAuthService _authService;
    private readonly ICurrentPrincipalAccessor _principalAccessor;

    public CustomSignInManager(
        IdentityUserManager userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<Volo.Abp.Identity.IdentityUser> claimsFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<SignInManager<Volo.Abp.Identity.IdentityUser>> logger,
        IAuthenticationSchemeProvider schemes,
        IUserConfirmation<Volo.Abp.Identity.IdentityUser> confirmation,
        ICustomUserAuthService authService,
        ICurrentPrincipalAccessor principalAccessor)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {
        _authService = authService;
        _principalAccessor = principalAccessor;
    }

    public async Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent)
    {
        try
        {
            var principal = await _authService.AuthenticateAsync(userName, password);

            // Establecer el principal
            _principalAccessor.Change(principal);

            // Simular inicio de sesión
            await Context.SignInAsync(IdentityConstants.ApplicationScheme, principal, new AuthenticationProperties
            {
                IsPersistent = isPersistent
            });

            return SignInResult.Success;
        }
        catch
        {
            return SignInResult.Failed;
        }
    }
}