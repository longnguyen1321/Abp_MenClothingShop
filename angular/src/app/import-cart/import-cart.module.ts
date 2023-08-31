import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ImportCartRoutingModule } from './import-cart-routing.module';
import { ImportCartComponent } from './import-cart.component';


@NgModule({
  declarations: [
    ImportCartComponent
  ],
  imports: [
    CommonModule,
    ImportCartRoutingModule
  ]
})
export class ImportCartModule { }
