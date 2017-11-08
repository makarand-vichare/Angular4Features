import { BaseVM } from '../../Common/ViewModels/BaseVM';
import { Moment } from 'moment';
export class SignUpVM extends BaseVM {
    Id: any;
    Email: string;
    Password: string;
    DateOfBirth: Moment;
    CountryId: number;
    CityId: number;
    Gender: number;
    AboutInfo: string;
}
