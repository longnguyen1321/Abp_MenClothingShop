using Acme.MenClothingShop.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Acme.MenClothingShop.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MenClothingShopEntityFrameworkCoreModule),
    typeof(MenClothingShopApplicationContractsModule)
    )]
public class MenClothingShopDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
