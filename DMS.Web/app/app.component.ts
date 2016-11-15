import { Component } from '@angular/core'

import { UserService } from './services/user.service'

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html'
})

export class AppComponent {
    subtitle = '(v1)';
    Title = 'Donor Management System';
    userName: string;
    constructor(private userService: UserService) {
        this.userName = userService.userName;
    }
}