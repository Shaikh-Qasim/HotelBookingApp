import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  RoleDto,
  HotelDto,
  HotelServiceProxy,
  HotelDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateHotelDialogComponent } from './create-hotel-dialog/create-hotel-dialog.component';
import { EditHotelDialogComponent } from './edit-hotel-dialog/edit-hotel-dialog.component';

class PagedHotelsRequestDto extends PagedRequestDto {
  keyword: string;
}
@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.css'],
  animations: [appModuleAnimation()]
})
export class HotelsComponent extends PagedListingComponentBase<HotelDto> {
  hotels: HotelDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _hotelsService: HotelServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedHotelsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._hotelsService
      .getAll(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: HotelDtoPagedResultDto) => {
        this.hotels = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(hotel: any): void {
    abp.message.confirm(
      this.l('HotelDeleteWarningMessage', hotel.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._hotelsService
            .delete(hotel.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createHotel(): void {
    this.showCreateOrEditRoleDialog();
  }

  editHotel(hotel: HotelDto): void {
    this.showCreateOrEditRoleDialog(hotel.id);
  }

  showCreateOrEditRoleDialog(id?: number): void {
    let createOrEditRoleDialog: BsModalRef;
    if (!id) {
      createOrEditRoleDialog = this._modalService.show(
        CreateHotelDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditRoleDialog = this._modalService.show(
        EditHotelDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditRoleDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
