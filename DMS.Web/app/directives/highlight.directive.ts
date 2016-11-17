import { Directive, ElementRef, Renderer , OnInit} from '@angular/core';

@Directive({ selector: '[my-highlight]' })

export class HighlightDirective implements OnInit {
    constructor(private renderer: Renderer, private el: ElementRef) {
        
    }

    ngOnInit() {
        console.log('1212');
        this.renderer.setElementStyle(this.el.nativeElement, 'backgroundColor', 'yellow');
        this.renderer.setText(this.el.nativeElement, 'Wijitha Wijenayake');        
    }
}