using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Imports
{
    public class ImportClotheListDto : EntityDto<Guid>
    {
        public string TenMH { get; set; }

        public string SizeMH { get; set; }

        public int TonKho { get; set; }

        public int SLTonKhoToiThieu { get; set; }
    }
}
