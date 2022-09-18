import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProductListComponent } from './product-list/product-list.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { OrderHistoryComponent } from './order-history/order-history.component';

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule, 
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'productlist', component: ProductListComponent },
      { path:'products/:productId',component: ProductDetailsComponent },
      { path: 'cart', component: CartComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent},
      { path: 'profile', component: ProfilePageComponent },
      { path: 'orderhistory', component: OrderHistoryComponent }


    ]),
  ],
  declarations: [
    AppComponent,
    TopBarComponent,
    ProductListComponent,
    ProductDetailsComponent,
    CartComponent,
    LoginComponent,
    RegisterComponent,
    ProfilePageComponent,
    OrderHistoryComponent

  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }

