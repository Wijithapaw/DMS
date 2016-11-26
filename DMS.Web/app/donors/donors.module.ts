import { NgModule } from '@angular/core';

import { DonorsComponent } from './donors.component';
import { SharedModule } from '../shared/shared.module';
import { donorsRouting } from './donors.routing';
import { DonorService } from './services/donor.service';

@NgModule({
    imports: [
        SharedModule,
        donorsRouting
    ],
    declarations: [
        DonorsComponent
    ],
    providers: [
        DonorService
    ],
    exports: [
        DonorsComponent
    ]

})
export class DonorsModule { }