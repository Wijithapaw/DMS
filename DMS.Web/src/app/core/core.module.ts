import { NgModule, Optional, SkipSelf } from '@angular/core'

import { AppConfigService } from './services/app-config.service';
import { throwIfAlreadyLoaded } from './module-import-guard';
import { UserSessionService } from './services/user-session.service';

@NgModule({
    imports: [

    ],
    declarations: [

    ],
    providers: [
        AppConfigService,
        UserSessionService
    ]
})
export class CoreModule {
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
    }
}