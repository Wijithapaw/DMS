import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ProjectService } from './services/project.service';
import { ProjectsComponent } from './projects.component';
import { ProjectsRoutingModule } from './projects.routing';

import { EditProjectComponent } from './edit-project/edit-project.component';

@NgModule({
    imports: [
        ProjectsRoutingModule,
        SharedModule
    ],
    declarations: [
        ProjectsComponent,
        EditProjectComponent
    ],
    providers: [
        ProjectService
    ],
    exports: [

    ]
})

export class ProjectsModule { }