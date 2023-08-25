using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Acme.MenClothingShop.Clothes
{
    public class ClotheManager : DomainService
    {
        IClotheRepository _clotheRepo;

        public ClotheManager(IClotheRepository clotheRepo)
        {
            _clotheRepo = clotheRepo;
        }

        public void UpdateClotheStorage(Clothe selectedClotheE,int soLuongThayDoi, string action)
        {
            if (action == "add")
            {
                selectedClotheE.TonKho += soLuongThayDoi;
            }
            
            if(action == "minus")
            {
                selectedClotheE.TonKho -= soLuongThayDoi;
            }
            
        }
    }
}
