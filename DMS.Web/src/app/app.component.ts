import { Component } from '@angular/core'

@Component({
    selector: 'app-root',
    templateUrl: 'app.component.html'
})

export class AppComponent {
    subtitle = '(v1)';
    Title = 'Donor Management System';
    userName: string;
    constructor() {
        this.userName = 'Wijitha Wijenayake';
    }
}