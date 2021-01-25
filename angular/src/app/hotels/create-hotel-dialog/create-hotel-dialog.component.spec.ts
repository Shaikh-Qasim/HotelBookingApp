import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateHotelDialogComponent } from './create-hotel-dialog.component';

describe('CreateHotelDialogComponent', () => {
  let component: CreateHotelDialogComponent;
  let fixture: ComponentFixture<CreateHotelDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateHotelDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateHotelDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
