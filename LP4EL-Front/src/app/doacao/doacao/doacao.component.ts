import { Component, OnInit } from '@angular/core';
import { DoacaoService } from 'src/app/_services/doacao.service';

@Component({
  selector: 'app-doacao',
  templateUrl: './doacao.component.html',
  styleUrls: ['./doacao.component.scss']
})
export class DoacaoComponent implements OnInit {

  model: any = {};
  constructor(private doacaoService: DoacaoService) { }

  ngOnInit() {
  }

  cadastrarDoacao(){
    
  }

}
