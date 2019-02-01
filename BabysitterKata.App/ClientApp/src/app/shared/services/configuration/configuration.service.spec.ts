import { ConfigurationService } from './configuration.service';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { of } from 'rxjs/internal/observable/of';
import { RestService } from '../rest/rest.service';
import { TestBed, inject } from '@angular/core/testing';
import { throwError } from 'rxjs';

describe('ConfigurationService', () => {
  let restServiceSpy: jasmine.SpyObj<RestService>;
  let service: ConfigurationService;

  beforeEach(() => {
    TestBed.configureTestingModule({
    providers: [
      ConfigurationService,
      HttpClient,
      HttpHandler,
      RestService
    ]
  });
  restServiceSpy = jasmine.createSpyObj('RestService', ['get']);
  service = new ConfigurationService(restServiceSpy);
});

  it('should be created', inject([ConfigurationService], (cservice: ConfigurationService) => {
    expect(cservice).toBeTruthy();
    }));

  it('#Load should return stubbed value from mocked RestService', () => {
    const fakeObj = {apiPath: 'localhost:25000'};
    restServiceSpy.get.and.returnValue(of(fakeObj));

    service.Load().then(() => {
      expect(service.currentConfiguration.apiPath).toEqual(fakeObj.apiPath, 'expected environment');
    });
    expect(restServiceSpy.get.calls.count()).toBe(1, 'spy method was called once');
  });

  it('#Load should return undefined currentConfiguration when the service returns a 404', () => {

    restServiceSpy.get.and.returnValue(throwError({status: 404}));

    service.Load().then( () => {
      fail('expected an error, not environment'),
      expect(service.currentConfiguration).toBeUndefined();
    });
    expect(restServiceSpy.get.calls.count()).toBe(1, 'spy method was called once');
  });

});
