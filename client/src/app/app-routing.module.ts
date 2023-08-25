import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TestErrorComponent } from './core/test-error/test-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'test-error', component: TestErrorComponent },
  { path: 'shop', loadChildren: () => import('./shop/shop.module').then((m) => m.ShopModule) }, // this route will be lazily loaded when we go to the '/shop' path
  { path: '**', redirectTo: '', pathMatch: 'full' }, // a route that does not exist
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
