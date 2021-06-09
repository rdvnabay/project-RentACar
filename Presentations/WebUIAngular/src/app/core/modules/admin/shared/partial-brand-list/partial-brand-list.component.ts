import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/core/components/admin/brand/models/brand';
import { BrandService } from 'src/app/core/components/admin/brand/services/brand.service';

@Component({
  selector: 'app-partial-brand-list',
  templateUrl: './partial-brand-list.component.html',
  styleUrls: [],
})
export class PartialBrandListComponent implements OnInit {
  brands: Brand[] = [];
  constructor(private brandService: BrandService) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    return this.brandService.getAll().subscribe((response) => {
      this.brands = response.data;
    });
  }
}
