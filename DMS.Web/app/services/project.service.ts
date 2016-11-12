import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Project } from '../models/project';
import { ApiService} from './api.service'

@Injectable()
export class ProjectService {

    private projectsUrl = 'app/projects'
    /*
    constructor(private http: Http) { }

    getProjects(): Promise<Project[]> {
        return this.http.get(this.projectsUrl)
            .toPromise()
            .then(response => response.json().data as Project[])
            .catch(this.handleError);
    }

    handleError(error: any): Promise<any> {
        console.error('Error Occured', error);
        return Promise.reject(error.message || error);
    }
    */

    constructor(private apiService: ApiService) { }

    getProjects(): Promise<Project[]> {
        return this.apiService.get('projects', '')
            .toPromise()
            .then(response => response.json().data as Project[])
    }
}