import './rxjs-extensions';

import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap'

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing';

import { CoreModule } from './core/core.module';
import { AuthorizedLayoutComponent } from './layout/authorized-layout/authorized-layout.component';
import { UnauthorizedLayoutComponent } from './layout/unauthorized-layout/unauthorized-layout.component';
import { ErrorsHandler } from './shared/services/error-handler';

@NgModule({
    imports: [
        BrowserModule,
        CoreModule,
        HttpClientModule,
        AppRoutingModule,
        NgbModule.forRoot()
    ],
    declarations: [
        AppComponent,
        AuthorizedLayoutComponent,
        UnauthorizedLayoutComponent,
    ],
    providers: [
        {
            provide: ErrorHandler,
            useClass: ErrorsHandler,
        }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }