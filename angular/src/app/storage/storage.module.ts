import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StorageRoutingModule } from './storage-routing.module';
import { StorageComponent } from './storage.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    StorageComponent
  ],
  imports: [
    SharedModule,
    StorageRoutingModule
  ]
})
export class StorageModule { }
