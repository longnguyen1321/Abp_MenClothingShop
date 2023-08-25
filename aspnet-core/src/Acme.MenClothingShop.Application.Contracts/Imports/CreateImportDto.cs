using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Imports
{
    public class CreateImportDto
    {
        [Required]
        public Guid MaNCC { get; set; }

        [Required]
        public decimal TongTienNhap { get; set; }
    }
}
