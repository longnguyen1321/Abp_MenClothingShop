using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Suppliers
{
    public class DeleteSupplierClotheDto
    {
        [Required]
        public Guid MaMH { get; set; }

        [Required]
        public Guid MaNCC { get; set; }
    }
}
