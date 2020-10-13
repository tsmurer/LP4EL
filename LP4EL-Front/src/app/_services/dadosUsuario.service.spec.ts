/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DadosUsuarioService } from './dadosUsuario.service';

describe('Service: DadosUsuario', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DadosUsuarioService]
    });
  });

  it('should ...', inject([DadosUsuarioService], (service: DadosUsuarioService) => {
    expect(service).toBeTruthy();
  }));
});
