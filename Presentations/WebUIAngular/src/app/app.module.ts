import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VatAddedPipe } from './core/pipes/vat-added.pipe';
import { FilterCarsPipe } from './core/pipes/filter-cars.pipe';

import { ToastrModule } from 'ngx-toastr';
import { CartSummaryComponent } from './core/components/cart-summary/cart-summary.component';
import { CustomerComponent } from './core/components/customer/customer.component';
import { CarDetailComponent } from './core/components/car/car-detail/car-detail.component';
import { CarListComponent } from './core/components/car/car-list/car-list.component';
import { FilterBrandsPipe } from './core/pipes/filter-brands.pipe';
import { FilterColorsPipe } from './core/pipes/filter-colors.pipe';
import { HeaderComponent } from './core/shared/components/header/header.component';
import { FooterComponent } from './core/shared/components/footer/footer.component';
import { LoginComponent } from './core/components/auth/login/login.component';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    VatAddedPipe,
    FilterCarsPipe,
    CartSummaryComponent,
    CustomerComponent,
    CarDetailComponent,
    CarListComponent,
    FilterBrandsPipe,
    FilterColorsPipe,
    HeaderComponent,
    FooterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    AppRoutingModule
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,useClass:AuthInterceptor,multi:true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
