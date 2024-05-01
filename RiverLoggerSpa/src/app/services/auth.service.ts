import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    // Faites un appel HTTP pour vous connecter
    // Vous pouvez remplacer cet exemple par votre propre logique d'authentification
    return this.http.post<any>('/api/login', { email, password });
  }

  register(name: string, email: string, password: string): Observable<any> {
    // Faites un appel HTTP pour vous inscrire
    // Vous pouvez remplacer cet exemple par votre propre logique d'inscription
    return this.http.post<any>('/api/register', { name, email, password });
  }
}
