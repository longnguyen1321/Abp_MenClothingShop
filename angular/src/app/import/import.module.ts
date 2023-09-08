import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ImportRoutingModule } from './import-routing.module';
import { ImportComponent } from './import.component';
import { SharedModule } from '../shared/shared.module';
import { ImportCartModule } from '../import-cart/import-cart.module';

@NgModule({
  declarations: [
    ImportComponent
  ],
  imports: [
    SharedModule,
    ImportRoutingModule,
    ImportCartModule
  ]
})
export class ImportModule { }
