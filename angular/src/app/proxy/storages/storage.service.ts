import type { ClotheStorageDto, GetClotheStorageListDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StorageService {
  apiName = 'Default';

  get = (input: GetClotheStorageListDto) =>
    this.restService.request<any, PagedResultDto<ClotheStorageDto>>({
      method: 'GET',
      url: '/api/app/storage',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
