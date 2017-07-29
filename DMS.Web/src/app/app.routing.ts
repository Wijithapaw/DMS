import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthorizedLayoutComponent } from './layout/authorized-layout/authorized-layout.component';
import { UnauthorizedLayoutComponent } from './layout/unauthorized-layout/unauthorized-layout.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
    },
    {
        path: '',
        component: AuthorizedLayoutComponent,
        data: {
            title: 'Home'
        },
        children: [
            {
                path: 'dashboard',
                loadChildren: './dashboard/dashboard.module#DashboardModule'
            },
            {
                path: 'projects',
                loadChildren: './projects/projects.module#ProjectsModule'
            },
            {
                path: 'donors',
                loadChildren: './donors/donors.module#DonorsModule'
            },
        ]
    },
    {
        path: 'login',
        component: UnauthorizedLayoutComponent,
        children: [
            {
                path: '',
                loadChildren: './account/account.module#AccountModule'
            }
        ]
    }    
]

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }