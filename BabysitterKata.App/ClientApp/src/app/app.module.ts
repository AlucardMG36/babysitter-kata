import { AppComponent } from './app.component';
import { Bootstrapper } from './bootstrapper';
import { BrowserModule } from '@angular/platform-browser';
import { CoreModule } from './core/core.module';
import { FormsModule } from '@angular/forms';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RoutingModule } from './routing.module';
import { SharedModule } from './shared/shared.module';

export function runBootstrapper(bootstrapper: Bootstrapper): Function {
  return () => bootstrapper.run();
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    CoreModule,
    FormsModule,
    NgbModule,
    RoutingModule,
    SharedModule
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
