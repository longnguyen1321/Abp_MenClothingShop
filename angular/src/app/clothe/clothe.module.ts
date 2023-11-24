import { NgModule } from '@angular/core';
import { ClotheRoutingModule } from './clothe-routing.module';
import { ClotheComponent } from './clothe.component';
import { SharedModule } from '../shared/shared.module';

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
