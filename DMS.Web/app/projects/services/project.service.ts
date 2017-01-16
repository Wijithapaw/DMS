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
            .then(response=>  response.json() as Project[])
            .catch((reason) => console.error(reason));
    }

    getProject(id: number): Promise<Project> {
        return this.getProjects()
            .then(projects => projects.find(project => project.id === id));
    }
}