import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/core/models/brand';
import { Color } from 'src/app/core/models/color';
import { BrandService } from 'src/app/core/services/brand.service';
import { CarService } from 'src/app/core/services/car.service';
import { ColorService } from 'src/app/core/services/color.service';

@Component({
  selector: 'app-car-add',
  templateUrl: './car-add.component.html',
  styleUrls: [],
})
export class CarAddComponent implements OnInit {
  carAddForm: FormGroup;
  brands: Brand[] = [];
  colors: Color[] = [];

  constructor(
    private carService: CarService,
    private brandService: BrandService,
    private colorService: ColorService,
    private formBuilder: FormBuilder,
    private router: Router,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createCarAddForm();
    this.getAllBrands();
    this.getAllColors();
  }

  createCarAddForm() {
    this.carAddForm = this.formBuilder.group({
      description: ['', Validators.required],
      dailyPrice: ['', Validators.required],
      modelYear: ['', Validators.required],
      name: ['', Validators.required],
      brandId: ['', Validators.required],
      colorId: ['', Validators.required],
      imagePath:['']
    });
  }

  add() {
    if (this.carAddForm.valid) {
      let carAddDtoModel = Object.assign({}, this.carAddForm.value);
      this.carService.add(carAddDtoModel).subscribe(
        response => {
          this.toastrService.success('Araç eklendi', 'Başarılı');
          this.router.navigateByUrl('admin');
        },
        responseError => {
          this.toastrService.error(responseError.error);
        });
    }
  }

  getAllBrands() {
    return this.brandService.getAll().subscribe((response) => {
      this.brands = response.data;
    });
  }

  getAllColors() {
    return this.colorService.getAll().subscribe((response) => {
      this.colors = response.data;
    });
  }
}
