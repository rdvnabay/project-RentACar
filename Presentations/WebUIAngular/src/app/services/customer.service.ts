import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
apiUrl:string='https://localhost:44303/api/customers/'
  constructor(private httpClient:HttpClient) { }

  getAll():Observable<ListResponseModel<Customer>>{
    let newPath:string='getall';
  return this.httpClient.get<ListResponseModel<Customer>>(newPath);
  }
}
