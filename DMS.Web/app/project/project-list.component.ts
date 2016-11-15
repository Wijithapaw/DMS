import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ProjectService } from '../services/project.service'
import { Project } from '../models/project'

@Component({
    selector: 'project-list',
    templateUrl: 'app/project/project-list.component.html'
})

export class ProjectListComponent implements OnInit {

    projects: Project[];
    subtitle = "Projects";
    constructor(private projectService: ProjectService, private router: Router) { }

    getProjects(): void {
        this.projectService.getProjects().then(projects => this.projects = projects);
    }

    createNew(): void {
        let link = ['/project/new', 0];
        this.router.navigate(link);
    }

    edit(id: number): void {
        let link = ['/project/edit', id];
        this.router.navigate(link);
    }

    ngOnInit(): void {
        this.getProjects();
    }
}
