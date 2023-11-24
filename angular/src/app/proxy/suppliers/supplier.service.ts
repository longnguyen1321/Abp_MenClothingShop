import type { CreateUpdateSupplierDto, SupplierDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { ClotheDto } from '../clothes/models';
import type { ImportDto } from '../imports/models';

@Injectable({
  providedIn: 'root',
})
export class SupplierService {
  apiName = 'Default';

  create = (input: CreateUpdateSupplierDto) =>
    this.restService.request<any, SupplierDto>({
      method: 'POST',
      url: '/api/app/supplier',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/supplier/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, SupplierDto>({
      method: 'GET',
      url: `/api/app/supplier/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<SupplierDto>>({
      method: 'GET',
      url: '/api/app/supplier',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  getSupplierClothes = (maNCC: string, input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ClotheDto>>({
      method: 'GET',
      url: '/api/app/supplier/supplier-clothes',
      params: { maNCC, skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  getSupplierImports = (maNCC: string, input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ImportDto>>({
      method: 'GET',
      url: '/api/app/supplier/supplier-imports',
      params: { maNCC, skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateSupplierDto) =>
    this.restService.request<any, SupplierDto>({
      method: 'PUT',
      url: `/api/app/supplier/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
