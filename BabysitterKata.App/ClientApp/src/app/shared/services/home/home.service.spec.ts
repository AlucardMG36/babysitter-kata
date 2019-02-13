import { ConfigurationService } from '../configuration/configuration.service';
import { HomeService } from './home.service';
import { HttpClient } from 'selenium-webdriver/http';
import { HttpHandler } from '@angular/common/http';
import { inject, TestBed } from '@angular/core/testing';
import { RestService } from '../rest/rest.service';
import { throwError, of } from 'rxjs';
import { HomeViewModel } from '../../models/homeViewModel';

describe('HomeService', () => {
  let restServiceSpy: jasmine.SpyObj<RestService>;
  let configService: ConfigurationService;
  let service: HomeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        ConfigurationService,
        HomeService,
        HttpClient,
        HttpHandler,
        RestService
      ]
    });

    restServiceSpy = jasmine.createSpyObj('RestService', ['get']);
    configService = new ConfigurationService(restServiceSpy);
    service = new HomeService(configService, restServiceSpy);
  });

  xit('should be created', inject([HomeService], (hService: HomeService) => {
    expect(hService).toBeTruthy();
  }));

  it('#getViewModel should return error when the service returns a 404', () => {
    restServiceSpy.get.and.returnValue(throwError({ status: 404 }));

    configService.Load().then(() => {
      service.getViewModel().subscribe(
        homeViewModel => fail('expected HomeViewModel, not found'),
        error => expect(error).toBe(404)
      );
      expect(restServiceSpy.get).toHaveBeenCalledTimes(1);
    });
  });

  it('#getViewModel should return the proper link from mocked RestService', () => {

    const testLink = { name: 'test', href: '/' };
    restServiceSpy.get.and.returnValue(of(testLink));

    configService.Load().then(() => {
      service.getViewModel().subscribe(
        homeviewModel => {
          expect(homeviewModel).toBeTruthy();

          const resolvehomeviewModel = new HomeViewModel(homeviewModel.links);

          expect(resolvehomeviewModel.links).toBeDefined();
        }
      );
    expect(restServiceSpy.get).toHaveBeenCalledTimes(2);
      });
});
});
