import './rxjs-extensions';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap'

//In-memory data service for initial phase of development and mockup
// import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
// import { InMemoryDataService } from './services/in-memory-data.service';

import { AppComponent} from './app.component';
import { routing } from './app.routing';

import { DashboardComponent } from './dashboard/dashboard.component';
import { DonorListComponent } from './donor/donor-list.component';
import { ProjectListComponent } from './project/project-list.component';
import { ModalTestComponent } from './test-area/modal-test.component';
import { DrawingboardComponent } from './test-area/drawingboard.component';
import { HighlightDirective } from './directives/highlight.directive';
import { TitleComponent } from './common/title.component';
import { EditProjectComponent } from './project/edit-project.component'


import { SharedModule } from './shared/shared.module';
import { DonorsModule } from './donors/donors.module';


import { DonorService } from './services/donor.service';
import { ProjectService } from './services/project.service';
import { ApiService} from './services/api.service';
import { BaseService } from './services/base.service';
import { UserService } from './services/user.service';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing,
        // InMemoryWebApiModule.forRoot(InMemoryDataService),
        NgbModule.forRoot(),
        SharedModule,
        DonorsModule
    ],
    declarations: [
        AppComponent,
        DashboardComponent,
        DonorListComponent,
        ProjectListComponent,
        DrawingboardComponent,
        ModalTestComponent,
        HighlightDirective,
        TitleComponent,
        EditProjectComponent
    ],
    providers: [
        BaseService,
        UserService,
        ApiService,
        DonorService,
        ProjectService,
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }