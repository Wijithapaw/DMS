﻿import { ModuleWithProviders} from '@angular/core'
import { Routes, RouterModule} from '@angular/router'

import { DashboardComponent } from './dashboard/dashboard.component'
import { DrawingboardComponent } from './test-area/drawingboard.component'

const appRoutes: Routes = [
    {
        path: 'dashboard',
        component: DashboardComponent
    },
    {
        path: 'drawingboard',
        component: DrawingboardComponent
    },
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);