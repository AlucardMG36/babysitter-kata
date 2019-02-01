import {HttpClient, HttpHandler } from '@angular/common/http';
import { RestService } from './rest.service';
import { TestBed, inject } from '@angular/core/testing';


describe('RestService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        HttpClient,
        HttpHandler,
        RestService
      ]
    });
  });

  it('should be created', inject([RestService], (service: RestService) => {
    expect(service).toBeTruthy();
  }));
});
