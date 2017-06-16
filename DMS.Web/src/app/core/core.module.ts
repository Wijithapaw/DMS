import { NgModule, Optional, SkipSelf } from '@angular/core'

import { AppConfigService } from './services/app-config.service';
import { throwIfAlreadyLoaded } from './module-import-guard';

@NgModule({
    imports: [

    ],
    declarations: [

    ],
    providers: [
        AppConfigService
    ]
})
export class CoreModule {
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
    }
}