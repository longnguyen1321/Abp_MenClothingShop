import { ConfigStateService, ListResultDto, ListService, PagedResultDto, ApplicationConfigurationDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { query } from '@angular/animations';
import { Console } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClotheDto, ClotheService } from '@proxy/clothes';
import { ImportDetailService, ImportService } from '@proxy/imports';
import { CancelImportDto, CreateImportDetailDto, CreateImportDto, CreateManyImportDetailsDto, ImportDto, UpdateImportDetailDto, UpdateImportDto, UpdateManyImportDetailDto } from '@proxy/imports/models';
import { SupplierDto, SupplierService } from '@proxy/suppliers';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss'],
  providers: [ListService],
})
export class ImportComponent implements OnInit {
  clotheList = { items: [], totalCount: 0 } as PagedResultDto<ClotheDto>;
  importList = { items: [], totalCount: 0} as PagedResultDto<ImportDto>;
  supplierList = { items: [], totalCount: 0 } as PagedResultDto<SupplierDto>;

  selectedClothe = { } as ClotheDto;
  selectedImport = {} as ImportDto;

  selectedClotheListToDisplay = [];
  action = null;
  currentUser = {} as ApplicationConfigurationDto["currentUser"];
  form: FormGroup;
  importInfoForm: FormGroup;
  importTotal: number;

  isModalOpen = false;
  condition = true;
  ngIf = true;

  selectedSupplier: any;
  oldSelectedSupplier: any;

  constructor(private importDetailService: ImportDetailService, 
    public readonly list: ListService, 
    private fb: FormBuilder, 
    private confirmation: ConfirmationService, 
    private clotheService: ClotheService,
    private supplierService: SupplierService,
    private configService: ConfigStateService,
    private importService: ImportService
    ) { }

  ngOnInit(): void {
    const importStreamCretor = (query) => this.importService.getImportListToDisplayByInput(query);
    this.list.hookToQuery(importStreamCretor).subscribe((value) => {
      this.importList = value;

      const supplierStreamCreator = (query2) => this.supplierService.getList(query2);

      this.list.hookToQuery(supplierStreamCreator).subscribe((response) => {
        this.supplierList = response;

        this.configService.getOne$("currentUser").subscribe(user => {
          this.currentUser = user;
        })
      }) 
    })
  }

  resetSelectedValue(){
    this.selectedClotheListToDisplay = [];
    this.selectedSupplier = undefined;
    this.oldSelectedSupplier = undefined;
    this.selectedImport = {} as ImportDto;
    this.importTotal = 0;
    this.clotheList = { items: [], totalCount: 0 } as PagedResultDto<ClotheDto>;

    document.forms['import-form']['import-supplier'].value = "";
    document.forms['import-form']['import-creator'].value = "";
    document.forms['import-form']['import-total'].value = "";
    document.forms['import-form']['import-status'].value = "";
    document.forms['import-form']['import-id'].value = "";

    const importStreamCretor = (query) => this.importService.getImportListToDisplayByInput(query);
    this.list.hookToQuery(importStreamCretor).subscribe((value) => {
      this.importList = value;
    })
  }
  
  openBootstrapModal(importId: string){ console.log(this.selectedSupplier)
    console.log(this.selectedImport)
    const modelDiv = document.getElementById('myModal');
    
    if(modelDiv != null){
      modelDiv.style.display = 'block';

      if(importId != null){
        this.importService.getImport(importId).subscribe((value) => {
          this.selectedImport = value;

          //Hiển thị Nhà cung cấp của Phiếu nhập lên Tag Select
          const thisImportSupplierIndex = (this.supplierList.items.findIndex(x => x.id == value.maNCC)) + 1; console.log(thisImportSupplierIndex);
          (<HTMLSelectElement> document.getElementById('supplierSelection')).selectedIndex = thisImportSupplierIndex; 

          this.supplierService.get(value.maNCC).subscribe((response) => {
            document.forms['import-form']['import-supplier'].value = response.tenNCC;
            document.forms['import-form']['import-creator'].value = value.userId;
            document.forms['import-form']['import-total'].value = value.tongTienNhap;
            document.forms['import-form']['import-status'].value = value.tinhTrangPX;
            document.forms['import-form']['import-id'].value = value.id;

            this.selectedSupplier = response;
            this.oldSelectedSupplier = this.selectedSupplier;
            this.changeSupplier();

            this.importDetailService.getImportDetailListToDisplayByMaMH(value.id).subscribe((response2) => {
              this.selectedClotheListToDisplay = response2;
              console.log(this.selectedClotheListToDisplay)
            });
          });
        });
      }
      else{
        this.selectedImport = {} as ImportDto;
      }

    }
  }

  closeBootstrapModal(){
    const modelDiv = document.getElementById('myModal');

    if(modelDiv != null){
      modelDiv.style.display = 'none';

      this.resetSelectedValue();
    }
  }

  getSelectedSupplier(obj: {}){
    var option = obj.valueOf();
    console.log(option);
  }

