import { Component, OnInit } from '@angular/core';
import { CarDto } from 'src/app/models/dtos/carDto';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: []
})
export class CarListComponent implements OnInit {

  cars:CarDto[]=[];
  constructor(private carService:CarService) { }

  ngOnInit(): void {
    this.getAll();
  }


  delete(carId:number){

  }

  getAll(){
return this.carService.getAll().subscribe(response=>{
this.cars=response.data;
})
  }
}
