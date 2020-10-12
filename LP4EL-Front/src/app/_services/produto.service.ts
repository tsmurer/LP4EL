import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

baseUrl = 'http://localhost:5000/produto/';

constructor(private httpClient: HttpClient) { }

getProdutos() {
  return this.httpClient.get(this.baseUrl + 'lista');
}

}
