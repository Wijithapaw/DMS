import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

//In-memory data service for initial phase of development and mockup
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './services/in-memory-data.service';

import { DataService } from './services/data.service';

@NgModule({
    imports: [
        BrowserModule,
        CommonModule,
        FormsModule,
        InMemoryWebApiModule.forRoot(InMemoryDataService)
    ],
    declarations: [

    ],
    providers: [
        DataService
    ],
    exports: [
        BrowserModule,
        CommonModule,
        FormsModule
    ]
})

export class SharedModule { }