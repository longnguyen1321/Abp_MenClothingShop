import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ClotheStorageDto, StorageService } from '@proxy/storages';

@Component({
  selector: 'app-storage',
  templateUrl: './storage.component.html',
  styleUrls: ['./storage.component.scss'],
  providers: [ListService],
})
export class StorageComponent implements OnInit {
  clotheStorage = { items: [], totalCount: 0} as PagedResultDto<ClotheStorageDto>;

  constructor(
    public readonly list: ListService,
    private storageService: StorageService
  ) { }

  ngOnInit(): void {
    const clotheStorageStreamCreator = (query) => this.storageService.get(query);
    
    this.list.hookToQuery(clotheStorageStreamCreator).subscribe((response) => {
      this.clotheStorage = response;
    });
  }

}
