import { Component, OnInit } from '@angular/core';
import { HospitalService } from '../_services/hospital.service';

@Component({
  selector: 'app-hemocentros',
  templateUrl: './hemocentros.component.html',
  styleUrls: ['./hemocentros.component.scss']
})


export class HemocentrosComponent implements OnInit {

  hemocentrosLista = [];

  constructor(public hospitalService: HospitalService) {

  }


  ngOnInit() {
    this.puxarNomes();
  }

  puxarNomes() {
    this.hospitalService.getHemocentros().subscribe((resp: any) => {
      //console.log(resp);
      for(let i = 0; i < resp.length; i++){
        //console.log(resp[i]);
        this.hemocentrosLista.push(resp[i].name);
      }
    });
  }

}
