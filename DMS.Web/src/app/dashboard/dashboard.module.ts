import { NgModule } from '@angular/core'

import { SharedModule } from '../shared/shared.module';
import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard.routing';
import { GrowlModule } from 'primeng/primeng';

@NgModule({
    imports: [
        GrowlModule,
        SharedModule,
        DashboardRoutingModule
    ],
    declarations: [
        DashboardComponent
    ],
    providers: [

    ]
})

export class DashboardModule { }