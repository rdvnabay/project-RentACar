import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Todo } from '../models/todo';
import { Observable } from 'rxjs';
import { TodoResponseModel } from '../models/todoResponseModel';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  apiUrl= 'https://jsonplaceholder.typicode.com/todos';
  constructor(private httpClient:HttpClient) { }

  getTodos():Observable<Todo[]> {
    return this.httpClient.get<Todo[]>(this.apiUrl);
  }}