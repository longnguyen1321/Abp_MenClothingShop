import type { ExportReason } from './export-reason.enum';

export interface CancelExportDto {
  tinhTrangPX: string;
}

export interface CreateExportDetailDto {
  exportId: string;
  clotheId: string;
  soLuongXuat: number;
  giaXuat: number;
  thanhTienXuat: number;
}

export interface CreateExportDto {
  tongTienXuat: number;
  tinhTrangPX: string;
  lyDoXuat: ExportReason;
}

export interface ExportDetailDto {
  exportId?: string;
  clotheId?: string;
  soLuongXuat: number;
  giaXuat: number;
  thanhTienXuat: number;
}

export interface ExportDto {
  userId?: string;
  ngayXuat?: string;
  tongTienXuat: number;
  tinhTrangPX?: string;
  lyDoXuat: ExportReason;
}
