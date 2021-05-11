import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SiteRoutingModule } from './site-routing.module';
import { SiteLayoutComponent } from './shared/site-layout/site-layout.component';
import { ColorListComponent } from './components/color/color-list/color-list.component';


@NgModule({
  declarations: [
    SiteLayoutComponent,
    ColorListComponent
  ],
  imports: [
    CommonModule,
    SiteRoutingModule
  ]
})
export class SiteModule { }
