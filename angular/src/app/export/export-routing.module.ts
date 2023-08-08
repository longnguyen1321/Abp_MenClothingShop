import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExportComponent } from './export.component';
import { SharedModule } from '../shared/shared.module';

const routes: Routes = [{ path: '', component: ExportComponent }];

@NgModule({
  declarations: [ExportComponent],
  imports: [SharedModule, ExportRoutingModule]
})
export class ExportRoutingModule { }
