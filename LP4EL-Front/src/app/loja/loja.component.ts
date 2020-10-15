import { Component, OnInit } from '@angular/core';
import { DadosUsuarioService } from '../_services/dadosUsuario.service';
import { ProdutoService } from '../_services/produto.service';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.scss']
})
export class LojaComponent implements OnInit {

  pontos;
  itensLista = [];

  constructor(private produtoService: ProdutoService, private dadosUsuario: DadosUsuarioService) { }

  ngOnInit() {
    this.puxarProdutos();
    this.dadosUsuario.getDados().subscribe((resp: any) => {this.pontos = resp.pontos});
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

  comprarProduto(pontos){
    if(this.pontos < pontos){
      alert("Seu saldo é insuficiente!");
    }else{
      alert("Você comprou o item!");
    }
      
  }

}
