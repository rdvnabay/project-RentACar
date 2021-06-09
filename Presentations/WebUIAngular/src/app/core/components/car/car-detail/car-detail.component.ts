import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from '../../admin/car/models/car';
import { CarService } from '../../admin/car/services/car.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: []
})
export class CarDetailComponent implements OnInit {
  car:Car;
  constructor(
    private carService:CarService,
    private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["carId"]){
        this.getBy(params["carId"])
      }
    })
  }

  getBy(carId:number){
    return this.carService.getBy(carId).subscribe(response=>{
      this.car=response.data;
    })
  }
}
