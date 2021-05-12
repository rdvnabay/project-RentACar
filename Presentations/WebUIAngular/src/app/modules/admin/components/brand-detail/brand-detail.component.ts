import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-brand-detail',
  templateUrl: './brand-detail.component.html',
  styleUrls: []
})
export class BrandDetailComponent implements OnInit {
  brand:Brand;
  constructor(
    private brandService:BrandService
  ) { }

  ngOnInit(): void {
    this.detail();
  }

  detail(){
    this.brandService.getById(this.brand.id).subscribe(response=>{
this.brand=response.data;
    });
  }
}
