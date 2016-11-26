﻿import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { Project } from '../models/project';
import { ProjectService } from '../services/project.service';

@Component({
    moduleId: module.id,
    selector: 'edit-project',
    templateUrl: 'edit-project.component.html'
})

export class EditProjectComponent implements OnInit {
    subtitle = 'Edit Project';
    project: Project;

    constructor(private route: ActivatedRoute, private projectService: ProjectService) {
       
    }

    ngOnInit(): void {
        this.route.params.forEach((params: Params) =>
        {
            let id = +params['id'];
            this.projectService.getProject(id).then(project => this.project = (project != null ? project : new Project()));
        });
    }
 
    onSubmit(): void {
        alert(this.project.title);
    }

    cancel() : void {
        alert('cancel');
    }
}
