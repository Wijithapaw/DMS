import { Injectable } from '@angular/core';
import 'rxjs/add/operator/toPromise';

import { Donor } from '../models/donor';
import { ApiService} from './api.service'
import { BaseService } from './base.service'

@Injectable()
export class DonorService extends BaseService {

    constructor(private apiService: ApiService) { super(); }

    getDonors(): Promise<Donor[]> {
        return this.apiService.get('donors', '')
            .toPromise()
            .then(response => response.json().data as Donor[])
            .catch(this.handleError);
    }

    getDonors2(): Promise<Donor[]> {
        return new Promise<Donor[]>(resolve => setTimeout(resolve, 5000))
            .then(() => this.getDonors());
    }
}