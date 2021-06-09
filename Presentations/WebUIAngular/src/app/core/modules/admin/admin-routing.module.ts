import { CarImageAddComponent } from '../../components/admin/carImage/car-image-add/car-image-add.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandAddComponent } from '../../components/admin/brand/brand-add/brand-add.component';
import { BrandEditComponent } from '../../components/admin/brand/brand-edit/brand-edit.component';
import { BrandListComponent } from '../../components/admin/brand/brand-list/brand-list.component';
import { CarAddComponent } from '../../components/admin/car/car-add/car-add.component';
import { CarEditComponent } from '../../components/admin/car/car-edit/car-edit.component';
import { CarListComponent } from '../../components/admin/car/car-list/car-list.component';
import { ColorAddComponent } from '../../components/admin/color/color-add/color-add.component';
import { ColorEditComponent } from '../../components/admin/color/color-edit/color-edit.component';
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

  { path:'car-image-add', component:CarImageAddComponent},

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
