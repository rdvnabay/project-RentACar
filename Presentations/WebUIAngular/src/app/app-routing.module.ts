import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { CarAddComponent } from './components/car/car-add/car-add.component';
import { CarDetailComponent } from './components/car/car-detail/car-detail.component';
import { CarListComponent } from './components/car/car-list/car-list.component';
import { ColorComponent } from './components/color/color.component';
import { LoginGuard } from './guards/login.guard';

const routes: Routes = [
  { path: '', component: CarListComponent },
  { path: 'cars/brand/:brandId', component: CarListComponent },
  { path: 'cars/detail/:carId', component: CarDetailComponent },
  { path: 'car/add', component:CarAddComponent, canActivate:[LoginGuard]},
  { path:'login', component:LoginComponent },
  { path:'color',component:ColorComponent },
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
