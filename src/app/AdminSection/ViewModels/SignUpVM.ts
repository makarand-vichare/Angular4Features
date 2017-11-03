import { BaseVM } from '../../Common/ViewModels/BaseVM';
export class SignUpVM extends BaseVM {
    Id: any;
    Name: string;
    Email: string;
    Password: string;
    DateOfBirth: Date;
    Country: number;
    Location: string;
    Gender: number;
}
