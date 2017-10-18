import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyspotsComponent } from './myspots.component';

describe('MyspotsComponent', () => {
  let component: MyspotsComponent;
  let fixture: ComponentFixture<MyspotsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyspotsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyspotsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
