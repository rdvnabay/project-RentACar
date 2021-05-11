import { Injectable } from '@angular/core';
import { Car } from '../models/car';
import { Cart } from '../models/cart';
import { CartItem } from '../models/cartItem';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor() { }

  addToCart(car:Car){
    let item=Cart.find(c=>c.car.id==car.id)
    if(item){
    item.quantity+=1;
    }
    else{
    let cartItem=new CartItem();
    cartItem.car=car;
    cartItem.quantity=1;
    Cart.push(cartItem);
    }
  }

  listCart():CartItem[]{
    return Cart;
  }

  removeFromCart(car:Car){
    let item=Cart.find(c=>c.car.id==car.id);
    Cart.splice(Cart.indexOf(item),1);
  }
}