  changeSupplier(){ console.log(this.selectedSupplier)
    if(this.selectedSupplier != undefined){ //Nếu Tag Select chọn giá trị khác Undefined - Gía trị rỗng
      //Khi Danh sách mặt hàng đã chọn tồn tại mặt hàng
      if(this.selectedClotheListToDisplay.length > 0){
        this.confirmation.warn('Khi thay đổi nhà cung cấp sẽ xóa những sản phẩm đã chọn không thuộc nhà cung cấp đó!', '::AreYouSure').subscribe((status) => {
          if(status == Confirmation.Status.confirm){
            // var index = (<HTMLSelectElement> document.getElementById('supplierSelection')).selectedIndex - 1;

            // this.supplierService.get(this.supplierList.items[index].id).subscribe((supplier) => {
            //   this.selectedSupplier = supplier;

            this.oldSelectedSupplier = this.selectedSupplier;
            document.forms['import-form']['import-supplier'].value = this.selectedSupplier.tenNCC;            

            const clotheStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getSupplierClothes(this.selectedSupplier.id, query);
  
            this.list.hookToQuery(clotheStreamCreator).subscribe((value) => {
              this.clotheList = value;      

              this.selectedClotheListToDisplay.forEach((element) => { 
                let deletedClotheIndex = this.clotheList.items.findIndex(y => y.id == element.maMH);

                if(deletedClotheIndex != -1){
                  this.selectedClotheListToDisplay.splice(deletedClotheIndex, 1);
                }
              });
            });
          }
          //Nếu không đồng ý, set lại giá trị của Tag select
          else{ console.log(this.oldSelectedSupplier)
            //Nếu giá trị nhà cung cấp trước là Undefined
            if(this.oldSelectedSupplier == undefined){ console.log("NCC trước là Undefined");
              (<HTMLSelectElement> document.getElementById('supplierSelection')).selectedIndex = 0; 
              return;
            }

            const index = this.supplierList.items.findIndex(x => x.id == this.oldSelectedSupplier.id) + 1; //Do tag Select giá trị khác Undefined bắt đầu từ 1

            (<HTMLSelectElement> document.getElementById('supplierSelection')).selectedIndex = index;
          }
        });
      }
      //Khi Danh sách mặt hàng đã chọn chưa tồn tại mặt hàng
      else{
        this.oldSelectedSupplier = this.selectedSupplier;
        document.forms['import-form']['import-supplier'].value = this.selectedSupplier.tenNCC;

        const clotheStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getSupplierClothes(this.selectedSupplier.id, query);

        this.list.hookToQuery(clotheStreamCreator).subscribe((value) => {
          this.clotheList = value; 
        })
      }
    }
  }

  createImport(){ 
    if(this.selectedClotheListToDisplay != undefined && this.selectedClotheListToDisplay.length > 0){
      const createImport = { maNCC: this.selectedSupplier.id, tongTienNhap:  this.importTotal} as CreateImportDto;
      this.importService.create(createImport).subscribe((response) => {
        const returnedImport = response;

        let selectedClothesList = [] as CreateImportDetailDto[]  
        this.selectedClotheListToDisplay.forEach(element => {
          (selectedClothesList).push({ maPN: returnedImport.id, maMH: element.maMH, soLuongNhap: element.soLuongNhap, giaNhap: element.giaNhap  } as CreateImportDetailDto)
        });

        const createManyDetail = { importDetails:selectedClothesList } as CreateManyImportDetailsDto;

        this.importDetailService.create(createManyDetail).subscribe();

        document.forms['import-form']['import-creator'].value = response.userId;
        document.forms['import-form']['import-id'].value = response.id;
        document.forms['import-form']['import-status'].value = response.tinhTrangPX;
        document.forms['import-form']['import-supplier'].value = response.maNCC;
      });
    }
    else{
      alert("Chưa chọn mặt hàng cho phiếu nhập!");
    }
  }

  cancelImport(importId: string){
    const updateDto = { maPN: importId } as CancelImportDto
    this.importService.updateImportStatus( updateDto ).subscribe((response) => {
      document.forms['import-form']['import-status'].value = response.tinhTrangPX;
    });
  } 

  updateImport(){ 
    const newImportDto = { maNCC: this.selectedSupplier.id, tongTienNhap: this.importTotal } as UpdateImportDto; 

    this.importService.update(this.selectedImport.id, newImportDto).subscribe(() => { 
      const updateImportDetailDto = { importDetails: [] } as UpdateManyImportDetailDto;
      this.selectedClotheListToDisplay.forEach(element => {
        const importDetail = { maPN: this.selectedImport.id, maMH: element.maMH, soLuongNhap: element.soLuongNhap, giaNhap: element.giaNhap } as UpdateImportDetailDto;

        updateImportDetailDto.importDetails.push(importDetail);
      });
      console.log(this.selectedImport.id)
      console.log(updateImportDetailDto)
      this.importDetailService.update(this.selectedImport.id, updateImportDetailDto).subscribe();
    });
  }

