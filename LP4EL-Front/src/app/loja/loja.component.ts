import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../_services/produto.service';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.scss']
})
export class LojaComponent implements OnInit {

  itensLista = [];

  constructor(private produtoService: ProdutoService) { }

  ngOnInit() {
    this.puxarProdutos();
  }

  puxarProdutos() {
    this.produtoService.getProdutos().subscribe((resp: any) => {
      console.log(resp.toString());
      for(let i = 0; i < resp.length; i++){
        //console.log(resp[i]);
        this.itensLista.push(resp[i]);
      }
    });
  }

}
