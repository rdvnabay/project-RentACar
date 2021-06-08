import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ColorListComponent } from './components/color/color-list/color-list.component';
import { SiteLayoutComponent } from './shared/site-layout/site-layout.component';

const routes: Routes = [
  { path: '', component: SiteLayoutComponent,
    children: [
      { path: '', component: ColorListComponent },
      { path:'color',component:ColorListComponent}
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SiteRoutingModule {}
