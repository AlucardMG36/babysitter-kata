import { BabysitterShiftService } from './babysitter-shift.service';
import { ConfigurationService } from '../configuration/configuration.service';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { of } from 'rxjs/internal/observable/of';
import { RestService } from '../rest/rest.service';
import { TestBed, inject } from '@angular/core/testing';
import { Observable } from 'rxjs';

describe('BabysitterShiftService', () => {
  let restServiceSpy: jasmine.SpyObj<RestService>;
  let configService: ConfigurationService;
  let service: BabysitterShiftService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        BabysitterShiftService,
        ConfigurationService,
        HttpClient,
        HttpHandler,
        RestService
      ]
    });

    restServiceSpy = jasmine.createSpyObj('RestService', ['get', 'post']);
    configService = new ConfigurationService(restServiceSpy);
    service = new BabysitterShiftService(configService, restServiceSpy);
  });

  it('should be created', inject([BabysitterShiftService], (bservice: BabysitterShiftService) => {
    expect(bservice).toBeTruthy();
  }));

  const fakeObj = {
    'pay': 145
  };

  it('#getPayForShift should return stubbed value from mocked RestService', () => {

    restServiceSpy.get.and.returnValue(of(fakeObj));

    configService.Load().then(() => {
      service.getPayforShift('get').subscribe(
        pay => expect(pay).toBeTruthy(),
        fail
      );
      expect(restServiceSpy.get).toHaveBeenCalledTimes(2);
    });
  });

  it('#workShift should return status of 201/Ok when post is successful', () => {
    restServiceSpy.post.and.returnValue(new Observable(observer => {
      observer.next({satus: 200, ok: true});
    }));

    configService.Load().then(() => {
      service.workShift('whatever', fakeObj).subscribe(
        result => {
          expect(result.status).toBe(200);
          expect(result.ok).toBeTruthy();
        }
      );
      expect(restServiceSpy.post).toHaveBeenCalledTimes(2);
    });
  });
});
