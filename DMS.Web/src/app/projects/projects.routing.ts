import { NgModule } from '@angular/core'
import { Routes, RouterModule} from '@angular/router'

import { ProjectsComponent } from './projects.component'
import { EditProjectComponent } from './edit-project/edit-project.component';

const projectsRoutes: Routes = [
    {
        path: '',
        component: ProjectsComponent,
        data: {
            title: ''
        }
    },
    {
        path: 'new',
        component: EditProjectComponent,
        data: {
            title: 'New'
        }
    },
    {
        path: 'edit/:id',
        component: EditProjectComponent,
        data: {
            title: 'Edit'
        }
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(projectsRoutes)
    ],
    exports: [
        RouterModule
    ]
})

export class ProjectsRoutingModule {}