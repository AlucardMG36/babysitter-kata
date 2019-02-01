import { Configuration } from '../../models/configuration';
import { Injectable } from '@angular/core';
import { RestService } from '../rest/rest.service';
import { SharedModule } from '../../shared.module';

@Injectable({
  providedIn: SharedModule
})
export class ConfigurationService {
  currentConfiguration: Configuration;

  constructor(private _rest: RestService) { }

  public Load() {
    return new Promise((resolve, reject) => {
      this._rest.get<Configuration>('../../assets/app.settings.json').subscribe(
        config => {
          this.currentConfiguration = config;
          resolve(true);
        },
        e => {
          console.error(e);
        },
        () => {
          console.log('Completed Configuration Service');
        }
      );
    });
  }
}
