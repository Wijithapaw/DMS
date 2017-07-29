import { Injectable } from '@angular/core'
import { DataService } from '../../shared/services/data.service';
import { LoginDto } from '../models/login-dto';


@Injectable()
export class AccountService {
    constructor(private dataService: DataService) {

    }

    public login(loginData: LoginDto) {
        
    }
}