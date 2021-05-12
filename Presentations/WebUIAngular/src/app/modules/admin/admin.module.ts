import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminLayoutComponent } from './shared/admin-layout/admin-layout.component';
import { BrandAddComponent } from './components/brand/brand-add/brand-add.component';
import { BrandListComponent } from './components/brand/brand-list/brand-list.component';
import { ColorAddComponent } from './components/color/color-add/color-add.component';
import { CarAddComponent } from './components/car/car-add/car-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    BrandAddComponent,
    BrandListComponent,
    ColorAddComponent,
    AdminLayoutComponent,
    CarAddComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AdminModule { }
