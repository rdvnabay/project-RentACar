import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandAddComponent } from './components/brand-add/brand-add.component';
import { BrandListComponent } from './components/brand-list/brand-list.component';
import { AdminLayoutComponent } from './shared/admin-layout/admin-layout.component';


const routes: Routes = [{ path: '', component: AdminLayoutComponent,
children:[
  { path:'',component:BrandListComponent },
  { path:'brand-add',component:BrandAddComponent },
  { path:'brand-list',component:BrandListComponent }
]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
