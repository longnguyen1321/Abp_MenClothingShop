import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface ClotheStorageDto extends EntityDto<string> {
  tenMH?: string;
  tonKho: number;
  tinhTrangMH?: string;
  tongNhapThangMH: number;
  tongXuatThangMH: number;
}

export interface GetClotheStorageListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}
