import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit, Query } from '@angular/core';
import { SupplierRoutingModule } from './supplier-routing.module';
import { CreateSupplierClotheDto, DeleteSupplierClotheDto, SupplierClotheService, SupplierDto, SupplierService } from '@proxy/suppliers';
import { ClotheDto, ClotheService } from '@proxy/clothes';
import { ImportDto, ImportService } from '@proxy/imports';
import { query } from '@angular/animations';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.scss'],
  providers: [ListService]
})
export class SupplierComponent implements OnInit {
  supplierList = { items: [], totalCount: 0} as PagedResultDto<SupplierDto>;
  clotheList = { items: [], totalCount: 0 } as PagedResultDto<ClotheDto>;
  importList = { items: [], totalCount: 0} as PagedResultDto<ImportDto>;
  clotheSelectionList = { items: [], totalCount: 0} as PagedResultDto<ClotheDto>;
  selectedClotheList = {items: [], totalCount: 0} as PagedResultDto<ClotheDto>;

  selectedSupplier = {} as SupplierDto;
  selectedClothe = {} as ClotheDto;

  form: FormGroup;

  isModalOpen = false;

  constructor(
    private readonly list: ListService,
    private readonly supplierService: SupplierService,
    private readonly clotheService: ClotheService,
    private readonly supplierClotheService: SupplierClotheService,
    private readonly importService: ImportService,
    private readonly fb: FormBuilder,
    private readonly confirmationService: ConfirmationService
    ) { }

  ngOnInit(): void {
    const supplierStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getList(query);
    
    this.list.hookToQuery(supplierStreamCreator).subscribe((respone) => {
      this.supplierList = respone;

      const clotheSelectionStreamCreator = (query: PagedAndSortedResultRequestDto) => this.clotheService.getList(query);
      this.list.hookToQuery(clotheSelectionStreamCreator).subscribe((clothe) => {
        this.clotheSelectionList = clothe;
      })
    })
  }
  
  closeModel(){
    this.resetValues();
  }

  resetValues(){
    this.form.reset;
    this.isModalOpen = false;
    this.selectedClotheList = {items: [], totalCount: 0} as PagedResultDto<ClotheDto>;
    this.selectedSupplier = {} as SupplierDto;
    this.selectedClothe = {} as ClotheDto;

    const supplierStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getList(query);
    
    this.list.hookToQuery(supplierStreamCreator).subscribe((respone) => {
      this.supplierList = respone;
    });
  }

  createSupplier(){
    this.selectedSupplier = {} as ClotheDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editSupplier(supplierId: string){
    this.supplierService.get(supplierId).subscribe((value) => {
      this.selectedSupplier = value;

      const clotheStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getSupplierClothes(this.selectedSupplier.id, query);
      this.list.hookToQuery(clotheStreamCreator).subscribe((clothe) => {
        this.selectedClotheList = clothe;
        this.buildForm();
        this.isModalOpen = true;
      })
    });
  }

  deleteSupplier(supplierId: string){
    this.confirmationService.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if(status == Confirmation.Status.confirm){
        this.supplierService.delete(supplierId).subscribe(() => this.list.get());
      }
    });
  }

  addClothe(clothe: ClotheDto){
    const duplicateClothe = this.selectedClotheList.items.find(x => x.id == clothe.id);
    if(duplicateClothe != undefined)
    {
      alert("Mặt hàng đã được chọn!");
    }
    else{
      this.selectedClothe = clothe;
      this.selectedClotheList.items.push(clothe);
      this.selectedClotheList.totalCount = this.selectedClotheList.items.length;
      console.log(this.selectedClotheList)
    }
  }

  deleteClothe(clothe: ClotheDto){
    const notFoundClothe = this.selectedClotheList.items.find(x => x.id == clothe.id);
    if(notFoundClothe == undefined){
      alert("Mặt hàng chưa được chọn!");
    }
    else{ 
      const index = this.selectedClotheList.items.findIndex(x => x.id == clothe.id);
      this.selectedClotheList.items.splice(index, 1);
      this.selectedClotheList.totalCount = this.selectedClotheList.items.length;
      console.log(this.selectedClotheList)
    }
  }

  showSupplierClotheAndImport(supplierId: string, row: any){
    const clotheStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getSupplierClothes(supplierId, query);

    this.list.hookToQuery(clotheStreamCreator).subscribe((clotheValue) => {
      this.clotheList = clotheValue;

      const importStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getSupplierImports(supplierId, query);
      this.list.hookToQuery(importStreamCreator).subscribe((importValue) => {
        this.importList = importValue;
        console.log(this.clotheList);
        console.log(this.importList);
        console.log(row)
      })
    });
  }

  buildForm(){
    this.form = this.fb.group({
      tenNCC: [this.selectedSupplier.tenNCC || '', [Validators.required]],
      diaChiNCC: [this.selectedSupplier.diaChiNCC || '', Validators.required],
      lienLacNCC: [this.selectedSupplier.lienLacNCC || '', Validators.required],
    });
  }

  save(){
    if (this.form.invalid) {
      return;
    }

    const request = !this.selectedSupplier.id ? this.supplierService.create(this.form.value) : this.supplierService.update(this.selectedSupplier.id, this.form.value);

    request.subscribe((respone) => { 
      if(this.selectedSupplier.id != undefined){ console.log("Đang cập nhập nhà cung cấp");
        const clotheStreamCreator = (query: PagedAndSortedResultRequestDto) => this.supplierService.getSupplierClothes(this.selectedSupplier.id, query);
        this.list.hookToQuery(clotheStreamCreator).subscribe((oldList)=> {
          const oldSupplierClotheList = oldList;
          this.selectedClotheList.items.forEach(element => {
            const foundCLothe = oldSupplierClotheList.items.find(x => x.id == element.id);
            //Nếu không tìm thấy thì thêm
            if(foundCLothe == undefined){
              this.supplierClotheService.create({ maMH: element.id, maNCC: this.selectedSupplier.id} as CreateSupplierClotheDto).subscribe();
            }
          });
          //Xóa những mặt hàng cũ mà không được chọn
          oldSupplierClotheList.items.forEach(oldClothe => { 
            const deletedClothe = this.selectedClotheList.items.find(x => x.id == oldClothe.id); console.log(deletedClothe)
            if(deletedClothe == undefined){ 
              this.supplierClotheService.delete({ maMH: oldClothe.id, maNCC: this.selectedSupplier.id} as DeleteSupplierClotheDto).subscribe();
            }
          });
        });

      }
      else{ console.log("Đang tạo mới NCC");
        this.selectedClotheList.items.forEach(element => {
          const supplierClothe = { maMH: element.id, maNCC: respone.id } as CreateSupplierClotheDto
          this.supplierClotheService.create(supplierClothe).subscribe(() => {
            this.list.get();
          });
        });
      }
    });
  }
}
