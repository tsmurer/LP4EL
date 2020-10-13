import { Component, OnInit } from '@angular/core';
import { CheckTokenService } from 'src/app/_services/checkToken.service';
import { DoacaoService } from 'src/app/_services/doacao.service';

@Component({
  selector: 'app-doacao',
  templateUrl: './doacao.component.html',
  styleUrls: ['./doacao.component.scss']
})
export class DoacaoComponent implements OnInit {

  model: any = {};
  constructor(private doacaoService: DoacaoService, private checkToken: CheckTokenService) { }

  ngOnInit() {
  }

  cadastrarDoacao(){
    this.model.IdHospital = this.checkToken.getId();
    this.model.Horario = new Date().toJSON("yyyy/MM/dd HH:mm");
    this.model.Realizado = true;
    this.doacaoService.cadastrarDoacao(this.model).subscribe(() => {
      alert('Doação cadastrada');
      //const loginObject = {name: this.model.name, password: this.model.password}

    }, error => {
      console.log(error);
      alert('Erro no cadastro da doação');
      console.log(this.model);
    });
  }

}
