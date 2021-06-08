import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/components/auth/login/login.component';
import { CarDetailComponent } from './core/components/car/car-detail/car-detail.component';
import { CarListComponent } from './core/components/car/car-list/car-list.component';
import { LoginGuard } from './core/guards/login.guard';

const routes: Routes = [
  // { path: '', component: CarListComponent },
  // { path: 'cars/brand/:brandId', component: CarListComponent },
  // { path: 'cars/detail/:carId', component: CarDetailComponent },
  // { path: 'car/add', component:CarAddComponent, canActivate:[LoginGuard]},
  // { path:'login', component:LoginComponent },
  { path: 'admin', loadChildren: () => import('./core/modules/admin/admin.module').then(m => m.AdminModule) },
  { path: '', loadChildren: () => import('./core/modules/site/site.module').then(m => m.SiteModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
