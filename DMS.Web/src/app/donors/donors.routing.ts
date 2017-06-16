import { ModuleWithProviders} from '@angular/core'
import { Routes, RouterModule} from '@angular/router'


import { DonorsComponent } from './donors.component'


const donorsRoutes: Routes = [
    {
        path: 'donors',
        component: DonorsComponent
    }
];

export const donorsRouting: ModuleWithProviders = RouterModule.forChild(donorsRoutes);