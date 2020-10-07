/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { HemocentrosComponent } from './hemocentros.component';

describe('HemocentrosComponent', () => {
  let component: HemocentrosComponent;
  let fixture: ComponentFixture<HemocentrosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HemocentrosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HemocentrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
