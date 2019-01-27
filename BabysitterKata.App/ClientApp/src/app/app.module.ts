import { AppComponent } from './app.component';
import { Bootstrapper } from './bootstrapper';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './core/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { NavMenuComponent } from './core/nav-menu/nav-menu.component';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { ShiftEntryFormComponent } from './core/shift-entry-form/shift-entry-form.component';
import { ShiftTimePickerComponent } from './core/shift-time-picker/shift-time-picker.component';
import { FamilySelectorComponent } from './core/family-selector/family-selector.component';

export function runBootstrapper(bootstrapper: Bootstrapper): Function {
  return () => bootstrapper.run();
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    ShiftEntryFormComponent,
    ShiftTimePickerComponent,
    FamilySelectorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    HttpClientModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [
    Bootstrapper,
    {
      deps: [
        Bootstrapper
      ],
      multi: true,
      provide: APP_INITIALIZER,
      useFactory: runBootstrapper
    }
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
