import { Injectable } from '@angular/core'
import 'rxjs/add/operator/toPromise';

import { DataService } from '../../shared/services/data.service';
import { LoginDto } from '../models/login-dto';
import { AuthToken } from '../models/auth-token';
import { UserDto } from '../models/user-dto';
import { UserLDto } from '../models/user-l-dto';
import { UserSessionService } from '../../core/services/user-session.service';

@Injectable()
export class AccountService {
    constructor(private dataService: DataService, private userSessionService: UserSessionService) {

    }

    public login(loginData: LoginDto){
        return this.dataService.post('account', 'login', loginData)
        .toPromise()
        .then(res => res.json() as AuthToken)
        .then(token => this.persistAuthToekn(token, loginData.rememberMe))
        .then(() => this.setCurrentUserInSession());
    }

    public getCurrentUset(): Promise<UserLDto> {
        return this.dataService.get("account", "currentuser")
        .toPromise()
        .then(res => res.json() as UserLDto);
    }

    private persistAuthToekn(authToke : AuthToken, remember: boolean) {        
        sessionStorage.removeItem("authToken");
        localStorage.removeItem("authToken");

        if(remember) {
            localStorage.setItem("authToken", authToke.token);
        } else {
            sessionStorage.setItem("authToken", authToke.token);
        }
    }

    private setCurrentUserInSession() {
        this.getCurrentUset()
        .then(user => { this.userSessionService.user = user; console.log(user)});
    }
}