import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,FormControl,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-brand-add',
  templateUrl: './brand-add.component.html',
  styleUrls: []
})
export class BrandAddComponent implements OnInit {
  brandAddForm: FormGroup;
  constructor(
    private brandService: BrandService,
    private formBuilder: FormBuilder,
    private router:Router,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createBrandForm();
  }

  add(){
    if(this.brandAddForm.valid){
      console.log(this.brandAddForm.value)
      let brandModel=Object.assign({},this.brandAddForm.value);

      this.brandService.add(brandModel).subscribe(response=>{
        this.toastrService.success('Marka eklendi','Başarılı');
        this.router.navigateByUrl('admin');
      },responseError=>{
        this.toastrService.error(responseError.error);
      })
    }
  }

  createBrandForm() {
    this.brandAddForm=this.formBuilder.group({
      name: ['', Validators.required],
    });
  }
}
