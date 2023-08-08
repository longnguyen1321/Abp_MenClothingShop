import type { ClotheDto, CreateUpdateClotheDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ClotheService {
  apiName = 'Default';

  create = (input: CreateUpdateClotheDto) =>
    this.restService.request<any, ClotheDto>({
      method: 'POST',
      url: '/api/app/clothe',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/clothe/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ClotheDto>({
      method: 'GET',
      url: `/api/app/clothe/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ClotheDto>>({
      method: 'GET',
      url: '/api/app/clothe',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateClotheDto) =>
    this.restService.request<any, ClotheDto>({
      method: 'PUT',
      url: `/api/app/clothe/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
