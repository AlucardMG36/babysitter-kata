import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SharedModule } from '../../shared.module';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: SharedModule
})
export class RestService {

  constructor(private _http: HttpClient) { }

  get<T>(url): Observable<T> {
    return this._http.get<T>(url, httpOptions);
  }
}
