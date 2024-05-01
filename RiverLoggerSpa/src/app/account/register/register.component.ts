import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerForm = {
    name: '',
    email: '',
    password: ''
  };

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    this.authService.register(this.registerForm.name, this.registerForm.email, this.registerForm.password)
      .subscribe(
        () => {
          // Rediriger l'utilisateur vers une autre page après l'inscription réussie
          this.router.navigate(['/login']);
        },
        error => {
          console.log('Erreur d\'inscription:', error);
          // Gérer l'affichage d'un message d'erreur à l'utilisateur
        }
      );
  }
}
