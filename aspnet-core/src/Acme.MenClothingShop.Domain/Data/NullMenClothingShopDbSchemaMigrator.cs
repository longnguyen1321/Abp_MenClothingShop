using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.MenClothingShop.Data;

/* This is used if database provider does't define
 * IMenClothingShopDbSchemaMigrator implementation.
 */
public class NullMenClothingShopDbSchemaMigrator : IMenClothingShopDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
