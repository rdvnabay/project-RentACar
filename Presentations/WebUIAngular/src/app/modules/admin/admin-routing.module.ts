import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandAddComponent } from './components/brand-add/brand-add.component';
import { BrandEditComponent } from './components/brand-edit/brand-edit.component';
import { BrandListComponent } from './components/brand-list/brand-list.component';
import { CarAddComponent } from './components/car-add/car-add.component';
import { CarEditComponent } from './components/car-edit/car-edit.component';
import { CarListComponent } from './components/car-list/car-list.component';
import { ColorAddComponent } from './components/color-add/color-add.component';
import { ColorEditComponent } from './components/color-edit/color-edit.component';
import { ColorListComponent } from './components/color-list/color-list.component';
import { AdminLayoutComponent } from './shared/admin-layout/admin-layout.component';


const routes: Routes = [{ path: '', component: AdminLayoutComponent,
children:[
  { path:'',component:BrandListComponent },

  { path:'brand-add',component:BrandAddComponent },
  { path:'brand-edit/:brandId',component:BrandEditComponent },
  { path:'brand-list',component:BrandListComponent },

  { path:'car-add',component:CarAddComponent },
  { path:'car-edit/:brandId',component:CarEditComponent },
  { path:'car-list',component:CarListComponent },

  { path:'color-add',component:ColorAddComponent },
  { path:'color-edit/:brandId',component:ColorEditComponent },
  { path:'color-list',component:ColorListComponent }
]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
