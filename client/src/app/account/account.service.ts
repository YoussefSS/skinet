import { Injectable } from '@angular/core';
import { ReplaySubject, map, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Address, User } from '../shared/models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

// We'll be making calls to our API here
// When a user logs in, we'll store them here, and we'll have an observable that other components can subscribe to

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) {}

  loadCurrentUser(token: string | null) {
    if (token === null) {
      this.currentUserSource.next(null); // We are ensuring there's always something in our replay subject
      return of(null); // returns the same type of this method but with the value we passed in. In this case an observable of null
    }

    // We'll send the token to our API so that we can authenticate them
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<User>(this.baseUrl + 'account', { headers }).pipe(
      // We'll update the currentUser observable and set the token
      map((user) => {
        if (user) {
          localStorage.setItem('token', user.token); // store the token in local storage so that it persists
          this.currentUserSource.next(user); // store the user object inside the observable
          return user;
        } else {
          return null;
        }
      })
    );
  }

  // Will receive values from a form
  login(values: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', values).pipe(
      map((user) => {
        localStorage.setItem('token', user.token); // store the token in local storage so that it persists
        this.currentUserSource.next(user); // store the user object inside the observable
      })
    );
  }

  // Will receive values from a form
  // We'll consider a user logged in after they've registered
  register(values: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', values).pipe(
      map((user) => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string) {
    return this.http.get<boolean>(
      this.baseUrl + 'account/emailExists?email=' + email
    );
  }

  getUserAddress() {
    return this.http.get<Address>(this.baseUrl + 'account/address');
  }

  updateUserAddress(address: Address) {
    return this.http.put(this.baseUrl + 'account/address', address);
  }
}
