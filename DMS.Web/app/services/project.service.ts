import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Project } from '../models/project';
import { ApiService} from './api.service'
import { BaseService } from './base.service';

@Injectable()
export class ProjectService extends BaseService {

    constructor(private apiService: ApiService) { super(); }

    getProjects(): Promise<Project[]> {
        return this.apiService.get('projects', '')
            .toPromise()
            .then(response => response.json().data as Project[])
            .catch(this.handleError);
    }

    getProject(id: number): Promise<Project> {
        return this.getProjects()
            .then(projects => projects.find(project => project.id === id));
    }
}