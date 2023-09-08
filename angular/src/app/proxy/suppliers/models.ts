import type { EntityDto } from '@abp/ng.core';

export interface CreateUpdateSupplierDto {
  tenNCC: string;
  diaChiNCC: string;
  lienLacNCC: string;
}

export interface SupplierDto extends EntityDto<string> {
  tenNCC?: string;
  diaChiNCC?: string;
  lienLacNCC?: string;
}
