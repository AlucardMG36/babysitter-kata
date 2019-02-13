import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { BabysitterShiftService } from '../../shared/services/babysitter/babysitter-shift.service';
import { ConfigurationService } from '../../shared/services/configuration/configuration.service';
import { HomeComponent } from './home.component';
import { HomeService } from '../../shared/services/home/home.service';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { FamilySelectorComponent } from '../family-selector/family-selector.component';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { RestService } from '../../shared/services/rest/rest.service';
import { ShiftEntryFormComponent } from '../shift-entry-form/shift-entry-form.component';
import { ShiftTimePickerComponent } from '../shift-time-picker/shift-time-picker.component';

describe('HomeComponent', () => {
    let component: HomeComponent;
    let fixture: ComponentFixture<HomeComponent>;
    let service: ConfigurationService;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                FormsModule,
                NgbModule
            ],
            declarations: [
                FamilySelectorComponent,
                HomeComponent,
                NavMenuComponent,
                ShiftEntryFormComponent,
                ShiftTimePickerComponent
            ],
            providers: [
                BabysitterShiftService,
                ConfigurationService,
                HomeService,
                HttpClient,
                HttpHandler,
                RestService
            ]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        service = TestBed.get(ConfigurationService);
        fixture = TestBed.createComponent(HomeComponent);
        component = fixture.componentInstance;

        service.Load().then(() => {
        fixture.detectChanges();
        });
    });

    it('should created', () => {
        expect(component).toBeTruthy();
    });
});
