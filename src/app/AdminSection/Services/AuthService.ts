import { LoginVM } from './../ViewModels/LoginVM';
import { AuthenticationVM } from './../ViewModels/AuthenticationVM';
import { Injectable } from '@angular/core';
import { Http, RequestOptionsArgs } from '@angular/http';
 import { NGXLogger } from 'ngx-logger';
import { BaseService } from '../../Common/Services/BaseService';
import { LocalStorageService, SessionStorageService, LocalStorage, SessionStorage } from 'angular-web-storage';
import { AppConstants } from '../../Common/AppConstants';
import { AuthorizationVM } from '../ViewModels/AuthorizationVM';
import { Observable } from 'rxjs/Observable';
import { SignUpVM } from '../ViewModels/SignupVM';
import { plainToClass } from 'class-transformer';

@Injectable()
export class AuthService extends BaseService {

  constructor(_logService: NGXLogger, _httpService: Http, private localStorageService: LocalStorageService) {
    super(_logService, _httpService);
  }

  isAuth = false;
  authVM: AuthenticationVM = {
    IsAuth: this.isAuth,
    UserName: '',
    Id: 0,
    Role: ''
  };

  SignUp = (registration: SignUpVM): Observable<any> => {
    const self = this;
    const  config = {
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type, x-xsrf-token'
  } as RequestOptionsArgs;

  return self.httpService.post( AppConstants.AuthAPIUrl + '/api/Account/Register', registration, config )
  .map((response) => {
    return response.json() || { success: false, message: 'No response from server' };
  })
  .catch((error: Response | any) => {
    return Observable.throw(error.json());
  });
  }

  Login = (loginData:  LoginVM): Promise<any> => {
    const self = this;
    const data = 'grant_type=password&username=' + loginData.UserName + '&password=' + loginData.Password;
    const  config = {
          'Accept': 'application/json',
          'Access-Control-Allow-Headers': 'Content-Type, x-xsrf-token'
      } as RequestOptionsArgs;

      return self.httpService.post(AppConstants.AuthAPIUrl + '/token', data, config).map(response => {
        const result = response.json();
        if (result != null) {
          self.localStorageService.set('authorizationData',
          {
            Token: result.access_token,
            UserName: loginData.UserName,
            Id: result.id,
            Role: result.role
          } as AuthorizationVM);

          self.authVM.IsAuth = !self.isAuth;
          self.authVM.UserName = loginData.UserName;
          self.authVM.Id = result.id;
          self.authVM.Role = result.role;

         return result;
        }
       return {success: false, message: 'No response from server'};
     }).catch((error: Response | any) => {
       return Observable.throw(error.json());
     }).toPromise();
  }

  LogOut = () => {
    const self = this;
    self.localStorageService.clear();
    self.authVM.IsAuth = self.isAuth;
    self.authVM.Id = 0;
    self.authVM.UserName = '';
    self.authVM.Role = '';
  }

  GetAuthData = (): AuthenticationVM => {
    const self = this;
    const authData = self.localStorageService.get('authorizationData') as AuthorizationVM;
    if (authData != null) {
      self.authVM.IsAuth = !self.isAuth;
      self.authVM.UserName = authData.UserName;
      self.authVM.Id = authData.Id;
      self.authVM.Role = authData.Role;
    }
    return self.authVM;
  }

  GetAntiForgeryToken = (): Promise<any> => {
    const self = this;

    return self.httpService.get(AppConstants.AuthAPIUrl + '/api/Antiforgerytoken/GetAntiForgeryToken')
    .map(response => {
      const result = response.json();
       return result || {success: false, message: 'No response from server'};
   }).catch((error: Response | any) => {
     return Observable.throw(error.json());
   }).toPromise();
  }
}
