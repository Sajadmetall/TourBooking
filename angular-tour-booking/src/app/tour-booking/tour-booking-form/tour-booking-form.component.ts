import { Component, OnInit } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { NgForm } from '@angular/forms';
import { TourBookingDetail } from '../../shared/tour-booking-detail.model';
import { TourBookingDetailService } from '../../shared/tour-booking-detail.service';


@Component({
  selector: 'app-tour-booking-form',
  templateUrl: './tour-booking-form.component.html',
  styles: [
  ]
})
export class TourBookingFormComponent implements OnInit {

  constructor(public service: TourBookingDetailService) { }
  dropdownSettings: IDropdownSettings = {
    singleSelection: false,
    idField: 'partyLeaderId',
    textField: 'name',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 3,

    allowSearchFilter: true
  };
  ngOnInit(): void {
    
  }
  statusMethods = [
    { id: 0, label: "Temporary" },
    { id: 1, label: "Confirmed" },
    { id: 2, label: "Canceled" }
  ];
  currencyMethods = [
    { id: 0, label: "USDolar" },
    { id: 1, label: "Euro"},
    { id: 2, label: "Pound"}
  ]

  onSubmit(form: NgForm) {
    this.service.formData.currency
    if (this.service.formData.bookingId == '00000000-0000-0000-0000-000000000000')
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postBooking().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        //this.toastr.success('Submitted successfully', 'Payment Detail Register')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putBooking().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        //this.toastr.info('Updated successfully', 'Payment Detail Register')
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new TourBookingDetail();
  }
  onItemSelect(item: any) {
    
    this.service.formData.partyLeaders.splice(item);
    this.service.formData.partyLeaders.push(item);
  }
  onSelectAll(items: any) {
    
    this.service.formData.partyLeaders.push(items);
  }
}
