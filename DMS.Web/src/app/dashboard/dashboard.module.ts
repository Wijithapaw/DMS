import { NgModule } from '@angular/core'

import { SharedModule } from '../shared/shared.module';
import { DashboardComponent } from './dashboard.component';
import { dashboardRouting } from './dashboard.routing';

@NgModule({
    imports: [
        SharedModule,
        dashboardRouting
    ],
    declarations: [
        DashboardComponent
    ],
    providers: [

    ]
})

export class DashboardModule { }