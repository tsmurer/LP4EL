import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CheckTokenService } from './checkToken.service';

@Injectable({
  providedIn: 'root'
})
export class DoacaoService {

  baseUrl = 'http://localhost:5000/api/doacao/';

  constructor(private http: HttpClient, private checkToken: CheckTokenService) { }

  cadastrarDoacao(model: any) {
    return this.http.post(this.baseUrl + 'cadastro/', model);
  }

  puxarDoacoesHospital() {
    return this.http.get(
      this.baseUrl + 'hospitaldoacao/' + this.checkToken.getId());
  }
}
