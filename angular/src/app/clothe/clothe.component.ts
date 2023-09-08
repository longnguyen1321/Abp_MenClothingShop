import { ListService, PagedAndSortedResultRequestDto, PagedResultDto, validateRequired } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClotheDto, ClotheService, clotheMaterialOptions, clotheTypeOptions } from '@proxy/clothes';

@Component({
  selector: 'app-clothe',
  templateUrl: './clothe.component.html',
  styleUrls: ['./clothe.component.scss'],
  providers: [ListService],
})
export class ClotheComponent implements OnInit {
  clothe = { items: [], totalCount: 0 } as PagedResultDto<ClotheDto>;

  selectedClothe = {} as ClotheDto; //Khai báo mặt hàng được chọn

  form: FormGroup; //Step 4

  clotheTypes = clotheTypeOptions;
  clotheMaterials = clotheMaterialOptions;

  isModalOpen = false; //step 3

  constructor(public readonly list: ListService, private clotheService: ClotheService, private fb: FormBuilder, private confirmation: ConfirmationService) { }

  ngOnInit(): void {
    const clotheStreamCreator = (query: PagedAndSortedResultRequestDto) => this.clotheService.getList(query);
    
    this.list.hookToQuery(clotheStreamCreator).subscribe((response) => {
      this.clothe = response;
    });
  }
  
  createClothe(){ //step 3
    this.selectedClothe = {} as ClotheDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editClothe(id: string){ 
    this.clotheService.get(id).subscribe((clothe) => {
      this.selectedClothe = clothe;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  deleteClothe(id: string){
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if(status == Confirmation.Status.confirm){
        this.clotheService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm(){
    this.form = this.fb.group({
      tenMH: [this.selectedClothe.tenMH || '', Validators.required],
      sizeMH: [this.selectedClothe.sizeMH || '', Validators.required],
      soLuongMH: [this.selectedClothe.soLuongMH || null, Validators.required],
      loaiMH: [this.selectedClothe.loaiMH || null, Validators.required],
      chatLieuMH: [this.selectedClothe.chatLieuMH || null, Validators.required],
      giaMH: [this.selectedClothe.giaMH || null, Validators.required],
      slTonKhoToiThieu: [this.selectedClothe.slTonKhoToiThieu || null, Validators.required],
      anhMH: [this.selectedClothe.anhMH || '', Validators.required],
      moTaMH: [this.selectedClothe.moTaMH || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedClothe.id ? this.clotheService.update(this.selectedClothe.id, this.form.value) : this.clotheService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

}
