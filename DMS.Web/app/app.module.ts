import './rxjs-extensions';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap'

import { AppComponent} from './app.component';
import { routing } from './app.routing';

import { DashboardComponent } from './dashboard/dashboard.component';
import { ModalTestComponent } from './test-area/modal-test.component';
import { DrawingboardComponent } from './test-area/drawingboard.component';
import { HighlightDirective } from './directives/highlight.directive';
import { TitleComponent } from './common/title.component';

import { SharedModule } from './shared/shared.module';
import { DonorsModule } from './donors/donors.module';
import { ProjectsModule } from './projects/projects.module';

import { ApiService} from './services/api.service';
import { BaseService } from './services/base.service';
import { UserService } from './services/user.service';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing,
        NgbModule.forRoot(),
        SharedModule,
        DonorsModule,
        ProjectsModule
    ],
    declarations: [
        AppComponent,
        DashboardComponent,
        DrawingboardComponent,
        ModalTestComponent,
        HighlightDirective,
        TitleComponent
    ],
    providers: [
        BaseService,
        UserService,
        ApiService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }