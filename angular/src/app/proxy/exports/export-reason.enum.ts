import { mapEnumToOptions } from '@abp/ng.core';

export enum ExportReason {
  BanHang = 0,
  LyDoKhac = 1,
}

export const exportReasonOptions = mapEnumToOptions(ExportReason);
