import * as cuid from 'cuid';

export interface Basket {
  id: string;
  items: BasketItem[];
}

export interface BasketItem {
  id: number;
  productName: string;
  price: number;
  quantity: number;
  pictureUrl: string;
  brand: string;
  type: string;
}

// making it a class to give it default values
// When we create a new basket, we want it to have a unique id and an empty array of items
export class Basket implements Basket {
  id = cuid();
  items: BasketItem[] = [];
}
