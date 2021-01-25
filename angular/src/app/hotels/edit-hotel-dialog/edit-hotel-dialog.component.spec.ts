import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditHotelDialogComponent } from './edit-hotel-dialog.component';

describe('EditHotelDialogComponent', () => {
  let component: EditHotelDialogComponent;
  let fixture: ComponentFixture<EditHotelDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditHotelDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditHotelDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
