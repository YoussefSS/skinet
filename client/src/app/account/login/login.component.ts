import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm = new FormGroup({
    // Here we define our FormControls
    email: new FormControl('', Validators.required), // initial value in parenthesis
    password: new FormControl('', Validators.required),
  });

  constructor(private accountService: AccountService) {}
  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe({
      next: (user) => console.log(user),
    });
  }
}
