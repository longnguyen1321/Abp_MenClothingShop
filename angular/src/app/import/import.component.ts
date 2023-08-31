import { ListResultDto, ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService } from '@abp/ng.theme.shared';
import { query } from '@angular/animations';
import { Console } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClotheDto, ClotheService } from '@proxy/clothes';
import { ImportDetailService } from '@proxy/imports';
import { CreateImportDetailDto, CreateImportDto, CreateManyImportDetailsDto, ImportClotheListDto } from '@proxy/imports/models';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss'],
  providers: [ListService],
})
export class ImportComponent implements OnInit {
  clotheList = { items: [], totalCount: 0 } as PagedResultDto<ImportClotheListDto>;
  selectedClothe = { } as ClotheDto;

  //selectedClothesList = {} as CreateManyImportDetailsDto;
  selectedImportClotheList = [];
  action = null;
  form: FormGroup;

  isModalOpen = false;

  constructor(private importDetailService: ImportDetailService, public readonly list: ListService, private fb: FormBuilder, private confirmation: ConfirmationService, private clotheService: ClotheService) { }

  ngOnInit(): void {
    const clotheStreamCreator = (query) => this.importDetailService.getClotheListByInput(query);

    this.list.hookToQuery(clotheStreamCreator).subscribe((response) => {
      this.clotheList = response;
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

  addToList(maMH: string, clothe: CreateImportDetailDto){ debugger
    let importDetail: CreateImportDetailDto = {
      maPN: "",
      maMH: maMH,
      soLuongNhap: clothe.soLuongNhap,
      giaNhap: clothe.giaNhap
    }

    let foundClothe = this.selectedImportClotheList.find(x => x.maMH == maMH);

    if(this.selectedImportClotheList.length == 0 || foundClothe == undefined){
      this.selectedImportClotheList.push(importDetail);
    }
    else{
      //return;
      console.log(this.selectedImportClotheList);
    }
  }

  deleteFromList(maMH: string){ debugger
    let selectedClotheIndex = this.selectedImportClotheList.findIndex(x => x.maMH == maMH); 
    console.log( this.selectedImportClotheList);
    if(selectedClotheIndex != -1){
    this.selectedImportClotheList.splice(selectedClotheIndex, 1);
    console.log( this.selectedImportClotheList);
    } 
  }

  updateInList(maMH: string, clothe: CreateImportDetailDto){
    let selectedClothe = this.selectedImportClotheList.find(x => x.maMH == maMH);
    selectedClothe.soLuongNhap = clothe.soLuongNhap;
    selectedClothe.giaNhap = clothe.giaNhap;
    console.log(this.selectedImportClotheList)
  }

  buildForm(){//console.log(this.selectedImportClotheList[0].maMH);
    let foundClothe = this.selectedImportClotheList.find(x => x.maMH === this.selectedClothe.id);
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

    //this.resetSelectedClothe();
    this.action = null;
    this.isModalOpen = false;
    this.form.reset();
  }
}
