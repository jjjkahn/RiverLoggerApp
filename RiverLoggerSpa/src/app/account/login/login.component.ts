import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { User } from '../../models/user';

@Component({
  standalone: true,
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  imports: [
    ReactiveFormsModule,
    CommonModule
  ],
})
export class LoginComponent implements OnInit {
  user: User;
  loginForm: FormGroup;
  submitted = false;



  constructor(private formBuilder: FormBuilder) {
    this.user = {
      name: '',
      lastName: '',
      password: '',
      email: ''
    }
    this.loginForm = new FormGroup({
      email: new FormControl(this.user.email, [Validators.required, Validators.email]),
      password: new FormControl(this.user.password, [Validators.required])
    })
  }

  ngOnInit() {
    this.initLoginForm();
  }

  get f(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }

  initLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  onSubmit() {
    this.submitted = true;

    if (this.loginForm.invalid) {
      return;
    }

    console.log(JSON.stringify(this.loginForm.value, null, 2));
  }
}


