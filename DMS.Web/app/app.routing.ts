import { ModuleWithProviders} from '@angular/core'
import { Routes, RouterModule} from '@angular/router'

import { DashboardComponent } from './dashboard/dashboard.component'
import { ProjectListComponent } from './project/project-list.component'
import { DrawingboardComponent } from './test-area/drawingboard.component'
import { EditProjectComponent } from './project/edit-project.component'

const appRoutes: Routes = [
    {
        path: 'dashboard',
        component: DashboardComponent
    },
    {
        path: 'projects',
        component: ProjectListComponent
    },
    {
        path: 'drawingboard',
        component: DrawingboardComponent
    },
    {
        path: 'project/new',
        component: EditProjectComponent
    },
    {
        path: 'project/edit/:id',
        component: EditProjectComponent
    },
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);