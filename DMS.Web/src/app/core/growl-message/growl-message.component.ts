import { Component, OnInit } from '@angular/core';
import { MessageService } from '../services/message.service';


@Component({
  selector: 'dms-growl-message',
  templateUrl: './growl-message.component.html'
})
export class GrowlMessageComponent {
  constructor(public messageService: MessageService) { }  
}
