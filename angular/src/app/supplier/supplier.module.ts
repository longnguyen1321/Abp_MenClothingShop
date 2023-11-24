import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SupplierRoutingModule } from './supplier-routing.module';
import { SupplierComponent } from './supplier.component';
import { SharedModule } from '../shared/shared.module';
import {MatTabsModule} from '@angular/material/tabs';


@NgModule({
  declarations: [
    SupplierComponent
  ],
  imports: [
    SharedModule,
    SupplierRoutingModule,
    MatTabsModule
  ]
})
export class SupplierModule { }
