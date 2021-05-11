import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { BrandAddComponent } from './components/brand/brand-add/brand-add.component';
import { BrandListComponent } from './components/brand/brand-list/brand-list.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';


@NgModule({
  declarations: [
    AdminComponent,
    BrandAddComponent,
    BrandListComponent,
    NavbarComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
