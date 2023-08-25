using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.Exports;
using Acme.MenClothingShop.Imports;
using AutoMapper;

namespace Acme.MenClothingShop;

public class MenClothingShopApplicationAutoMapperProfile : Profile
{
    public MenClothingShopApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Clothe, ClotheDto>();
        CreateMap<CreateUpdateClotheDto, Clothe>();
        CreateMap<CreateExportDto, Export>();
        CreateMap<CreateExportDetailDto, ExportDetail>();
        CreateMap<Clothe, ImportClotheListDto>();
    }
}
