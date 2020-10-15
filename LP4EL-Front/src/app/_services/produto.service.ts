import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CheckTokenService } from './checkToken.service';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

baseUrl = 'http://localhost:5000/produto';

constructor(private httpClient: HttpClient, private checkToken: CheckTokenService) { }

  getProdutos() {
    return this.httpClient.get(this.baseUrl + '/lista');
  }

  resgatarProduto(idProduto) { //idproduto, iduser
    const idUser = this.checkToken.getId();
    return this.httpClient.post(this.baseUrl + 'Resgate' + '/' + idProduto + '/' + idUser , idProduto, idUser);
  }



}
