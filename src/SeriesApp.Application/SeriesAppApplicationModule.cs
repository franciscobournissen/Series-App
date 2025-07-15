using Microsoft.AspNetCore.Identity;
using SeriesApp.Domain.Services;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Microsoft.Extensions.DependencyInjection;
using SeriesApp.Entities;
using SeriesApp.Identity;
using Volo.Abp.Application;

namespace SeriesApp;

[DependsOn(
    typeof(SeriesAppDomainModule),
    typeof(SeriesAppApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(SeriesAppDomainModule),
    typeof(SeriesAppApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpIdentityApplicationModule)
    )]
public class SeriesAppApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<SeriesAppApplicationModule>();
        context.Services.AddHttpClient<ISeriesApiService, SeriesApiService>();
    
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SeriesAppApplicationModule>(validate: true);
        });

        context.Services.AddScoped<SignInManager<Volo.Abp.Identity.IdentityUser>, CustomSignInManager>();
    
        // 💥 Agregá esto para evitar el error
        context.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    }

}
