import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClotheComponent } from './clothe.component';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: ClotheComponent, canActivate: [AuthGuard, PermissionGuard] },];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClotheRoutingModule { }
