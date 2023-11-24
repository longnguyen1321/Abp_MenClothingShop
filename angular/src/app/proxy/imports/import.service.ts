import type { CancelImportDto, CreateImportDto, ImportDto, ToDisplayImportDto, UpdateImportDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ImportService {
  apiName = 'Default';

  create = (input: CreateImportDto) =>
    this.restService.request<any, ImportDto>({
      method: 'POST',
      url: '/api/app/import',
      body: input,
    },
    { apiName: this.apiName });

  getImport = (maPN: string) =>
    this.restService.request<any, ImportDto>({
      method: 'GET',
      url: '/api/app/import/import',
      params: { maPN },
    },
    { apiName: this.apiName });

  getImportListToDisplayByInput = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ToDisplayImportDto>>({
      method: 'GET',
      url: '/api/app/import/import-list-to-display',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ImportDto>>({
      method: 'GET',
      url: '/api/app/import',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (maPN: string, input: UpdateImportDto) =>
    this.restService.request<any, ImportDto>({
      method: 'PUT',
      url: '/api/app/import',
      params: { maPN },
      body: input,
    },
    { apiName: this.apiName });

  updateImportStatus = (input: CancelImportDto) =>
    this.restService.request<any, ImportDto>({
      method: 'PUT',
      url: '/api/app/import/import-status',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