  saveImport(){
    this.confirmation.warn(this.selectedImport.id == undefined ? 'Bạn muốn tạo phiếu nhập?' : "Bạn muốn cập nhập phiếu nhập?", '::AreYouSure').subscribe((response) => {
      if(response == Confirmation.Status.confirm){
        if(this.selectedImport.id == undefined){
          this.createImport();
        }
        else{
          this.updateImport();
        }

        const clotheStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getSupplierClothes(this.selectedSupplier.id, query);
        this.list.hookToQuery(clotheStreamCreator).subscribe((value) => {
          this.clotheList = value;
        });
      }
    })
  }
  
  addClothe(id: string){  
    this.clotheService.get(id).subscribe((clothe) => {
      this.selectedClothe = clothe;
      this.action = "add";
      this.buildForm();
      this.isModalOpen = true;
    })
  }

  editClothe(id: string){ console.log(id)
    this.clotheService.get(id).subscribe((clothe) => {
      this.selectedClothe = clothe;
      this.action = "edit";
      this.buildForm();
      this.isModalOpen = true;
    })
  }

  deleteClothe(id: string){
    this.clotheService.get(id).subscribe((clothe) => {
      this.selectedClothe = clothe;
      this.action = "delete";
      this.buildForm();
      this.isModalOpen = true;
    })
  }

  addToList(maMH: string, clothe: CreateImportDetailDto){
    let clotheToDisplay= {
      maMH: maMH,
      tenMH: this.selectedClothe.tenMH,
      sizeMH: this.selectedClothe.sizeMH,
      soLuongNhap: clothe.soLuongNhap,
      giaNhap: clothe.giaNhap,
      thanhTienNhap:clothe.giaNhap * clothe.soLuongNhap
    }
    let foundClothe = this.selectedClotheListToDisplay.find(x => x.maMH == maMH);

    if(this.selectedClotheListToDisplay.length == 0 || foundClothe == undefined){
      this.selectedClotheListToDisplay.push(clotheToDisplay)
    }
    else{
    }
  }

  deleteFromList(maMH: string){
    let selectecClotheToDisplayIndex = this.selectedClotheListToDisplay.findIndex(y => y.maMH == maMH);
    
    this.selectedClotheListToDisplay.splice(selectecClotheToDisplayIndex, 1);

    this.importTotal = Object.keys(this.selectedClotheListToDisplay).reduce((total: any, key: string | number) => {
      return total + this.selectedClotheListToDisplay[key].thanhTienNhap;
    }, 0);

    document.forms['import-form']['import-total'].value = this.importTotal;
  }

  updateInList(maMH: string, clothe: CreateImportDetailDto){
    let selectecClotheToDisplay = this.selectedClotheListToDisplay.find(y => y.maMH == maMH);

    selectecClotheToDisplay.soLuongNhap = clothe.soLuongNhap;
    selectecClotheToDisplay.giaNhap = clothe.giaNhap;
    selectecClotheToDisplay.thanhTienNhap = clothe.soLuongNhap*clothe.giaNhap;
  }

  buildForm(){
    let foundClothe = this.selectedClotheListToDisplay.find(x => x.maMH === this.selectedClothe.id);

    //Nếu mặt hàng này đã được chọn
    if(foundClothe == undefined){
      this.form = this.fb.group({
        tenMH: [this.selectedClothe.tenMH, [Validators.required, Validators.maxLength(128)]],
        sizeMH: [this.selectedClothe.sizeMH, Validators.required],
        soLuongNhap: [0, [Validators.required, Validators.min(1)]],
        giaNhap: [0, [Validators.required, Validators.min(0)]] 
      });
    }
    //Nếu mặt hàng này chưa được chọn
    else{
      this.form = this.fb.group({
        tenMH: [this.selectedClothe.tenMH, [Validators.required, Validators.maxLength(128)]],
        sizeMH: [this.selectedClothe.sizeMH, Validators.required],
        soLuongNhap: [this.action == "add" ? 0 : foundClothe.soLuongNhap, [Validators.required, Validators.min(1)]],
        giaNhap: [this.action == "add" ? 0 : foundClothe.giaNhap, [Validators.required, Validators.min(0)]] 
      });
    }
  }

  saveClothe(){
    if (this.form.invalid) {
      return;
    }

    if(this.action == "add"){
      this.addToList(this.selectedClothe.id, this.form.value);
    }
    else if(this.action == "edit"){
      this.updateInList(this.selectedClothe.id, this.form.value);
    }
    else {
      this.deleteFromList(this.selectedClothe.id);
    }

    this.importTotal = Object.keys(this.selectedClotheListToDisplay).reduce((total: any, key: string | number) => {
      return total + this.selectedClotheListToDisplay[key].thanhTienNhap;
    }, 0);

    document.forms['import-form']['import-total'].value = this.importTotal;

    this.action = null;
    this.isModalOpen = false;
    this.form.reset();
  }
}