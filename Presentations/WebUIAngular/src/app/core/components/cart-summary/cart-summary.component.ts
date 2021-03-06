import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Car } from '../admin/car/models/car';
import { CartItem } from '../../models/cartItem';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart-summary',
  templateUrl: './cart-summary.component.html',
  styleUrls: []
})
export class CartSummaryComponent implements OnInit {
  cartItems:CartItem[];
  constructor(
    private cartService:CartService,
    private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart(){
   this.cartItems=this.cartService.listCart();
  }

  removeFromCart(car:Car){
    this.cartService.removeFromCart(car);
    this.toastrService.error("Silindi",car.name);
  }
}
