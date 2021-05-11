import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { BrandAddComponent } from './components/brand/brand-add/brand-add.component';
import { BrandListComponent } from './components/brand/brand-list/brand-list.component';

const routes: Routes = [{ path: '', component: AdminComponent,
children:[
  { path:'brand-add',component:BrandAddComponent },
  { path:'brand-list',component:BrandListComponent }
]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
