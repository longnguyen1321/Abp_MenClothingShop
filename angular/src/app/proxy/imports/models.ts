import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CancelImportDto {
  maPN: string;
}

export interface CreateImportDetailDto extends EntityDto {
  maPN: string;
  maMH: string;
  soLuongNhap: number;
  giaNhap: number;
}

export interface CreateImportDto {
  maNCC: string;
  tongTienNhap: number;
}

export interface CreateManyImportDetailsDto {
  importDetails: CreateImportDetailDto[];
}

export interface GetImportClotheListDto extends PagedAndSortedResultRequestDto {
}

export interface ImportClotheListDto extends EntityDto<string> {
  tenMH?: string;
  sizeMH?: string;
  tonKho: number;
  slTonKhoToiThieu: number;
}
