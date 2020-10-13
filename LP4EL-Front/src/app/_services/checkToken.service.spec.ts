/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CheckTokenService } from './checkToken.service';

describe('Service: CheckToken', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CheckTokenService]
    });
  });

  it('should ...', inject([CheckTokenService], (service: CheckTokenService) => {
    expect(service).toBeTruthy();
  }));
});
