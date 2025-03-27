using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using SeriesApp.Entities;

namespace SeriesApp.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SeriesAppDbContext :
    AbpDbContext<SeriesAppDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<User> AppUsers { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<TrackingList> TrackingLists { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    #region Entities from the modules

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public SeriesAppDbContext(DbContextOptions<SeriesAppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */
        builder.Entity<User>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Users", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<Administrator>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Administrators", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<Serie>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Series", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<Notification>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Notifications", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(n => n.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<TrackingList>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "TrackingLists", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(tl => tl.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
            b.HasMany(tl => tl.Series)
                .WithMany()
                .UsingEntity(j => j.ToTable(SeriesAppConsts.DbTablePrefix + "TrackingListSeries"));
        });

        builder.Entity<Rating>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Ratings", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
            b.HasOne(r => r.Serie)
                .WithMany()
                .HasForeignKey("SerieId")
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
