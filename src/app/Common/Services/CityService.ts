import { Injectable } from '@angular/core';
import { AppConstants } from './../../Common/AppConstants';
import { BaseService } from './../../Common/Services/BaseService';
import { NGXLogger } from 'ngx-logger';
import { Http, Response, RequestOptionsArgs } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { plainToClass } from 'class-transformer';

@Injectable()
export class CityService extends BaseService {

  constructor(_logService: NGXLogger, _httpService: Http) {
    super(_logService, _httpService);
  }


  GetCities = (countryId: number): Observable<any> => {
    const self = this;
    const config = {
      'Accept': 'application/json', 'Access-Control-Allow-Headers': 'Content-Type, x-xsrf-token'
    } as RequestOptionsArgs;

    return self.httpService.get(AppConstants.AuthAPIUrl + '/api/city/GetCities', config)
      .map((response) => {
        return response.json() || { success: false, message: 'No response from server' };
      })
      .map((data: any) => {
        return data;
      }).catch((error: Response | any) => {
        return Observable.throw(error.json());
      });
  }
}
