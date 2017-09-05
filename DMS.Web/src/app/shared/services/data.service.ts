import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { AppConfigService } from '../../core/services/app-config.service'

@Injectable()
export class DataService {

    constructor(private http: Http, private appConfigService: AppConfigService, private router: Router) {

    }

    get(controler: string, action: string = '', id: number = null): Observable<Response> {
        let url = this.createUrl(controler, action, id);
        return this.http.get(url, { headers: this.getHeaders() })
            .catch(res => this.handleException(res));
    }

    post(controler: string, action: string, data: any): Observable<Response> {
        let url = this.createUrl(controler, action);
        return this.http
            .post(url, JSON.stringify(data), { headers: this.getHeaders() })
            .catch(res => this.handleException(res));
    }

    put(controler: string, action: string, data: any): Observable<Response> {
        let url = this.createUrl(controler, action);
        return this.http
            .put(url, JSON.stringify(data), { headers: this.getHeaders() })
            .catch(res => this.handleException(res));
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

    private getHeaders(): Headers {
        var authToken = localStorage.getItem("authToken");
        if (authToken == null)
            authToken = sessionStorage.getItem('authToken');

        return new Headers({
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'bearer ' + authToken
        });
    }

    private handleException(response: Response): Observable<Response> {
        if (response.status == 401) {
            localStorage.removeItem("authToken");
            sessionStorage.removeItem("authToken");

            let link = ['/login', { returnUrl: this.router.url }]; 
            this.router.navigate(link);
        }else if (response.status == 403) {

            localStorage.removeItem("authToken");
            sessionStorage.removeItem("authToken");

            let link = ['/login']; 
            this.router.navigate(link);

            //Show Forbiden Access Message
        }         
        else {
            //Show Error Message
            console.log(response.json())
        }
        throw Observable.throw(response);
    }
}