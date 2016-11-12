import { Component, OnInit } from '@angular/core'

import { ProjectService } from '../services/project.service'
import { Project } from '../models/project'

@Component({
    selector: 'project-list',
    templateUrl: 'app/project/project-list.component.html'
})

export class ProjectListComponent implements OnInit {

    projects: Project[];

    constructor(private projectService: ProjectService) { }

    getProjects(): void {
        this.projectService.getProjects().then(projects => this.projects = projects);
    }

    ngOnInit(): void {
        this.getProjects();
    }
}
