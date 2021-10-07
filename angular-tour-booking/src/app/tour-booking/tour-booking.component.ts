import { Component, OnInit } from '@angular/core';
import { TourBookingDetail } from '../shared/tour-booking-detail.model';
import { TourBookingDetailService } from '../shared/tour-booking-detail.service';

@Component({
  selector: 'app-tour-booking',
  templateUrl: './tour-booking.component.html',
  styles: [
  ]
})
export class TourBookingComponent implements OnInit {

  constructor(public service: TourBookingDetailService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.service.getPartyLeaders();
  }

  populateForm(selectedRecord: TourBookingDetail) {
    debugger;
    
    this.service.formData = Object.assign({}, selectedRecord);
    this.service.getPartyLeadersByBookingId();
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      debugger;
      this.service.deleteBooking(id)
        .subscribe(
          res => {
            this.service.refreshList();
            //this.toastr.error("Deleted successfully", 'Payment Detail Register');
          },
          err => { console.log(err) }
        )
    }
  }

}
