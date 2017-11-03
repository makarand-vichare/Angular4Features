import { UserVM } from './../../AdminSection/ViewModels/UserVM';
import { HomeService } from './../Services/HomeService';
import { AppConstants } from './../../Common/AppConstants';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseComponent } from '../../Common/Components/BaseComponent';
import { Router } from '@angular/router';
import { NGXLogger } from 'ngx-logger';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './../Views/HomeComponent.html',
  styleUrls: ['./../Views/HomeComponent.scss'],
  providers: [HomeService, NGXLogger]
})

export class HomeComponent extends BaseComponent implements OnInit {
  constructor(_routerService: Router, _logService: NGXLogger, private homeService: HomeService,
    _toastr: ToastsManager, _vRef: ViewContainerRef) {
    super(_routerService, _logService, _toastr, _vRef);
  }

  users: Array<UserVM>;

  ngOnInit() {
    const self = this;
    self.users = new Array<UserVM>();
  }


  CheckApiUrl = () => {
    const self = this;
    self.StartProcess();

    self.homeService.GetTestValuesList()
      .then(function (response: any) {
        self.users = response.result;
        self.ProcessInfo.Message = 'suceeded';
      })
      .catch(function (error: any) {
        self.ProcessInfo.Message = error.data;
      });
  }
}
