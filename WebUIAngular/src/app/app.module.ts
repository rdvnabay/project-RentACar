import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TodoComponent } from './components/todo/todo.component';
import { ColorComponent } from './components/color/color.component';
import { VatAddedPipe } from './pipes/vat-added.pipe';
import { FilterCarsPipe } from './pipes/filter-cars.pipe';

import { ToastrModule } from 'ngx-toastr';
import { CartSummaryComponent } from './components/cart-summary/cart-summary.component';
import { CustomerComponent } from './components/customer/customer.component';
import { CarDetailComponent } from './components/car/car-detail/car-detail.component';
import { CarListComponent } from './components/car/car-list/car-list.component';
import { BrandListComponent } from './components/brand/brand-list/brand-list.component';
import { BrandAddComponent } from './components/brand/brand-add/brand-add.component';
import { FilterBrandsPipe } from './pipes/filter-brands.pipe';
import { FilterColorsPipe } from './pipes/filter-colors.pipe';
import { HeaderComponent } from './shared/components/header/header.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { CarAddComponent } from './components/car/car-add/car-add.component';
import { LoginComponent } from './components/auth/login/login.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    TodoComponent,
    ColorComponent,
    VatAddedPipe,
    FilterCarsPipe,
    CartSummaryComponent,
    CustomerComponent,
    CarDetailComponent,
    CarListComponent,
    BrandListComponent,
    BrandAddComponent,
    FilterBrandsPipe,
    FilterColorsPipe,
    HeaderComponent,
    FooterComponent,
    NavbarComponent,
    CarAddComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    })
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,useClass:AuthInterceptor,multi:true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
