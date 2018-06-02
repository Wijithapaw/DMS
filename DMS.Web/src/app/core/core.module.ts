import { NgModule, Optional, SkipSelf } from '@angular/core'
import { GrowlModule } from 'primeng/primeng';

import { AppConfigService } from './services/app-config.service';
import { throwIfAlreadyLoaded } from './module-import-guard';
import { UserSessionService } from './services/user-session.service';
import { GrowlMessageComponent } from './growl-message/growl-message.component';
import { MessageService } from './services/message.service';

@NgModule({
    imports: [
        GrowlModule
    ],
    declarations: [
        GrowlMessageComponent
    ],
    providers: [
        AppConfigService,
        MessageService,
        UserSessionService
    ],
    exports: [
        GrowlMessageComponent
    ]
})
export class CoreModule {
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
    }
}