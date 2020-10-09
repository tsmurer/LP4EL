import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HospitalService {
  baseUrl = 'http://localhost:5000/hospital/';

  constructor(private httpClient: HttpClient) { }

  getHemocentros(){
    return this.httpClient.get(this.baseUrl);
  }

}
