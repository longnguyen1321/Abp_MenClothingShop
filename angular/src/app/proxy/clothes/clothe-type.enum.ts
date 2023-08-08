import { mapEnumToOptions } from '@abp/ng.core';

export enum ClotheType {
  Undefined = 0,
  AoLen = 1,
  AoPolo = 2,
  AoGio = 3,
  AoGiuNhiet = 4,
  AoPhong = 5,
  AoSoMi = 6,
  BoNi = 7,
  QuanAu = 8,
  QuanDui = 9,
  QuanJean = 10,
  QuanNgo = 11,
}

export const clotheTypeOptions = mapEnumToOptions(ClotheType);
