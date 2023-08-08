using System.Threading.Tasks;

namespace Acme.MenClothingShop.Data;

public interface IMenClothingShopDbSchemaMigrator
{
    Task MigrateAsync();
}
