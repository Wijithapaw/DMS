import { Component, Input } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'page-title',
    templateUrl: 'title.component.html'
})

export class TitleComponent {
    @Input() subtitle = '';
    title = 'DMS';
}