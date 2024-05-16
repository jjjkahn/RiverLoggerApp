import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, LoginComponent] // Importing the standalone component
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('form should be invalid initially', () => {
    expect(component.loginForm.valid).toBeFalsy();
  });

  [
    {
      email: "",
      requiredError: true,
      emailError: undefined
    },
    {
      email: "test",
      requiredError: undefined,
      emailError: true
    },
    {
      email: "test@example.com",
      requiredError: undefined,
      emailError: undefined
    }
  ].forEach((emailCase) => {
    it(`When email is ${emailCase.email}, required error should be ${emailCase.requiredError} and email error should be ${emailCase.emailError}`, () => {
      let email = component.loginForm.controls['email'];
      email.setValue(emailCase.email);
      let errors = email.errors || {};
      fixture.detectChanges();

      expect(errors['required']).toBe(emailCase.requiredError);
      expect(errors['email']).toBe(emailCase.emailError);
    });
  });

  [
    {
      password: "",
      requiredError: true,
      passwordError: undefined
    },
    {
      password: "short",
      requiredError: undefined,
      passwordError: true
    },
    {
      password: "validPassword123",
      requiredError: undefined,
      passwordError: undefined
    }
  ].forEach((passwordCase) => {
    it(`When password is ${passwordCase.password}, required error should be ${passwordCase.requiredError} and min length error should be ${passwordCase.passwordError}`, () => {
      let password = component.loginForm.controls['password'];
      password.setValue(passwordCase.password);
      let errors = password.errors || {};
      fixture.detectChanges();

      expect(errors['required']).toBe(passwordCase.requiredError);
    });
  });
});
