/* tslint:disable:no-console */
import { AppRoutingModule } from './AppRoutingModule';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, isDevMode } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RootComponent } from './Components/RootComponent';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastModule } from 'ng2-toastr/ng2-toastr';
import { FormsModule } from '@angular/forms';
import { AngularWebStorageModule } from 'angular-web-storage';
import { LoginMenuComponent } from './Components/LoginMenuComponent';
import { HomeComponent } from '../HomeSection/Components/HomeComponent';
import { TopMenuComponent } from './Components/TopMenuComponent';
import { LoginComponent } from '../HomeSection/Components/LoginComponent';
import { StarShipComponent } from './../AdminSection/Components/StarShipComponent';
import { StarShipTravelComponent } from './../UserSection/Components/StarShipTravelComponent';
import { PlanetComponent } from './../AdminSection/Components/PlanetComponent';
import { AdminLandingComponent } from '../AdminSection/Components/AdminLandingComponent';
import { UserLandingComponent } from '../UserSection/Components/UserLandingComponent';
import { LoggerModule, NgxLoggerLevel, NGXLogger  } from 'ngx-logger';
import { environment } from '../../environments/environment';
@NgModule({
  declarations: [
    RootComponent,
    PlanetComponent,
    StarShipComponent,
    StarShipTravelComponent,
    HomeComponent,
    LoginComponent,
    LoginMenuComponent,
    TopMenuComponent,
    AdminLandingComponent,
    UserLandingComponent
  ],
  imports: [
    NgbModule.forRoot(),
    ToastModule.forRoot(),
    LoggerModule.forRoot({serverLoggingUrl: '/api/logs', level: NgxLoggerLevel.DEBUG, serverLogLevel: NgxLoggerLevel.ERROR}),
    BrowserModule,
    BrowserAnimationsModule,
    HttpModule,
    AppRoutingModule,
    ToastModule,
    FormsModule,
    AngularWebStorageModule
  ],
  providers: [],
  bootstrap: [RootComponent]
})
export class AppModule {
  constructor(private logger: NGXLogger ) {
    if (isDevMode()) {
      console.info('To see debug logs enter: \'logger.level = logger.Level.DEBUG;\' in your browser console');
    }
    /// this.logger.level = environment.logger.level;
  }
}
