import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminLayoutComponent } from './shared/admin-layout/admin-layout.component';
import { AdminNavbarComponent } from './shared/admin-navbar/admin-navbar.component';
import { AdminSidebarComponent } from './shared/admin-sidebar/admin-sidebar.component';
import { AdminFooterComponent } from './shared/admin-footer/admin-footer.component';
import { BrandAddComponent } from './components/brand-add/brand-add.component';
import { BrandListComponent } from './components/brand-list/brand-list.component';
import { AdminContentHeaderComponent } from './shared/admin-content-header/admin-content-header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrandEditComponent } from './components/brand-edit/brand-edit.component';
import { BrandDetailComponent } from './components/brand-detail/brand-detail.component';
import { ColorAddComponent } from './components/color-add/color-add.component';
import { ColorEditComponent } from './components/color-edit/color-edit.component';
import { ColorDeleteComponent } from './components/color-delete/color-delete.component';
import { CarAddComponent } from './components/car-add/car-add.component';
import { CarEditComponent } from './components/car-edit/car-edit.component';
import { CarDeleteComponent } from './components/car-delete/car-delete.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';


@NgModule({
  declarations: [
    BrandAddComponent,
    BrandListComponent,
    AdminLayoutComponent,
    AdminNavbarComponent,
    AdminSidebarComponent,
    AdminFooterComponent,
    AdminContentHeaderComponent,
    BrandEditComponent,
    BrandDetailComponent,
    ColorAddComponent,
    ColorEditComponent,
    ColorDeleteComponent,
    CarAddComponent,
    CarEditComponent,
    CarDeleteComponent,
    CarDetailComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    })
  ]
})
export class AdminModule { }
