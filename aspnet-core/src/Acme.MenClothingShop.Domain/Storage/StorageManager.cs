﻿using Acme.MenClothingShop.Exports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Acme.MenClothingShop.Storage
{
    public class StorageManager : DomainService
    { 
        IExportDetailRepository _exportRepository; 
        
        public StorageManager(IExportDetailRepository exportRepository)
        {
            _exportRepository = exportRepository;
        }


    }
}
