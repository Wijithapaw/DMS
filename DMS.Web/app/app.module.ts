import './rxjs-extensions';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap'

//In-memory data service for initial phase of development and mockup
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './services/in-memory-data.service';

import { AppComponent} from './app.component';
import { routing } from './app.routing';

import { DashboardComponent } from './dashboard/dashboard.component';
import { DonorListComponent } from './donor/donor-list.component';
import { ProjectListComponent } from './project/project-list.component';
import { ModalTestComponent } from './test-area/modal-test.component';
import { DrawingboardComponent } from './test-area/drawingboard.component';

import { DonorService } from './services/donor.service';
import { ProjectService } from './services/project.service';
import { ApiService} from './services/api.service';
import { BaseService } from './services/base.service';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing,
        InMemoryWebApiModule.forRoot(InMemoryDataService),
        NgbModule.forRoot()
    ],
    declarations: [
        AppComponent,
        DashboardComponent,
        DonorListComponent,
        ProjectListComponent,
        DrawingboardComponent,
        ModalTestComponent
    ],
    providers: [
        BaseService,
        ApiService,
        DonorService,
        ProjectService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }