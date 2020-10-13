import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DoacaoService {

  baseUrl = 'http://localhost:5000/api/doacao/';

  constructor(private http: HttpClient) { }

  cadastrarDoacao(model: any) {
    return this.http.post(this.baseUrl + 'cadastro/', model);
  }
}
