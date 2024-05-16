import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './account/login/login.component';

@Component({
  imports: [
    RouterOutlet,
    LoginComponent
  ],
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})

export class AppComponent {
  title = 'RiverLoggerSpa';
}
