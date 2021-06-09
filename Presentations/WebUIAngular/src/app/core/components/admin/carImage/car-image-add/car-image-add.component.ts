import {
  FormBuilder,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CarImageService } from '../services/car-image.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-image-add',
  templateUrl: './car-image-add.component.html',
  styleUrls: [],
})
export class CarImageAddComponent implements OnInit {
  carImageAddForm: FormGroup;
  constructor(
    private carImageService: CarImageService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {}

  add() {
    if (this.carImageAddForm.valid) {
      let carImageAddDtoModel = Object.assign({});
      this.carImageService.add(carImageAddDtoModel).subscribe((response) => {
        this.toastrService.success('Araç resimleri eklendi', 'Başarılı');
      });
    }
  }

  createCarImageAddForm() {
    this.carImageAddForm = this.formBuilder.group({
      carId: ['', Validators.required],
      imagePath: ['', Validators.required],
    });
  }
}
