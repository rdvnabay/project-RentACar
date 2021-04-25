import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  product1: any = {
    productId: 1,
    productName: 'Laptop',
    price: 5000,
    categoryId: 1,
  };
  product2: any = {
    productId: 2,
    productName: 'Mouse',
    productPrice: 44,
    categoryId: 1,
  };
  product3: any = {
    productId: 3,
    productName: 'Keyboard',
    price: 100,
    categoryId: 1,
  };
  product4: any = {
    productId: 4,
    productName: 'Phone',
    price: 3500,
    categoryId: 2,
  };
  product5: any = {
    productId: 5,
    productName: 'Pencil',
    price: 20,
    categoryId: 3,
  };

  products = [
    this.product1,
    this.product2,
    this.product3,
    this.product4,
    this.product5,
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
