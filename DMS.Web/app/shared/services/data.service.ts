import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { AppConfigService } from '../../core/services/app-config.service'

@Injectable()
export class DataService {

    constructor(private http: Http, private appConfigService: AppConfigService) {
        
    }

    private getUrl(controler: string, action: string): string {
        return this.pathCombine(this.appConfigService.apiUrl, this.pathCombine(controler, action));
    }

    private pathCombine(part1: string, part2: string): string {
        return part1 + (part2 != '' ? '/' + part2 : '');
    }

    get(controler: string, action: string = '', id: number = 0): Observable<Response> {
        let url = this.getUrl(controler, action);
        if(id > 0)
            url += '/' + id;
        return this.http.get(url);
    }

    put(controler: string, action: string, id: number, jsonData : string) : Observable<Response>{
        console.log(jsonData);

        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });
        let options = new RequestOptions({ headers: headers });

        let url = this.getUrl(controler, action);
            url += '/' + id;
       
        return this.http.put(url,  jsonData, options)
             .map(res => res.json());
             
         
    }

    handleError(error) {
        console.error(error);
    }
}