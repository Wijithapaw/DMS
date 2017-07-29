import { NgModule} from '@angular/core'
import { Routes, RouterModule} from '@angular/router'


import { DonorsComponent } from './donors.component'


const donorsRoutes: Routes = [
    {
        path: '',
        component: DonorsComponent,
        data: {
            title: 'Donors'
        }
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(donorsRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class DonorsRoutingModule{}