import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminLayoutComponent } from './shared/admin-layout/admin-layout.component';
import { AdminNavbarComponent } from './shared/admin-navbar/admin-navbar.component';
import { AdminSidebarComponent } from './shared/admin-sidebar/admin-sidebar.component';
import { AdminFooterComponent } from './shared/admin-footer/admin-footer.component';
import { BrandAddComponent } from '../../components/admin/brand/brand-add/brand-add.component';
import { BrandListComponent } from '../../components/admin/brand/brand-list/brand-list.component';
import { AdminContentHeaderComponent } from './shared/admin-content-header/admin-content-header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrandEditComponent } from '../../components/admin/brand/brand-edit/brand-edit.component';
import { BrandDetailComponent } from '../../components/admin/brand/brand-detail/brand-detail.component';
import { ColorAddComponent } from '../../components/admin/color/color-add/color-add.component';
import { ColorEditComponent } from '../../components/admin/color/color-edit/color-edit.component';
import { ColorDeleteComponent } from '../../components/admin/color/color-delete/color-delete.component';
import { CarAddComponent } from '../../components/admin/car/car-add/car-add.component';
import { CarEditComponent } from '../../components/admin/car/car-edit/car-edit.component';
import { CarDeleteComponent } from '../../components/admin/car/car-delete/car-delete.component';
import { CarDetailComponent } from '../../components/admin/car/car-detail/car-detail.component';
import { ColorListComponent } from './components/color-list/color-list.component';
import { CarListComponent } from '../../components/admin/car/car-list/car-list.component';
import { PartialBrandListComponent } from './shared/partial-brand-list/partial-brand-list.component';
import { PartialColorListComponent } from './shared/partial-color-list/partial-color-list.component';
import { CarImageAddComponent } from '../../components/admin/carImage/car-image-add/car-image-add.component';


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
    CarDetailComponent,
    ColorListComponent,
    CarListComponent,
    PartialBrandListComponent,
    PartialColorListComponent,
    CarImageAddComponent
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
