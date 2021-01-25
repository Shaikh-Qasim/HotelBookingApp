import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  HotelDto,
  HotelServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-hotel-dialog',
  templateUrl: './edit-hotel-dialog.component.html',
  styleUrls: ['./edit-hotel-dialog.component.css']
})
export class EditHotelDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  hotel: HotelDto = new HotelDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _hotelService: HotelServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._hotelService.get(this.id).subscribe((result: HotelDto) => {
      this.hotel = result;
    });
  }

  save(): void {
    this.saving = true;

    this._hotelService
      .update(this.hotel)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
