import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SiteRoutingModule } from './site-routing.module';
import { SiteLayoutComponent } from './shared/site-layout/site-layout.component';
import { ColorListComponent } from './components/color/color-list/color-list.component';
import { CarAddComponent } from './components/car/car-add/car-add.component';
import { CarListComponent } from './components/car/car-list/car-list.component';
import { CarDetailComponent } from './components/car/car-detail/car-detail.component';
import { SiteNavbarComponent } from './shared/site-navbar/site-navbar.component';


@NgModule({
  declarations: [
    SiteLayoutComponent,
    ColorListComponent,
    CarAddComponent,
    CarListComponent,
    CarDetailComponent,
    SiteNavbarComponent
  ],
  imports: [
    CommonModule,
    SiteRoutingModule
  ]
})
export class SiteModule { }
