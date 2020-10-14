import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DadosUsuarioService {
  baseUrl = 'http://localhost:5000/user';

  constructor(private httpClient: HttpClient) { }

}
