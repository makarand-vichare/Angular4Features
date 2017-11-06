import { AuthService } from './../../AdminSection/Services/AuthService';
import { AppConstants, MOMENT_FORMATS } from './../../Common/AppConstants';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseComponent } from '../../Common/Components/BaseComponent';
import { Router } from '@angular/router';
import { NGXLogger } from 'ngx-logger';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { SignUpVM } from '../../AdminSection/ViewModels/SignUpVM';
import { KeyValuePair } from '../../Common/ViewModels/KeyValuePair';
import { Genders } from '../../Common/AppEnum';
import { CountryService } from '../../Common/Services/CountryService';
import * as moment from 'moment';
import { MomentDateAdapter } from '../../Common/Helpers/MomentDateAdapter';
import { CityService } from '../../Common/Services/CityService';

@Component({
    selector: 'app-signup',
    templateUrl: './../Views/SignUpComponent.html',
    styleUrls: ['./../Views/SignUpComponent.scss'],
    providers: [CityService, CountryService, NGXLogger, MomentDateAdapter]
})

export class SignUpComponent extends BaseComponent implements OnInit {
    constructor(_routerService: Router,
        _logService: NGXLogger,
        private authService: AuthService,
        private countryService: CountryService,
        private cityService: CityService,
        _toastr: ToastsManager,
        _vRef: ViewContainerRef,
        private dateAdapter: MomentDateAdapter) {
        super(_routerService, _logService, _toastr, _vRef);
    }

    signUpVM: SignUpVM;
    countries: Array<KeyValuePair>;
    genders: Array<KeyValuePair>;
    cities: Array<KeyValuePair>;

    ngOnInit() {
        const self = this;
        const dob = self.dateAdapter.addCalendarYears(moment(), -20);

         self.signUpVM = {
            Name: 'Name1',
            Email: 'Email@email.com',
            Password: '',
            DateOfBirth : dob,
            Country: -1,
            City: -1,
            Gender : -1,
            AboutInfo : ''
        } as SignUpVM;

        self.genders = [
         {id: '0', value: 'Select'} as KeyValuePair,
         {id: Genders.Female.toString(), value: Genders[Genders.Female] } as KeyValuePair,
         {id: Genders.Male.toString(), value: Genders[Genders.Male] } as KeyValuePair
        ] as Array<KeyValuePair>;

        self.GetCountries();
    }

    GetCountries = () => {
        const self = this;
        self.countryService.GetCountries().subscribe(
            (response: any) => {
                if (response.isSucceed) {
                    self.countries = response.viewModels;
                }
            },
            (error: any) => {
                self.logService.error(error);
                console.error(error);
            }
        );
    }

    GetCities = () => {
        const self = this;
        self.cityService.GetCities(self.signUpVM.Country).subscribe(
            (response: any) => {
                if (response.isSucceed) {
                    self.cities = response.viewModels;
                }
            },
            (error: any) => {
                self.logService.error(error);
                console.error(error);
            }
        );
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
