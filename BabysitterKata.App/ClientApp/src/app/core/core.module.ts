import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FamilySelectorComponent } from './family-selector/family-selector.component';
import { HomeComponent } from './home/home.component';
import { ShiftEntryFormComponent } from './shift-entry-form/shift-entry-form.component';
import { ShiftTimePickerComponent } from './shift-time-picker/shift-time-picker.component';
@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        NgbModule
    ],
    declarations: [
        FamilySelectorComponent,
        HomeComponent,
        NavMenuComponent,
        ShiftEntryFormComponent,
        ShiftTimePickerComponent
    ]
})
export class CoreModule {}
