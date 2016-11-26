import { Injectable } from '@angular/core';
import 'rxjs/add/operator/toPromise';

import { Donor } from '../models/donor';
import { DataService } from '../../shared/services/data.service';

@Injectable()
export class DonorService {

    constructor(private dataService: DataService) {  }

    getDonors(): Promise<Donor[]> {
        return this.dataService.get('donors', '')
            .toPromise()
            .then(response => response.json().data as Donor[])
            //.catch(this.handleError);
    }

    getDonors2(): Promise<Donor[]> {
        return new Promise<Donor[]>(resolve => setTimeout(resolve, 5000))
            .then(() => this.getDonors());
    }
}