using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Imports
{
    public class UpdateImportDto 
    {
        [Required]
        public Guid MaNCC { get; set; }

        [Required]
        public Decimal TongTienNhap { get; set; }
    }
}
