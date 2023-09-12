using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.Exports;
using Acme.MenClothingShop.Imports;
using Acme.MenClothingShop.Suppliers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
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

    public DbSet<Import> Imports { get; set; }

    public DbSet<ImportDetail> ImportDetails { get; set; }

    public DbSet<Supllier> Suplliers { get; set; }

    public DbSet<SupplierClothe> SupplierClothes { get; set; }

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
            c.HasIndex(i => new { i.TenMH, i.SizeMH }).IsUnique();
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "Clothes", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.Property(x => x.TenMH).IsRequired().HasMaxLength(128);
            c.Property(d => d.GiaMH).HasColumnType("decimal(18,2)") ;
        });

        builder.Entity<Export>(c => {
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "Exports", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();
            c.Property(d => d.TongTienXuat).HasColumnType("decimal(18,2)");
        });
        
        builder.Entity<ExportDetail>(c =>
        {
            c.HasKey(m => new { m.ExportId, m.ClotheId });
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "ExportDetails", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.HasOne<Export>().WithMany().HasForeignKey(y => y.ExportId).IsRequired();
            c.HasOne<Clothe>().WithMany().HasForeignKey(x => x.ClotheId).IsRequired();
            c.Property(d => d.GiaXuat).HasColumnType("decimal(18,2)");
            c.Property(d => d.ThanhTienXuat).HasColumnType("decimal(18,2)");
        });

        builder.Entity<Supllier>(c =>
        { //Nhớ thêm index unique name
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "Suppliers", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.Property(x => x.TenNCC).IsRequired().HasMaxLength(128);
        });

        builder.Entity<Import>(c =>
        {
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "Imports", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();
            c.Property(d => d.TongTienNhap).HasColumnType("decimal(18,2)");
        });

        builder.Entity<ImportDetail>(c =>
        {
            c.HasKey(m => new { m.MaPN, m.MaMH });
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "ImportDetails", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.HasOne<Import>().WithMany().HasForeignKey(x => x.MaPN).IsRequired();
            c.HasOne<Clothe>().WithMany().HasForeignKey(y => y.MaMH).IsRequired();
            //c.Property(d => d.GiaNhap).HasColumnType("decimal(18,2");
            //c.Property(d => d.ThanhTienNhap).HasColumnType("decimal(18,2)");
        });

        builder.Entity<SupplierClothe>(c =>
        {
            c.HasKey(compositeKey => new { compositeKey.MaNCC, compositeKey.MaMH });
            c.ToTable(MenClothingShopConsts.DbTablePrefix + "SupplierClothes", MenClothingShopConsts.DbSchema);
            c.ConfigureByConvention();
            c.HasOne<Supllier>().WithMany().HasForeignKey(x => x.MaNCC).IsRequired();
            c.HasOne<Clothe>().WithMany().HasForeignKey(y => y.MaMH).IsRequired();
        });
        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(MenClothingShopConsts.DbTablePrefix + "YourEntities", MenClothingShopConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }

    public static explicit operator MenClothingShopDbContext(Task<DbContext> v)
    {
        throw new NotImplementedException();
    }
}
