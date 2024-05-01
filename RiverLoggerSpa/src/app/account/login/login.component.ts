import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm = {
    email: '',
    password: ''
  };

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    this.authService.login(this.loginForm.email, this.loginForm.password)
      .subscribe(
        () => {
          // Rediriger l'utilisateur vers une autre page après la connexion réussie
          this.router.navigate(['/dashboard']);
        },
        error => {
          console.log('Erreur de connexion:', error);
          // Gérer l'affichage d'un message d'erreur à l'utilisateur
        }
      );
  }
}
