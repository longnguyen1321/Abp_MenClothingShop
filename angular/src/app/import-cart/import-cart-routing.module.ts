import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImportCartComponent } from './import-cart.component';

const routes: Routes = [{ path: '', component: ImportCartComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ImportCartRoutingModule { }
