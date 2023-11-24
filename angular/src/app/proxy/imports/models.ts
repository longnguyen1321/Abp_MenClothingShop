import type { EntityDto } from '@abp/ng.core';

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

export interface ImportDto extends EntityDto<string> {
  maNCC?: string;
  userId?: string;
  ngayNhap?: string;
  tongTienNhap: number;
  tinhTrangPX?: string;
}

export interface ToDisplayImportDetailDto {
  maMH?: string;
  tenMH?: string;
  sizeMH?: string;
  soLuongNhap: number;
  giaNhap: number;
  thanhTienNhap: number;
}

export interface ToDisplayImportDto extends EntityDto<string> {
  tenNCC?: string;
  userId?: string;
  ngayNhap?: string;
  tongTienNhap: number;
  tinhTrangPN?: string;
}

export interface UpdateImportDetailDto {
  maPN: string;
  maMH: string;
  soLuongNhap: number;
  giaNhap: number;
}

export interface UpdateImportDto {
  maNCC: string;
  tongTienNhap: number;
}

export interface UpdateManyImportDetailDto {
  importDetails: UpdateImportDetailDto[];
}
