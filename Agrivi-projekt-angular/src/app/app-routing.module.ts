import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BrandDetailsComponent } from './brand-details/brand-details.component';
import { CarDetailsComponent } from './car-details/car-details.component';

const routes: Routes = [ 
{   path: '', 
    redirectTo: 'carList', 
    pathMatch: 'full' 
},
{
  path: 'carList',
  component: CarDetailsComponent
},
{
  path: 'brandList',
  component: BrandDetailsComponent
}];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  
}

