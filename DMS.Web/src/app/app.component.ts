import { Component } from '@angular/core'

@Component({
    selector: 'app-root',
    template: '<router-outlet></router-outlet>'
})

export class AppComponent {
    subtitle = '(v1)';
    Title = 'Donor Management System';
    userName: string;
    constructor() {
        this.userName = 'Wijitha Wijenayake';
    }
}