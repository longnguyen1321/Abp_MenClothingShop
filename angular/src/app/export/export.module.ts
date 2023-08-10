import { NgModule } from '@angular/core';
import { ExportRoutingModule } from './export-routing.module';
import { ExportComponent } from './export.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    ExportComponent
  ],
  imports: [
    SharedModule,
    ExportRoutingModule
  ]
})
export class ExportModule { }
