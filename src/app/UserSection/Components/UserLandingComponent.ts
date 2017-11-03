import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseComponent } from '../../Common/Components/BaseComponent';
import { Router } from '@angular/router';
import { NGXLogger } from 'ngx-logger';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
  selector: 'app-user-landing',
  templateUrl: './../Views/UserLandingComponent.html',
  styleUrls: ['./../Views/UserLandingComponent.scss']
})

export class UserLandingComponent extends BaseComponent implements OnInit {
  constructor(_routerService: Router, _logService: NGXLogger,
    _toastr: ToastsManager, _vRef: ViewContainerRef) {
    super(_routerService, _logService, _toastr, _vRef);
  }

  title = 'Welcome to User Section';
  ngOnInit() {
    const self = this;
  }

}
