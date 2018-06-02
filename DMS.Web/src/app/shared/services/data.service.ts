import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { AppConfigService } from '../../core/services/app-config.service'
import { Promise } from 'q';

@Injectable()
export class DataService {

    constructor(private http: HttpClient, private appConfigService: AppConfigService, private router: Router) {
    }

    get<T>(controler: string, action: string = '', id: number = null) {
        let url = this.createUrl(controler, action, id);
        return this.http.get<T>(url, { headers: this.getHeaders() });
    } 

    post<T>(controler: string, action: string, data: any) {
        let url = this.createUrl(controler, action);
        return this.http.post<T>(url, data, { headers: this.getHeaders() });
    }

    put(controler: string, action: string, data: any): Observable<Object> {
        let url = this.createUrl(controler, action);
        return this.http
            .put(url, JSON.stringify(data), { headers: this.getHeaders() });
            //.catch(res => this.handleException(res));
    }

    private createUrl(controler: string, action: string, id: number = null): string {
        let url = this.pathCombine(this.appConfigService.apiUrl, this.pathCombine(controler, action));
        if (id != null)
            url += '/' + id;

        return url;
    }

    private pathCombine(part1: string, part2: string): string {
        return part1 + (part2 != '' ? '/' + part2 : '');
    }

    private getHeaders(): HttpHeaders {
        var authToken = localStorage.getItem("authToken");
        if (authToken == null)
            authToken = sessionStorage.getItem('authToken');

        return new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'bearer ' + authToken
        });
    }   
}