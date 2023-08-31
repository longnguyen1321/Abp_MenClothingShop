import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ClotheType } from './clothe-type.enum';
import type { ClotheMaterial } from './clothe-material.enum';

export interface ClotheDto extends AuditedEntityDto<string> {
  tenMH?: string;
  sizeMH?: string;
  soLuongMH: number;
  tonKho: number;
  slTonKhoToiThieu: number;
  loaiMH: ClotheType;
  giaMH: number;
  chatLieuMH: ClotheMaterial;
  anhMH?: string;
  moTaMH?: string;
}

export interface CreateUpdateClotheDto {
  tenMH: string;
  sizeMH: string;
  soLuongMH: number;
  tonKho: number;
  slTonKhoToiThieu: number;
  loaiMH: ClotheType;
  giaMH: number;
  chatLieuMH: ClotheMaterial;
  anhMH?: string;
  moTaMH: string;
}

export interface GetClotheListDto extends PagedAndSortedResultRequestDto {
}
