import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: []
})
export class CarListComponent implements OnInit {

  cars:Car[]=[];
  constructor() { }

  ngOnInit(): void {
  }


  delete(carId:number){

  }
}
