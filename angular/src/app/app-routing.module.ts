import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { path: 'clothes', loadChildren: () => import('./clothe/clothe.module').then(m => m.ClotheModule) },
  { path: 'exports', loadChildren: () => import('./export/export.module').then(m => m.ExportModule) },
  { path: 'storage', loadChildren: () => import('./storage/storage.module').then(m => m.StorageModule) },
  { path: 'imports', loadChildren: () => import('./import/import.module').then(m => m.ImportModule) },
  { path: 'imports', loadChildren: () => import('./import/import.module').then(m => m.ImportModule) },
  { path: 'importCart', loadChildren: () => import('./import-cart/import-cart.module').then(m => m.ImportCartModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
