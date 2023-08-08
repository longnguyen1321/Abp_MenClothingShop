import type { CreateExportDetailDto, ExportDetailDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ExportDetailService {
  apiName = 'Default';

  create = (input: CreateExportDetailDto) =>
    this.restService.request<any, ExportDetailDto>({
      method: 'POST',
      url: '/api/app/export-detail',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
