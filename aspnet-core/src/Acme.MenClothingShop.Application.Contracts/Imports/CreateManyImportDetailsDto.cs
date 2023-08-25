using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Imports
{
    public class CreateManyImportDetailsDto
    {
        [Required]
        public List<CreateImportDetailDto> ImportDetails { get; set; } 
    }
}
