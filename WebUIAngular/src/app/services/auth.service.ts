import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/loginModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl: string = 'https://localhost:44303/api/auth/';
  constructor(private httpClient: HttpClient) {}

  login(loginModel: LoginModel):Observable<LoginModel> {
    let newPath = this.apiUrl + 'login';
    return this.httpClient.post<LoginModel>(newPath, loginModel);
  }
}
