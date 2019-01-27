import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftEntryFormComponent } from './shift-entry-form.component';

describe('ShiftEntryFormComponent', () => {
  let component: ShiftEntryFormComponent;
  let fixture: ComponentFixture<ShiftEntryFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShiftEntryFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShiftEntryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
