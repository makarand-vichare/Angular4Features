import { BaseVM } from '../../Common/ViewModels/BaseVM';
import { Moment } from 'moment';
export class SignUpVM extends BaseVM {
    Id: any;
    Name: string;
    Email: string;
    Password: string;
    DateOfBirth: Moment;
    Country: number;
    City: number;
    Gender: number;
    AboutInfo: string;
}
