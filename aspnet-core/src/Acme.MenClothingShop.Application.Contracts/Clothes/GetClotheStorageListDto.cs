using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Clothes
{
    public class GetClotheStorageListDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
