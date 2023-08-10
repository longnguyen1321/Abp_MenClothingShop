import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ClotheDto } from '@proxy/clothes';

@Component({
  selector: 'app-export',
  templateUrl: './export.component.html',
  styleUrls: ['./export.component.scss'],
  //providers: [ListService],
})
export class ExportComponent implements OnInit {
  //clothe = {items: [], totalCount: 0} as PagedResultDto<ClotheDto>;

  constructor() { }

  ngOnInit(): void {
  }

}
