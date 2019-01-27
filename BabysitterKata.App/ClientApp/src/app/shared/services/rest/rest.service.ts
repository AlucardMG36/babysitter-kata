import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class RestService {

  constructor(private _http: HttpClient) { }

  get<T>(url: string): Observable<T> {
    return this._http.get<T>(url, httpOptions);
  }

  post<T>(url: string, body: any) {
    return this._http.post<T>(url, body, httpOptions);
  }
}
