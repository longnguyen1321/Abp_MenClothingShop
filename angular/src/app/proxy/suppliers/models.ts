import type { EntityDto } from '@abp/ng.core';

export interface CreateSupplierClotheDto {
  maMH: string;
  maNCC: string;
}

export interface CreateUpdateSupplierDto {
  tenNCC: string;
  diaChiNCC: string;
  lienLacNCC: string;
}

export interface DeleteSupplierClotheDto {
  maMH: string;
  maNCC: string;
}

export interface SupplierClotheDto extends EntityDto {
  maMH?: string;
  maNCC?: string;
}

export interface SupplierDto extends EntityDto<string> {
  tenNCC?: string;
  diaChiNCC?: string;
  lienLacNCC?: string;
}
