using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Suppliers
{
    public class CreateUpdateSupplierDto
    {
        [Required]
        public string TenNCC { get; set; }

        [Required]
        public string DiaChiNCC { get; set; }

        [Required]
        public string LienLacNCC { get; set; }
    }
}
