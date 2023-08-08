using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.Exports;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Acme.MenClothingShop.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MenClothingShopDbContext :
    AbpDbContext<MenClothingShopDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */
    //Entity
    public DbSet<Clothe> Clothes { get; set; }

    public DbSet<Export> Exports { get; set; }

    public DbSet<ExportDetail> ExportDetails { get; set; }

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public MenClothingShopDbContext(DbContextOptions<MenClothingShopDbContext> options)
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
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */
        builder.Entity<Clothe>(c =>
        {
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "Clothes", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.Property(x => x.TenMH).IsRequired().HasMaxLength(128);
        });

        builder.Entity<Export>(c => {
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "Exports", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();
        });
        
        builder.Entity<ExportDetail>(c =>
        {
            c.HasKey(m => new { m.ExportId, m.ClotheId });
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "ExportDetails", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.HasOne<Export>().WithMany().HasForeignKey(y => y.ExportId).IsRequired();
            c.HasOne<Clothe>().WithMany().HasForeignKey(x => x.ClotheId).IsRequired();
        });
        
        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(MenClothingShopConsts.DbTablePrefix + "YourEntities", MenClothingShopConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
