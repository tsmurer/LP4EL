import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class CheckTokenService {

constructor() { }

  getId() {
    return jwt_decode(localStorage.getItem('token')).nameid;
  }

  getTipo() {
    return jwt_decode(localStorage.getItem('token')).actort;
  }
}
