import type { CreateManyImportDetailsDto, ToDisplayImportDetailDto, UpdateManyImportDetailDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

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

  getImportDetailListToDisplayByMaMH = (maMH: string) =>
    this.restService.request<any, ToDisplayImportDetailDto[]>({
      method: 'GET',
      url: '/api/app/import-detail/import-detail-list-to-display',
      params: { maMH },
    },
    { apiName: this.apiName });

  update = (maPN: string, input: UpdateManyImportDetailDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/import-detail',
      params: { maPN },
      body: input,
    },
    { apiName: this.apiName });

  updateImportClotheStorage = (maPN: string) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/import-detail/import-clothe-storage',
      params: { maPN },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
