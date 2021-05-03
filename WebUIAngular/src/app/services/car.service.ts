import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Car } from '../models/car';
import { CarDetail } from '../models/carDetail';
import { ItemResponseModel } from '../models/itemResponseModel';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  apiUrl = 'https://localhost:44303/api/';
  constructor(private httpClient: HttpClient) {}
  
add(car:Car):Observable<ResponseModel>{
  let newPath:string=this.apiUrl+'cars/add';
  return this.httpClient.post<ResponseModel>(newPath,car);
}

  getBy(carId:number):Observable<ItemResponseModel<Car>>{
    let newPath:string=this.apiUrl+'cars/getdetails?carId=carId';
    return this.httpClient.get<ItemResponseModel<Car>>(newPath);
  }

  getAll(): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + 'cars/getall';
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getAllByBrand(brandId: number): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + 'cars/getallbybrand?brandId=1';
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getAllDetail(): Observable<ListResponseModel<CarDetail>> {
    let newPath: string = this.apiUrl + 'cars/getcardetails';
    return this.httpClient.get<ListResponseModel<CarDetail>>(newPath);
  }
}
