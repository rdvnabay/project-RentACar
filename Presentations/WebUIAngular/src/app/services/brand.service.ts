import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Brand } from '../models/brand';
import { ListResponseModel } from '../models/listResponseModel';
import { ResponseModel } from '../models/responseModel';
import { SingleResponseModel } from '../models/singleResponseModel';

@Injectable({
  providedIn: 'root',
})
export class BrandService {
  apiUrl: string = 'https://localhost:44303/api/brands/';
  constructor(private httpClient: HttpClient) {}

  add(brand: Brand): Observable<ResponseModel> {
    let newPath = this.apiUrl + 'add';
    return this.httpClient.post<ResponseModel>(newPath, brand);
  }

  delete(brandId:number):Observable<ResponseModel>{
    let newPath=this.apiUrl+'delete?brandId='+brandId;
    return this.httpClient.post<ResponseModel>(newPath,brandId);
  }

  getAll(): Observable<ListResponseModel<Brand>> {
    let newPath = this.apiUrl + 'getall';
    return this.httpClient.get<ListResponseModel<Brand>>(newPath);
  }
}
