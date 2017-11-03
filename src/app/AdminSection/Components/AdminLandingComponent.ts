import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseComponent } from '../../Common/Components/BaseComponent';
import { Router } from '@angular/router';
 import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { NGXLogger } from 'ngx-logger';

@Component({
  selector: 'app-admin-landing',
  templateUrl: './../Views/AdminLandingComponent.html',
  styleUrls: ['./../Views/AdminLandingComponent.scss']
})

export class AdminLandingComponent extends BaseComponent implements OnInit {
  constructor(_routerService: Router, _logService: NGXLogger,
    _toastr: ToastsManager, _vRef: ViewContainerRef) {
    super(_routerService, _logService, _toastr, _vRef);
  }

  title = 'Welcome to Admin Section';
  ngOnInit() {
    const self = this;
  }
}
