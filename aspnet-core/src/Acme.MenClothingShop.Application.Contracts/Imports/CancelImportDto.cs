using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Imports
{
    public class CancelImportDto
    {
        [Required]
        public Guid MaPN { get; set; }
    }
}
