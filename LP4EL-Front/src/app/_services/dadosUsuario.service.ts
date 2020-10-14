import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CheckTokenService } from './checkToken.service';

@Injectable({
  providedIn: 'root'
})
export class DadosUsuarioService {

constructor(private httpClient: HttpClient, private checkToken: CheckTokenService) { }

baseUrl = 'http://localhost:5000/user/';

getDados() {
  return this.httpClient.get(this.baseUrl + this.checkToken.getId());
}

}
