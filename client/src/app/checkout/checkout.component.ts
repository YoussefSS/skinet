import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../account/account.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss'],
})
export class CheckoutComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.getAddressFormValues();
  }

  // A parent form with nested child forms
  checkoutForm = this.fb.group({
    addressForm: this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zipCode: ['', Validators.required],
    }),
    deliveryForm: this.fb.group({
      deliveryMethod: ['', Validators.required],
    }),
    paymentForm: this.fb.group({
      // We'll look at taking CC payments later with stripe
      nameOnCard: ['', Validators.required],
    }),
  });

  getAddressFormValues() {
    this.accountService.getUserAddress().subscribe({
      next: (address) => {
        if (address) {
          this.checkoutForm.get('addressForm')?.patchValue(address);
        }
      },
    });
  }
}
