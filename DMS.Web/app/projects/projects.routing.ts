import { ModuleWithProviders} from '@angular/core'
import { Routes, RouterModule} from '@angular/router'

import { ProjectsComponent } from './projects.component'
import { EditProjectComponent } from './edit-project/edit-project.component';


const projectsRoutes: Routes = [
    {
        path: 'projects',
        component: ProjectsComponent
    },
    {
        path: 'project/new',
        component: EditProjectComponent
    },
    {
        path: 'project/edit/:id',
        component: EditProjectComponent
    }
];

export const projectsRouting: ModuleWithProviders = RouterModule.forChild(projectsRoutes);