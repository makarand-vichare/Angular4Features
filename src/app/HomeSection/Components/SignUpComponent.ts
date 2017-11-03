import { AuthService } from './../../AdminSection/Services/AuthService';
import { AppConstants } from './../../Common/AppConstants';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseComponent } from '../../Common/Components/BaseComponent';
import { Router } from '@angular/router';
import { NGXLogger } from 'ngx-logger';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { SignUpVM } from '../../AdminSection/ViewModels/SignUpVM';


@Component({
    selector: 'app-signup',
    templateUrl: './../Views/SignUpComponent.html',
    styleUrls: ['./../Views/SignUpComponent.scss']
})

export class SignUpComponent extends BaseComponent implements OnInit {
    constructor(_routerService: Router,
        _logService: NGXLogger,
        private authService: AuthService,
        _toastr: ToastsManager,
        _vRef: ViewContainerRef) {
        super(_routerService, _logService, _toastr, _vRef);
    }

    signUpVM: SignUpVM;

    ngOnInit() {
        const self = this;
        const dob = new Date();
        dob.setUTCFullYear(dob.getFullYear() - 20);
         self.signUpVM = {
            Name: '',
            Email: '',
            Password: '',
            DateOfBirth : dob,
            Country: -1,
            Location: '',
            Gender : -1
        } as SignUpVM;
    }

    StartTimer = () => {
        const self = this;
        setTimeout(() => {
            self.routerService.navigateByUrl('/login');
         }, 2000);
    }

    SignUp() {
        const self = this;
        self.authService.SignUp(self.signUpVM).subscribe(
            (response: any) => {
                if ( response.status === 400 ) {
                    if ( response.data.modelState != null) {
                        const errors = new Array<string>();
                        for ( const key in response.data.modelState ) {
                            if (key.length > 0 ) {
                                for ( let i = 0; i < response.data.modelState[key].length; i++ ) {
                                    errors.push( response.data.modelState[key][i] );
                                }
                            }
                        }
                        self.ProcessInfo.Message = 'Failed to register user due to:' + errors.join( ' ' );
                    } else {
                        self.ProcessInfo.Message = response.data.message;
                    }
                } else {
                    self.ProcessInfo.Message = response.data.message;
                    self.ProcessInfo.IsSucceed = true;
                    self.StartTimer();
                }
            },
            (error: any) => {
                self.ProcessInfo.Message = error;
            }
        );
    }
}
