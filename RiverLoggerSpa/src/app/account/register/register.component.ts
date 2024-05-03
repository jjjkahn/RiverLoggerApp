import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  imports: [ReactiveFormsModule],
})
export class RegisterComponent {
  registerForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    console.log('On submit register');
    this.authService
      .register(
        this.registerForm.value.name!,
        this.registerForm.value.email!,
        this.registerForm.value.password!
      )
      .subscribe(
        () => {
          // Rediriger l'utilisateur vers une autre page après l'inscription réussie
          //this.router.navigate(['/login']);
          console.log("you Are registered in");
        },
        (error) => {
          console.log("Erreur d'inscription:", error);
          // Gérer l'affichage d'un message d'erreur à l'utilisateur
        }
      );
  }
}
