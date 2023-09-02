import { Component } from '@angular/core';
import {
  AbstractControl,
  AsyncValidatorFn,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';
import { debounceTime, finalize, map, switchMap, take } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  errors: string[] | null = null;

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router
  ) {}

  complexPassword =
    "(?=^.{6,10}$)(?=.*d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*s).*$";

  // We are using this as an alternative way to the way we use in login.component.ts
  registerForm = this.fb.group({
    displayName: ['', Validators.required], // first element is initial value
    email: [
      '',
      [Validators.required, Validators.email],
      [this.validateEmailNotTaken()],
    ],
    password: [
      '',
      [Validators.required, Validators.pattern(this.complexPassword)],
    ],
  });

  onSubmit() {
    this.accountService.register(this.registerForm.value).subscribe({
      next: () => this.router.navigateByUrl('/shop'),
      error: (error) => (this.errors = error.errors), // check our error interceptor where we throw this type of error
    });
  }

  validateEmailNotTaken(): AsyncValidatorFn {
    return (control: AbstractControl) => {
      return control.valueChanges.pipe(
        debounceTime(1000), // wait a second after the user typed a character before calling the API
        take(1), // only take the last value
        switchMap(() => {
          // switchMap returns an observable from the function we provide here which can then be used in our registerForm validator above
          return this.accountService.checkEmailExists(control.value).pipe(
            map((result) => (result ? { emailExists: true } : null)),
            finalize(() => control.markAsTouched()) // This way we'll be notified immediately that the email is taken
          );
        })
      );
    };
  }
}
