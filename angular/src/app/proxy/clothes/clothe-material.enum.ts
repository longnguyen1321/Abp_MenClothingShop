import { mapEnumToOptions } from '@abp/ng.core';

export enum ClotheMaterial {
  Undefined = 0,
  Acrylic = 1,
  Cotton = 2,
  CVC = 3,
  Nano = 4,
  Polyester = 5,
  Polyspun = 6,
  TC = 7,
}

export const clotheMaterialOptions = mapEnumToOptions(ClotheMaterial);
