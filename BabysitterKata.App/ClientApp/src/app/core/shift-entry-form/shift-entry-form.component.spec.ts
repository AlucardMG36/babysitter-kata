import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { BabysitterShiftService } from '../../shared/services/babysitter/babysitter-shift.service';
import { ConfigurationService } from '../../shared/services/configuration/configuration.service';
import { FamilySelectorComponent } from '../family-selector/family-selector.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RestService } from '../../shared/services/rest/rest.service';
import { ShiftEntryFormComponent } from './shift-entry-form.component';
import { ShiftTimePickerComponent } from '../shift-time-picker/shift-time-picker.component';

describe('ShiftEntryFormComponent', () => {
  let component: ShiftEntryFormComponent;
  let fixture: ComponentFixture<ShiftEntryFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        FormsModule,
        NgbModule
      ],
      declarations: [
        FamilySelectorComponent,
        ShiftEntryFormComponent,
        ShiftTimePickerComponent
       ],
      providers: [
        BabysitterShiftService,
        ConfigurationService,
        HttpClient,
        HttpHandler,
        RestService
      ]
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
