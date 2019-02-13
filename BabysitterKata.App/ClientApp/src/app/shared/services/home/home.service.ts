import { ConfigurationService } from '../configuration/configuration.service';
import { HomeViewModel } from '../../models/homeViewModel';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RestService } from '../rest/rest.service';
import { SharedModule } from '../../shared.module';

@Injectable({
  providedIn: SharedModule
})
export class HomeService {

  constructor(private _config: ConfigurationService, private _rest: RestService) { }

  getViewModel(): Observable<HomeViewModel> {
    const url = this._config.currentConfiguration.apiPath;

    return this._rest.get(url);
  }
}
