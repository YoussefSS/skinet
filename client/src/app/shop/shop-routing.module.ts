import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

const routes: Routes = [
  { path: '', component: ShopComponent },
  { path: ':id', component: ProductDetailsComponent, data: {breadcrumb: {alias: 'productDetails'}} }, // giving a breadcrumb alias so we can set it to something other than the id
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)], // note how we use forChild instead of forRoot, as these routes are a child of this module
  exports: [RouterModule],
})
export class ShopRoutingModule {}
