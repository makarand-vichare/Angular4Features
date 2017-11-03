import { Injectable } from '@angular/core';
import { AppConstants } from '../../Common/AppConstants';
import { BaseService } from '../../Common/Services/BaseService';
import { NGXLogger } from 'ngx-logger';
import {Http , Response , RequestOptionsArgs} from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class StarShipService  extends BaseService  {

  constructor(_logService: NGXLogger , _httpService: Http) {
      super(_logService, _httpService);
  }

  GetByPage = (page: number): Promise<any> => {
      const  config = {
              'Accept': 'application/json', 'Access-Control-Allow-Headers': 'Content-Type, x-xsrf-token',
              params: {page: page}
      } as RequestOptionsArgs;

      return this.httpService.get(AppConstants.SWAPIUrl + '/starships/', config).map(response => {
        return response.json() || {success: false, message: 'No response from server'};
      }).catch((error: Response | any) => {
        return Observable.throw(error.json());
      }).toPromise();
  }

  GetAll = (): Promise<any> => {
      const  config = {
          'Accept': 'application/json', 'Access-Control-Allow-Headers': 'Content-Type, x-xsrf-token'
      } as RequestOptionsArgs;

      return this.httpService.get(AppConstants.SWAPIUrl + '/starships/', config).map(response => {
        return response.json() || {success: false, message: 'No response from server'};
      }).catch((error: Response | any) => {
        return Observable.throw(error.json());
      }).toPromise();
  }
}
