import type { CreateSupplierClotheDto, DeleteSupplierClotheDto, SupplierClotheDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SupplierClotheService {
  apiName = 'Default';

  create = (input: CreateSupplierClotheDto) =>
    this.restService.request<any, SupplierClotheDto>({
      method: 'POST',
      url: '/api/app/supplier-clothe',
      body: input,
    },
    { apiName: this.apiName });

  delete = (input: DeleteSupplierClotheDto) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/supplier-clothe',
      params: { maMH: input.maMH, maNCC: input.maNCC },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
