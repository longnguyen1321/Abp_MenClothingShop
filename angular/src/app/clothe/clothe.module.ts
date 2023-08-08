import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClotheRoutingModule } from './clothe-routing.module';
import { ClotheComponent } from './clothe.component';
import { SharedModule } from '../shared/shared.module';
import {NgxDatatableModule}   from "@swimlane/ngx-datatable";


@NgModule({
  declarations: [
    ClotheComponent,
  ],
  imports: [
    ClotheRoutingModule,
    SharedModule,
  ]
})
export class ClotheModule { }
