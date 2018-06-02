import { Injectable } from '@angular/core';


import { Donor } from '../models/donor';
import { DataService } from '../../shared/services/data.service';
import { Observable } from 'rxjs';

@Injectable()
export class DonorService {

    constructor(private dataService: DataService) {  }

    getDonors(): Observable<Donor[]> {
        return this.dataService.get<Donor[]>('donors');
    }
}