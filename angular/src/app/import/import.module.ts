import { NgModule } from '@angular/core';
import { ImportRoutingModule } from './import-routing.module';
import { ImportComponent } from './import.component';
import { SharedModule } from '../shared/shared.module';
import { ImportCartModule } from '../import-cart/import-cart.module';
import { ImportActionComponent } from '../import-action/import-action.component';

@NgModule({
  declarations: [
    ImportComponent, ImportActionComponent
  ],
  imports: [
    SharedModule,
    ImportRoutingModule,
    ImportCartModule
  ]
})
export class ImportModule { }
