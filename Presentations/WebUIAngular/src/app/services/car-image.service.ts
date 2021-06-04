import { ResponseModel } from './../models/responseModel';
import { Observable } from 'rxjs';
import { CarImageAddDto } from './../models/dtos/carImageAddDto';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CarImageService {
  apiUrl = 'https://localhost:44303/api/carimages/';
  constructor(private httpClient:HttpClient) { }

  add(carImageAddDto:CarImageAddDto ):Observable<ResponseModel>{
  var newPath=this.apiUrl+'add';
  return this.httpClient.post<ResponseModel>(newPath,carImageAddDto);
  }
}
