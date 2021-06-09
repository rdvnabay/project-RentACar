import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../../../../models/listResponseModel';
import { Color } from '../models/color';
import { ResponseModel } from '../../../../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class ColorService {
  apiUrl='https://localhost:44303/api/colors/';
  constructor(private httpClient:HttpClient) { }

  add(color: Color): Observable<ResponseModel> {
    let newPath = this.apiUrl + 'add';
    return this.httpClient.post<ResponseModel>(newPath, color);
  }

  delete(color:Color):Observable<ResponseModel>{
    let newPath=this.apiUrl+'delete';
    return this.httpClient.post<ResponseModel>(newPath,color);
  }

  getAll():Observable<ListResponseModel<Color>>{
    let newPath=this.apiUrl+'getall';
    return this.httpClient.get<ListResponseModel<Color>>(newPath);
  }
}
