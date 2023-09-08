import { ConfigStateService, ListResultDto, ListService, PagedResultDto, ApplicationConfigurationDto } from '@abp/ng.core';
import { ConfirmationService } from '@abp/ng.theme.shared';
import { query } from '@angular/animations';
import { Console } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClotheDto, ClotheService } from '@proxy/clothes';
import { ImportDetailService, ImportService } from '@proxy/imports';
import { CancelImportDto, CreateImportDetailDto, CreateImportDto, CreateManyImportDetailsDto, ImportClotheListDto } from '@proxy/imports/models';
import { SupplierDto, SupplierService } from '@proxy/suppliers';
@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss'],
  providers: [ListService],
})
export class ImportComponent implements OnInit {
  clotheList = { items: [], totalCount: 0 } as PagedResultDto<ImportClotheListDto>;
  selectedClothe = { } as ClotheDto;

  supplierList = { items: [], totalCount: 0 } as PagedResultDto<SupplierDto>;

  parentPro = "Thuộc tính từ parent";
  selectedClotheListToDisplay = [];
  action = null;
  currentUser = {} as ApplicationConfigurationDto["currentUser"];
  form: FormGroup;
  importInfoForm: FormGroup;
  importTotal: number;

  isModalOpen = false;

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
    const clotheStreamCreator = (query) => this.importDetailService.getClotheListByInput(query);

    this.list.hookToQuery(clotheStreamCreator).subscribe((response) => {
      this.clotheList = response;
    });
    const supplierStreamCreator = (query2) => this.supplierService.getList(query2);

    this.list.hookToQuery(supplierStreamCreator).subscribe((response) => {
      this.supplierList = response;
    }) 

    const response = this.configService.getOne("currentUser.id");

    this.configService.getOne$("currentUser").subscribe(response => {
      this.currentUser = response;
      console.log(this.currentUser)
    })
  }
  
  openBootstrapModal(){debugger
    const modelDiv = document.getElementById('myModal');
    
    if(modelDiv != null){
      modelDiv.style.display = 'block';

      this.importTotal = Object.keys(this.selectedClotheListToDisplay).reduce((total: any, key: string | number) => {
        return total + this.selectedClotheListToDisplay[key].thanhTienNhap;
      }, 0); //Tính tổng tiền phiếu nhập mỗi khi bấm nút tạo PN

      document.forms['import-form']['import-supplier'].value = (<HTMLInputElement>document.getElementById('supplierSelection')).value;
      document.forms['import-form']['import-creator'].value = this.currentUser.name;
      document.forms['import-form']['import-total'].value = this.importTotal;
    }
  }

  closeBootstrapModal(){
    const modelDiv = document.getElementById('myModal');

    if(modelDiv != null){
      modelDiv.style.display = 'none';
    }
  }

  getSelectedSupplier(obj: {}){
    var option = obj.valueOf();
    console.log(option);
  }

  createImport(){ debugger
    const selectedSupplier = this.supplierList.items.find(x => x.tenNCC == (<HTMLInputElement>document.getElementById('supplierSelection')).value);

    const createImport = { maNCC: selectedSupplier.id, tongTienNhap:  this.importTotal} as CreateImportDto;
      this.importService.create(createImport).subscribe((response) => {
        const returnedImport = response;

        let selectedClothesList = [] as CreateImportDetailDto[]  
        this.selectedClotheListToDisplay.forEach(element => {
          (selectedClothesList).push({ maPN: returnedImport.id, maMH: element.maMH, soLuongNhap: element.soLuongNhap, giaNhap: element.giaNhap  } as CreateImportDetailDto)
        });

        const createManyDetail = { importDetails:selectedClothesList } as CreateManyImportDetailsDto;
        console.log(createManyDetail);
        this.importDetailService.create(createManyDetail).subscribe();
      });
      
    
  }

  cancelImport(){
    const updateDto = { maPN: (<HTMLInputElement>document.getElementById('import-id')).value } as CancelImportDto
    this.importService.update( updateDto ).subscribe((response) => {
      document.forms['import-form']['import-status'].value = response.tinhTrangPX;
    });
  } 

  addClothe(id: string){ 
    this.clotheService.get(id).subscribe((clothe) => {
      this.selectedClothe = clothe;
      this.action = "add";
      this.buildForm();
      this.isModalOpen = true;
    })
  }

  editClothe(id: string){
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
  }

  updateInList(maMH: string, clothe: CreateImportDetailDto){
    let selectecClotheToDisplay = this.selectedClotheListToDisplay.find(y => y.maMH == maMH);

    selectecClotheToDisplay.soLuongNhap = clothe.soLuongNhap;
    selectecClotheToDisplay.giaNhap = clothe.giaNhap;
    selectecClotheToDisplay.thanhTienNhap = clothe.soLuongNhap*clothe.giaNhap;
  }

  buildForm(){
    let foundClothe = this.selectedClotheListToDisplay.find(x => x.maMH === this.selectedClothe.id);
    if(foundClothe == undefined){
      this.form = this.fb.group({
        tenMH: [this.selectedClothe.tenMH, Validators.required],
        sizeMH: [this.selectedClothe.sizeMH, Validators.required],
        soLuongNhap: [0, Validators.required],
        giaNhap: [0, Validators.required] 
      });
    }
    else{
      this.form = this.fb.group({
        tenMH: [this.selectedClothe.tenMH, Validators.required],
        sizeMH: [this.selectedClothe.sizeMH, Validators.required],
        soLuongNhap: [this.action == "add" ? 0 : foundClothe.soLuongNhap, Validators.required],
        giaNhap: [this.action == "add" ? 0 : foundClothe.giaNhap, Validators.required] 
      });
    }
  }

  save(){
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

    this.action = null;
    this.isModalOpen = false;
    this.form.reset();
  }
}
