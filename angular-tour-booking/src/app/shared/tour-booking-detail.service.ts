import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PartyLeaderDetail, TourBookingDetail } from './tour-booking-detail.model';

@Injectable({
  providedIn: 'root'
})
export class TourBookingDetailService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:5001/api/Booking/v1'
  formData: TourBookingDetail = new TourBookingDetail();
  list: TourBookingDetail[] = [];
  partyLeaders: PartyLeaderDetail[]=[];

  postBooking() {
    
    return this.http.post(this.baseURL +'/AddBooking', this.formData);
   
  }

  putBooking() {
    return this.http.put(`${this.baseURL +'/UpdateBooking'}`, this.formData);
  }

  deleteBooking(id: number) {
    return this.http.delete(`${this.baseURL + '/DeleteBooking?id=' + id}`);
  }

  refreshList() {
    this.http.get(this.baseURL +'/GetBooking')
      .toPromise()
      .then(res => this.list = res as TourBookingDetail[]);
  }
  getPartyLeaders() {
    this.http.get(this.baseURL + '/GetPartyLeaders')
      .toPromise()
      .then(res => {
        this.partyLeaders = res as PartyLeaderDetail[]
      });
  }
  getPartyLeadersByBookingId()
  {
    debugger;
    this.http.get(this.baseURL + '/GetPartyLeadersByBookingId?bookingId=' + this.formData.bookingId)
      .toPromise()
      .then(res => {
        this.formData.partyLeaders = res as PartyLeaderDetail[]
      });
  }

}
