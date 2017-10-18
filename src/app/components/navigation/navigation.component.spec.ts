/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NavigationComponent } from './navigation.component';

describe('NavigationComponent', () => {
  let component: NavigationComponent;
  let fixture: ComponentFixture<NavigationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavigationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it(`should have as title 'Spot 2 Share'`, async(() => {
    let fixture = TestBed.createComponent(NavigationComponent);
    let app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Spot 2 Share');
  }));

  it('should render title', async(() => {
    let fixture = TestBed.createComponent(NavigationComponent);
    fixture.detectChanges();
    let compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('.navbar-brand').textContent).toContain('Spot 2 Share');
  }));

  it('should select active Home menu item', async(() => {
    let fixture = TestBed.createComponent(NavigationComponent);
    fixture.detectChanges();
    let compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('.active').textContent).toContain('Home');
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
