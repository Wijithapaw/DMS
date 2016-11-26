import { NgModule } from '@angular/core'

//In-memory data service for initial phase of development and mockup
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './services/in-memory-data.service';

import { DataService } from'./services/data.service'; 

@NgModule({
    imports: [
        InMemoryWebApiModule.forRoot(InMemoryDataService)
    ],
    declarations: [

    ],
    providers: [
        DataService
    ],
    exports: [

    ]
})

export class SharedModule {}