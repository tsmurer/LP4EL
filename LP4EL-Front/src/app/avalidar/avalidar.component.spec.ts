/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AvalidarComponent } from './avalidar.component';

describe('AvalidarComponent', () => {
  let component: AvalidarComponent;
  let fixture: ComponentFixture<AvalidarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AvalidarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AvalidarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
