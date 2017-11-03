import { Component, OnInit, ViewContainerRef  } from '@angular/core';
import { BaseComponent } from './../../Common/Components/BaseComponent';
import {Router} from '@angular/router';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { NGXLogger } from 'ngx-logger';
@Component({
  selector: 'app-root',
  templateUrl: './../Views/RootComponent.html',
  styleUrls: ['./../Views/RootComponent.scss'],
  providers: [NGXLogger]
})
export class RootComponent implements OnInit {
  title = 'App Root Page';
  constructor(private logger: NGXLogger) {
    this.logger.debug('Your log message goes here');
  }
  ngOnInit() {
    this.logger.debug('ngOnInit');
  }
}
