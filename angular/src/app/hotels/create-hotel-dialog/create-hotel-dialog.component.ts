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
  CreateTenantDto,
  HotelDto,
  HotelServiceProxy,
  TenantServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-hotel-dialog',
  templateUrl: './create-hotel-dialog.component.html',
  styleUrls: ['./create-hotel-dialog.component.css']
})
export class CreateHotelDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  hotel: HotelDto = new HotelDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _hotelService: HotelServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._hotelService
      .create(this.hotel)
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
