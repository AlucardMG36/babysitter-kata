import { ConfigurationService } from '../configuration/configuration.service';
import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RestService } from '../rest/rest.service';
import { SharedModule } from '../../shared.module';
import { BabysitterViewModel } from '../../models/babysitterViewModel';

@Injectable({
  providedIn: SharedModule
})
export class BabysitterShiftService {

  constructor(
    private _config: ConfigurationService,
    private _rest: RestService
  ) { }

  getPayforShift(url: string): Observable<BabysitterViewModel> {
    const shiftPayPath = this._config.currentConfiguration.apiPath + url;

    return this._rest.get(shiftPayPath);
  }

}
