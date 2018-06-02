import { Injectable } from '@angular/core'


import { DataService } from '../../shared/services/data.service';
import { LoginDto } from '../models/login-dto';
import { AuthToken } from '../models/auth-token';
import { UserDto } from '../models/user-dto';
import { UserLDto } from '../models/user-l-dto';
import { UserSessionService } from '../../core/services/user-session.service';
import { Observable, combineLatest } from 'rxjs';
import { flatMap, map } from 'rxjs/operators';

@Injectable()
export class AccountService {
    constructor(private dataService: DataService, private userSessionService: UserSessionService) {

    }

    public login(loginData: LoginDto) {
        return this.dataService.post<AuthToken>('account', 'login', loginData)
                .pipe(flatMap(token => {
                    this.persistAuthToekn(token, loginData.rememberMe);
                    return this.setCurrentUserInSession();
                }));
    }

    private getCurrentUset(): Observable<UserLDto> {
        return this.dataService.get<UserLDto>("account", "currentuser");
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
        return this.getCurrentUset()
            .pipe(map(user => { 
                user =>  this.userSessionService.user = user 
            }));            
    }
}