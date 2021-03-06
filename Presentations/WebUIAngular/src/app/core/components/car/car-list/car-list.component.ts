import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CartService } from 'src/app/core/services/cart.service';
import { Car } from '../../admin/car/models/car';
import { CarDetail } from '../../admin/car/models/carDetail';
import { CarService } from '../../admin/car/services/car.service';

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
