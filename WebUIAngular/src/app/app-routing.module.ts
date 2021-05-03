import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandListComponent } from './components/brand/brand-list/brand-list.component';
import { CarAddComponent } from './components/car/car-add/car-add.component';
import { CarDetailComponent } from './components/car/car-detail/car-detail.component';
import { CarListComponent } from './components/car/car-list/car-list.component';

const routes: Routes = [
  { path: '', component: CarListComponent },
  { path: 'brands', component: BrandListComponent },
  { path: 'cars/brand/:brandId', component: CarListComponent },
  { path: 'cars/detail/:carId', component: CarDetailComponent },
  { path: 'car/add', component:CarAddComponent},
  {
    path: 'admin',
    loadChildren: () =>
      import('./admin/admin.module').then((m) => m.AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
