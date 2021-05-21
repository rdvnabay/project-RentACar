import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/models/car';
import { CarDetail } from 'src/app/models/carDetail';
import { CarDto } from 'src/app/models/dtos/carDto';
import { CarService } from 'src/app/services/car.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: []
})
export class CarListComponent implements OnInit {

  cars: Car[] = [];
  carDetails:CarDetail[]=[];
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
        this.getAllDetail()
      }
    })
  }

  getAll() {
    this.carService.getAll().subscribe(response => {
      // this.cars = response.data;
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

  getAllDetail(){
    this.carService.getAllDetail().subscribe(response=>{
      this.carDetails=response.data;
    })
  }

  addToCart(car:Car){
    this.toastrService.success("Eklendi",car.name);
    this.cartService.addToCart(car);
  }
}
