import type { CreateManyImportDetailsDto, ImportClotheListDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { GetClotheListDto } from '../clothes/models';

@Injectable({
  providedIn: 'root',
})
export class ImportDetailService {
  apiName = 'Default';

  create = (impClotheList: CreateManyImportDetailsDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/import-detail',
      body: impClotheList,
    },
    { apiName: this.apiName });

  getClotheListByInput = (input: GetClotheListDto) =>
    this.restService.request<any, PagedResultDto<ImportClotheListDto>>({
      method: 'GET',
      url: '/api/app/import-detail/clothe-list',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (maPN: string) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/import-detail',
      params: { maPN },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
