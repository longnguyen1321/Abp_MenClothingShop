using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Imports
{
    public class UpdateManyImportDetailDto
    {
        [Required]
        public List<UpdateImportDetailDto> ImportDetails { get; set; }
    }
}
