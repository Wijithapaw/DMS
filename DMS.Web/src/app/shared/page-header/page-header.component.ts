import { Component, Input , EventEmitter, Output} from '@angular/core'

@Component({
    moduleId : module.id,
    selector: 'dms-page-header',
    templateUrl: 'page-header.component.html'
})

export class PageHeaderComponent {
    @Input() subTitle: string;
    @Input() buttonName: string;
    @Output() buttonClicked : EventEmitter<void>;

  constructor() {
    this.buttonClicked = new EventEmitter<void>();
  }
    buttonClick(event: any) {
        event.preventDefault();
        this.buttonClicked.emit();
    }
}


