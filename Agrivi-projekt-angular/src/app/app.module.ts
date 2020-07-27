import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarDetailsComponent } from './car-details/car-details.component';
import { CarDetailComponent } from './car-details/car-detail/car-detail.component';
import { CarDetailListComponent } from './car-details/car-detail-list/car-detail-list.component';
import { CarDetailService } from './shared/car-detail.service';
import { HttpClientModule } from '@angular/common/http';
import { BrandDetailService } from './shared/brand-detail.service';
import { BrandDetailsComponent } from './brand-details/brand-details.component';
import { BrandDetailListComponent } from './brand-details/brand-detail-list/brand-detail-list.component';
import { BrandDetailComponent } from './brand-details/brand-detail/brand-detail.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { DatePipe } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    CarDetailsComponent,
    CarDetailComponent,
    CarDetailListComponent,
    BrandDetailsComponent,
    BrandDetailComponent,
    BrandDetailListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NoopAnimationsModule,
    NgxPaginationModule,
    NgbModule
  ],
  providers: [CarDetailService, BrandDetailService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
