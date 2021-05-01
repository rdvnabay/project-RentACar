import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent implements OnInit {

  dataLoaded:boolean=false;
  brands: Brand[] = [];
  currentBrand:Brand;
  filterText:string="";
  constructor(private brandService:BrandService) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.brandService.getAll().subscribe(response=>{
      this.brands=response.data;
      this.dataLoaded=true;
    })
  }

  setCurrentBrand(brand:Brand){
   this.currentBrand=brand;
  }

  getCurrentBrandClass(brand:Brand){
    if(brand==this.currentBrand){
      return "list-group-item active";
    }
    else{
      return "list-group-item";
    }
  }

  getAllCategoryClass(){
    if(!this.currentBrand){
      return "list-group-item active";
    }
    else{
      return "list-group-item";
    }
  }
}
