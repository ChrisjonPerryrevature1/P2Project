import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { OrderHistoryComponent } from './order-history/order-history.component';

const routes: Routes = [
  {path:'', component:ProductListComponent},
  {path: 'products/:productId', component:ProductDetailsComponent}, 
  {path: 'cart', component: CartComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'profilepage', component: ProfilePageComponent},
  {path: 'orderhistory', component: OrderHistoryComponent}

];

@NgModule({
  declarations: [],
  imports: [CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
