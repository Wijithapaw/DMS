import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Project } from '../models/project';
import { DataService} from '../../shared/services/data.service'

@Injectable()
export class ProjectService  {

    constructor(private dataService: DataService) { }

    getProjects(): Promise<Project[]> {
        return this.dataService.get('projects', '')
            .toPromise()
            .then(response => response.json().data as Project[])
            //.catch(this.handleError);
    }

    getProject(id: number): Promise<Project> {
        return this.getProjects()
            .then(projects => projects.find(project => project.id === id));
    }
}