import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { jqxGridModule } from 'jqwidgets-ng/jqxgrid';
import { HttpClientModule } from '@angular/common/http';
import { TourBookingComponent } from './tour-booking/tour-booking.component';
import { TourBookingFormComponent } from './tour-booking/tour-booking-form/tour-booking-form.component';
import { FormsModule } from '@angular/forms';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

@NgModule({
  declarations: [
    AppComponent,
    TourBookingComponent,
    TourBookingFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    jqxGridModule,
    HttpClientModule,
    FormsModule,
    NgMultiSelectDropDownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
