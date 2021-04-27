import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css'],
})
export class CarComponent implements OnInit {
  cars: Car[] = [];
  dataLoaded:boolean=false;
  constructor(
    private carService: CarService,
    private activatedRoute:ActivatedRoute) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["brandId"]){
        this.getAllByBrand(params["brandId"]);
        console.log(params['brandId']);
      }
      else{
        this.getAll();
      }
    })
  }

  getAll() {
    this.carService.getAll().subscribe((response) => {
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
}
