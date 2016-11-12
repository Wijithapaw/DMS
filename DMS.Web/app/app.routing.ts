import { ModuleWithProviders} from '@angular/core'
import { Routes, RouterModule} from '@angular/router'

import { DashboardComponent } from './dashboard/dashboard.component'
import { DonorListComponent } from './donor/donor-list.component'
import { ProjectListComponent } from './project/project-list.component'

const appRoutes: Routes = [
    {
        path: 'dashboard',
        component: DashboardComponent
    },
    {
        path: 'donors',
        component: DonorListComponent
    },
    {
        path: 'projects',
        component: ProjectListComponent
    },
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);