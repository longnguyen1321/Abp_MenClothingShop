import type { CancelImportDto, CreateImportDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ImportService {
  apiName = 'Default';

  create = (input: CreateImportDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/import',
      body: input,
    },
    { apiName: this.apiName });

  update = (input: CancelImportDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/import',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
