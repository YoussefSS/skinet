import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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

  onSubmit() {
    console.log(this.loginForm.value);
  }
}
