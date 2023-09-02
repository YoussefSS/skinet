import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

// We'll be making calls to our API here
// When a user logs in, we'll store them here, and we'll have an observable that other components can subscribe to

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) {}

  loadCurrentUser(token: string) {
    // We'll send the token to our API so that we can authenticate them
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<User>(this.baseUrl + 'account', { headers }).pipe(
      // We'll update the currentUser observable and set the token
      map((user) => {
        localStorage.setItem('token', user.token); // store the token in local storage so that it persists
        this.currentUserSource.next(user); // store the user object inside the observable
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
}
