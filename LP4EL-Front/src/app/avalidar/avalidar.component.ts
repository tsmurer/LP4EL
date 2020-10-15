import { Component, OnInit } from '@angular/core';
import { DoacaoService } from '../_services/doacao.service';

@Component({
  selector: 'app-avalidar',
  templateUrl: './avalidar.component.html',
  styleUrls: ['./avalidar.component.scss']
})
export class AvalidarComponent implements OnInit {

  constructor(private doacaoService: DoacaoService) { }

  doacoes: any = [];

  ngOnInit() {
    this.puxarDoacoes();
  }

  puxarDoacoes() {
    this.doacaoService.puxarDoacoesHospital()
      .subscribe(
        (resp: any) => {
          console.log(resp);
          this.doacoes = resp;
        }
        )
  }

  validarDoacao(doacao) {
    if (doacao.realizado === false) {
      this.doacaoService.validarDoacao(doacao.id).subscribe();
      this.puxarDoacoes();
    }
  }

}
