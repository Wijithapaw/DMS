import './rxjs-extensions';

import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap'

import { AppComponent} from './app.component';
import { routing } from './app.routing';

import { SharedModule } from './shared/shared.module';
import { DonorsModule } from './donors/donors.module';
import { ProjectsModule } from './projects/projects.module';
import { DashboardModule } from './dashboard/dashboard.module';

@NgModule({
    imports: [
        HttpModule,
        routing,
        NgbModule.forRoot(),
        SharedModule,
        DashboardModule,
        DonorsModule,
        ProjectsModule
    ],
    declarations: [
        AppComponent
    ],
    providers: [
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }