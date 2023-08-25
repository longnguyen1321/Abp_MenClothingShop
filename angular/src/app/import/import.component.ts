import { ListResultDto, ListService, PagedResultDto } from '@abp/ng.core';
import { query } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ImportDetailService } from '@proxy/imports';
import { ImportClotheListDto } from '@proxy/imports/models';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss'],
  providers: [ListService],
})
export class ImportComponent implements OnInit {
  clotheList = { items: [], totalCount: 0} as PagedResultDto<ImportClotheListDto>;
  //selectedClothes = { } as CreateManyImportDetail

  form: FormGroup;

  isModalOpen = false;

  constructor(private importDetailService: ImportDetailService, public readonly list: ListService) { }

  ngOnInit(): void {
    const clotheStreamCreator = (query) => this.importDetailService.getClotheListByInput(query);

    this.list.hookToQuery(clotheStreamCreator).subscribe((response) => {
      this.clotheList = response;
    });
  }

  //addClothe()
}
