import type { CancelImportDto, CreateImportDto, ImportDto } from './models';
import { RestService } from '@abp/ng.core';
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

  update = (input: CancelImportDto) =>
    this.restService.request<any, ImportDto>({
      method: 'PUT',
      url: '/api/app/import',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
