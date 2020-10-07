/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PontosComponent } from './pontos.component';

describe('PontosComponent', () => {
  let component: PontosComponent;
  let fixture: ComponentFixture<PontosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PontosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PontosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
