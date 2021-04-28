import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Car } from '../models/car';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  apiUrl = 'https://localhost:44303/api/';
  constructor(private httpClient: HttpClient) {}

  getAll(): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + 'cars/getall';
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getAllByBrand(brandId: number): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + 'cars/getallbybrand?brandId=1';
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getAllDetail(): Observable<ListResponseModel<Car>> {
    let newPath: string = this.apiUrl + 'cars/detail';
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }
}
