import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError, empty } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';

import { AppConfigService } from '../../core/services/app-config.service'
import { Promise } from 'q';
import { MessageService } from '../../core/services/message.service';

@Injectable()
export class DataService {

    constructor(private http: HttpClient, private appConfigService: AppConfigService, private router: Router, 
        private messageService: MessageService,
        private injector: Injector) {
    }

    get<T>(controler: string, action: string = '', id: number = null) {
        let url = this.createUrl(controler, action, id);
        return this.http.get<T>(url, { headers: this.getHeaders() })
        .pipe(catchError((a, b) => {
            return this.handleError(a,b);
        }));
    } 

    post<T>(controler: string, action: string, data: any) {
        let url = this.createUrl(controler, action);
        return this.http.post<T>(url, data, { headers: this.getHeaders() })
        .pipe(catchError((a, b) => {
            return this.handleError(a,b);
        }));
    }

    put<T>(controler: string, action: string, data: any) {
        let url = this.createUrl(controler, action);
        return this.http.put<T>(url, data, { headers: this.getHeaders() })
        .pipe(catchError((a, b) => {
            return this.handleError(a,b);
        }));
    }

    private createUrl(controler: string, action: string, id: number = null): string {
        let url = this.pathCombine(this.appConfigService.apiUrl, this.pathCombine(controler, action));
        if (id != null)
            url += '/' + id;

        return url;
    }
        
    private handleError(error, caught) {
        var errorMsg = '';
        if (error.status == 401) { 
            localStorage.removeItem("authToken");
            sessionStorage.removeItem("authToken");

            let link = ['/login', { returnUrl: this.router.url }];
            this.router.navigate(link);
            errorMsg = 'Unauthorized access';

        } else if (error.status == 403) { 
            localStorage.removeItem("authToken");
            sessionStorage.removeItem("authToken");

            let link = ['/login'];
            this.router.navigate(link);

            errorMsg = 'Insufficent permission';
        }
        else if (error.status == 500){                    
            errorMsg = error.error.message;
        }
        else {
            errorMsg = 'Unknown error';
        }
        
        this.messageService.showError(errorMsg);
        return ErrorObservable.create(error);
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