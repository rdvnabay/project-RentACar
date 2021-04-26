import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/models/brand';
import { Todo } from 'src/app/models/todo';
import { BrandResponseModel } from 'src/app/models/brandResponseModel';
import { TodoResponseModel } from 'src/app/models/todoResponseModel';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  
  apiTodoUrl= 'https://jsonplaceholder.typicode.com/todos';
  todos: Todo[] = [];
  brands: Brand[] = [];

  constructor(private brandService:BrandService) {}

  ngOnInit(): void {
    this.getBrands();
  }

  getBrands() {
    this.brandService.getBrands().subscribe(response=>{
      this.brands=response.data;
    })
  }

  // getTodos() {
  //   this.httpClient
  //   .get<TodoResponseModel>(this.apiTodoUrl)
  //   .subscribe((response) => {
  //     this.todos = response.data;
  //   });
  // }
}
