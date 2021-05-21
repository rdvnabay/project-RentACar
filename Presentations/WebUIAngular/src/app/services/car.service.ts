import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Car } from '../models/car';
import { CarDetail } from '../models/carDetail';
import { ResponseModel } from '../models/responseModel';
import { SingleResponseModel } from '../models/singleResponseModel';
import { CarAddDto } from '../models/dtos/carAddDto';
import { CarDto } from '../models/dtos/carDto';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  apiUrl = 'https://localhost:44303/api/cars/';
  constructor(private httpClient: HttpClient) {}

add(carAddDto:CarAddDto):Observable<ResponseModel>{
  let newPath:string=this.apiUrl+'add';
  return this.httpClient.post<ResponseModel>(newPath,carAddDto);
}

  getBy(carId:number):Observable<SingleResponseModel<Car>>{
    let newPath:string=this.apiUrl+'getdetails?carId=carId';
    return this.httpClient.get<SingleResponseModel<Car>>(newPath);
  }

  getAll(): Observable<ListResponseModel<CarDto>> {
    let newPath = this.apiUrl + 'getall';
    return this.httpClient.get<ListResponseModel<CarDto>>(newPath);
  }

  getAllByBrand(brandId: number): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + 'getallbybrand?brandId=1';
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getAllDetail(): Observable<ListResponseModel<CarDetail>> {
    let newPath: string = this.apiUrl + 'getcardetails';
    return this.httpClient.get<ListResponseModel<CarDetail>>(newPath);
  }
}
