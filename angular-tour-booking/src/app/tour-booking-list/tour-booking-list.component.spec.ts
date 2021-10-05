import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourBookingListComponent } from './tour-booking-list.component';

describe('TourBookingListComponent', () => {
  let component: TourBookingListComponent;
  let fixture: ComponentFixture<TourBookingListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TourBookingListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TourBookingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
