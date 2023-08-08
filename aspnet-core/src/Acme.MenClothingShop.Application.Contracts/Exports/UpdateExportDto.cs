using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Exports
{
    public class CancelExportDto
    {
        [Required]
        public String TinhTrangPX { get; set; }
    }
}
