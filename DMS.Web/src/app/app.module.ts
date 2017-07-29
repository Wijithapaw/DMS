import './rxjs-extensions';

import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap'

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing';

import { CoreModule } from './core/core.module';
import { AuthorizedLayoutComponent } from './layout/authorized-layout/authorized-layout.component';
import { UnauthorizedLayoutComponent } from './layout/unauthorized-layout/unauthorized-layout.component';

@NgModule({
    imports: [
        BrowserModule,
        CoreModule,
        HttpModule,
        AppRoutingModule,
        NgbModule.forRoot()
    ],
    declarations: [
        AppComponent,
        AuthorizedLayoutComponent,
        UnauthorizedLayoutComponent,
    ],
    providers: [
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }