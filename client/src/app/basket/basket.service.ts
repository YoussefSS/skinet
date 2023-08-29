import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Basket } from '../shared/models/basket';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket | null>(null); // we have to give it an initial value
  basketSource$ = this.basketSource.asObservable(); // our components can subscribe to this and be notified of changes and update accordingly

  constructor(private http: HttpClient) {}

  // Unlike previously where we would subscribe to the get methods, our other components will just use basketSource$

  getBasket(id: string) {
    return this.http.get<Basket>(this.baseUrl + 'basket?id=' + id).subscribe({
      next: (basket) => this.basketSource.next(basket),
    });
  }

  setBasket(basket: Basket) {
    return this.http.post<Basket>(this.baseUrl + 'basket', basket).subscribe({
      next: (basket) => this.basketSource.next(basket),
    });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }
}
