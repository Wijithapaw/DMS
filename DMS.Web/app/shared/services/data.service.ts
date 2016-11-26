import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class DataService {

    apiRootUrl = 'app'

    constructor(private http: Http) {
        
    }

    private getUrl(controler: string, action: string): string {
        return this.pathCombine(this.apiRootUrl, this.pathCombine(controler, action));
    }

    private pathCombine(part1: string, part2: string): string {
        return part1 + (part2 != '' ? '/' + part2 : '');
    }

    get(controler: string, action: string): Observable<Response> {
        let url = this.getUrl(controler, action);
        return this.http.get(url);
    }
}