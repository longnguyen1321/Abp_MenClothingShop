import { NgModule } from '@angular/core';

import { ImportCartRoutingModule } from './import-cart-routing.module';
import { ImportCartComponent } from './import-cart.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    ImportCartComponent
  ],
  imports: [
    SharedModule,
    ImportCartRoutingModule
  ],
  exports: [ImportCartComponent]
})
export class ImportCartModule { }
