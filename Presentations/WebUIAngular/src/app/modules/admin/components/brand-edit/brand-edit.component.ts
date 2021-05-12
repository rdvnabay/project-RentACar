import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-brand-edit',
  templateUrl: './brand-edit.component.html',
  styleUrls: [],
})
export class BrandEditComponent implements OnInit {
  brandEditForm: FormGroup;
  constructor(
    private brandService:BrandService,
    private activatedRoute:ActivatedRoute,
    private formBuilder: FormBuilder,
    private router:Router,
    private toastrService:ToastrService) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["brandId"]){
        this.edit();
        this.createBrandForm();
      }
    })

  }

  createBrandForm() {
    this.formBuilder.group({
      name: ['', Validators.required],
    });
  }

  edit(){
    if(this.brandEditForm.valid){
      console.log(this.brandEditForm.value)
      let brandModel=Object.assign({},this.brandEditForm.value);

      this.brandService.edit(brandModel).subscribe(response=>{
        this.toastrService.info('Marka güncellendi','Başarılı');
        this.router.navigateByUrl('admin');
      },responseError=>{
        this.toastrService.error(responseError.error);
      })
    }
  }
}
