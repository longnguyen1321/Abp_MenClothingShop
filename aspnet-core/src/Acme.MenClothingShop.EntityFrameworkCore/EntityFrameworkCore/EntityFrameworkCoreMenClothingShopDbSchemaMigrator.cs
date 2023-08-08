using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.MenClothingShop.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.MenClothingShop.EntityFrameworkCore;

public class EntityFrameworkCoreMenClothingShopDbSchemaMigrator
    : IMenClothingShopDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMenClothingShopDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MenClothingShopDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MenClothingShopDbContext>()
            .Database
            .MigrateAsync();
    }
}
