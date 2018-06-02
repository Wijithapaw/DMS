import { NgModule, ErrorHandler, Injectable } from '@angular/core'
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

//In-memory data service for initial phase of development and mockup
//import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
//import { InMemoryDataService } from './services/in-memory-data.service';

import { DataService } from './services/data.service';
import { PageHeaderComponent } from './page-header/page-header.component';
import { ErrorsHandler } from './services/error-handler';

@NgModule({
    imports: [
        //BrowserModule,
        CommonModule,
        FormsModule,
        //InMemoryWebApiModule.forRoot(InMemoryDataService)
    ],
    declarations: [
        PageHeaderComponent
    ],
    providers: [
        DataService        
    ],
    exports: [
        //BrowserModule,
        CommonModule,
        FormsModule,
        PageHeaderComponent
    ]
})

export class SharedModule { }