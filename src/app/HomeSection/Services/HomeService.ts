import { Injectable } from '@angular/core';
import { AppConstants } from '../../Common/AppConstants';
import { BaseService } from '../../Common/Services/BaseService';
import { NGXLogger } from 'ngx-logger';
import {Http , Response , RequestOptionsArgs} from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HomeService  extends BaseService  {

  constructor(_logService: NGXLogger , _httpService: Http) {
      super(_logService, _httpService);
  }

  GetTestValuesList(): Promise<any> {
    return this.httpService.get(AppConstants.AuthAPIUrl + '/api/TestApi').map(response => {
      return response.json() || {success: false, message: 'No response from server'};
    }).catch((error: Response | any) => {
      return Observable.throw(error.json());
    }).toPromise();
  }
}
