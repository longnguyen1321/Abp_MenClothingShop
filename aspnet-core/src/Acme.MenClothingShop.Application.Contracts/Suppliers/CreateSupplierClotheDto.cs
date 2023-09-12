using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Suppliers
{
    public class CreateSupplierClotheDto
    {
        [Required]
        public Guid MaMH { get; set; }

        [Required]
        public Guid MaNCC { get; set; }
    }
}
