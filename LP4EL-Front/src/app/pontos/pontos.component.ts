import { Component, OnInit } from '@angular/core';
import { CheckTokenService } from '../_services/checkToken.service';
import { DadosUsuarioService } from '../_services/dadosUsuario.service';

@Component({
  selector: 'app-pontos',
  templateUrl: './pontos.component.html',
  styleUrls: ['./pontos.component.scss']
})
export class PontosComponent implements OnInit {

  nome;
  pontos;
  
  constructor(private dadosUsuario: DadosUsuarioService) { 

  }

  ngOnInit() {
   this.dadosUsuario.getDados().subscribe((resp: any) => {this.nome = resp.name, this.pontos = resp.pontos});
  }
        

}
