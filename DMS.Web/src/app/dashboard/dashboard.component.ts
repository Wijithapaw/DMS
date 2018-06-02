import { Component } from '@angular/core'
import { Message } from 'primeng/primeng';
import { MessageService } from '../core/services/message.service';

@Component({
    moduleId: module.id,
    selector: 'dms-dashboard',
    templateUrl: 'dashboard.component.html'
})

export class DashboardComponent {

    constructor(private messageService: MessageService){}

    msgs: Message[] = [];

    growlTest() {
        this.messageService.showInfo('Dashboard');
        //this.msgs.push({severity:'success', summary:'Success!', detail:'Test message!'});
    }

} 