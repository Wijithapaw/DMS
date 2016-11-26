import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ProjectService } from './services/project.service'
import { Project } from './models/project'

@Component({
    moduleId: module.id,
    selector: 'dms-projects',
    templateUrl: 'projects.component.html'
})

export class ProjectsComponent implements OnInit {

    projects: Project[];
    subtitle = "Projects";

    constructor(private projectService: ProjectService, private router: Router) { }

    private getProjects(): void {
        this.projectService.getProjects().then(projects => this.projects = projects);
    }

    createNew(): void {
        let link = ['/project/new'];
        this.router.navigate(link);
    }

    ngOnInit(): void {
        this.getProjects();
    }
}
