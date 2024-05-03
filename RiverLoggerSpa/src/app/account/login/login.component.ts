import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  imports: [ReactiveFormsModule],
})
export class LoginComponent {
  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    this.authService
      .login(this.loginForm.value.email!, this.loginForm.value.password!)
      .subscribe(
        () => {
          // Rediriger l'utilisateur vers une autre page après la connexion réussie
          //this.router.navigate(['/dashboard']);

          console.log('you Are logged in in');
        },
        (error) => {
          console.log('Erreur de connexion:', error);
          // Gérer l'affichage d'un message d'erreur à l'utilisateur
        }
      );
  }
}
