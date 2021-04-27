import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css'],
})
export class CarComponent implements OnInit {
  cars: Car[] = [];
  dataLoaded:boolean=false;
  filterText:string="";
  constructor(
    private carService: CarService,
    private activatedRoute:ActivatedRoute,
    private toastrService:ToastrService,
    private cartService:CartService) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["brandId"]){
        this.getAllByBrand(params["brandId"])
      }else{
        this.getAll()
      }
    })
  }

  getAll() {
    this.carService.getAll().subscribe(response => {
      this.cars = response.data;
      this.dataLoaded=true;
      console.log(response.data);
    });
  }

  getAllByBrand(brandId:number){
    this.carService.getAllByBrand(brandId).subscribe(response=>{
      this.cars=response.data;
      console.log(response.data);
    })
  }

  addToCart(car:Car){
    this.toastrService.success("Eklendi",car.name);
    this.cartService.addToCart(car);
  }
}
