import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,FormControl,Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ColorService } from 'src/app/core/services/color.service';

@Component({
  selector: 'app-color-add',
  templateUrl: './color-add.component.html',
  styleUrls: []
})
export class ColorAddComponent implements OnInit {

  colorAddForm: FormGroup;
  constructor(
    private colorService: ColorService,
    private formBuilder: FormBuilder,
    private router:Router,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createBrandForm();
  }

  add(){
    if(this.colorAddForm.valid){
      console.log(this.colorAddForm.value)
      let colorModel=Object.assign({},this.colorAddForm.value);

      this.colorService.add(colorModel).subscribe(response=>{
        this.toastrService.success('Marka eklendi','Başarılı');
        this.router.navigateByUrl('admin');
      },responseError=>{
        this.toastrService.error(responseError.error);
      })
    }
  }

  createBrandForm() {
    this.colorAddForm=this.formBuilder.group({
      name: ['', Validators.required],
    });
  }
}
