import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';


import { Project } from '../models/project';
import { DataService } from '../../shared/services/data.service'
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class ProjectService {

    constructor(private dataService: DataService) { }

    getProjects(): Observable<Project[]>{
        return this.dataService.get<Project[]>('projects');                
    }

    getProject(id: number): Observable<Project> {
        return this.dataService.get<Project>('projects', '', id)
    }

    updateProject(project: Project) {
        return this.dataService.put<void>('projects', '',project);
    }
}