import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftTimePickerComponent } from './shift-time-picker.component';

describe('ShiftTimePickerComponent', () => {
  let component: ShiftTimePickerComponent;
  let fixture: ComponentFixture<ShiftTimePickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShiftTimePickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShiftTimePickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
