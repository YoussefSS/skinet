import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BasketItem } from '../models/basket';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-basket-summary',
  templateUrl: './basket-summary.component.html',
  styleUrls: ['./basket-summary.component.scss'],
})
export class BasketSummaryComponent {
  @Output() addItem = new EventEmitter<BasketItem>();
  @Output() removeItem = new EventEmitter<{ id: number; quantity: number }>(); // we can only emit 1 thing so we put multiple things in 1 object
  @Input() isBasket = true; // We'll show less items if we're not a basket (ie checkout)

  constructor(public basketService: BasketService) {}

  addBasketItem(item: BasketItem) {
    this.addItem.emit(item);
  }

  removeBasketItem(id: number, quantity = 1) {
    this.removeItem.emit({ id, quantity });
  }
}
