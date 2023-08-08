import type { CancelExportDto, CreateExportDto, ExportDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ExportService {
  apiName = 'Default';

  cancel = (id: string, exportStatus: CancelExportDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/export/${id}/cancel`,
      body: exportStatus,
    },
    { apiName: this.apiName });

  create = (input: CreateExportDto) =>
    this.restService.request<any, ExportDto>({
      method: 'POST',
      url: '/api/app/export',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
