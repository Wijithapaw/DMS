import { Component, OnInit } from '@angular/core';

import { Donor } from '../models/donor';
import { DonorService } from '../services/donor.service'

@Component({
    selector: 'donor-list',
    templateUrl: 'app/donor/donor-list.component.html'
})

export class DonorListComponent implements OnInit {

    donors: Donor[];

    constructor(private donorService: DonorService) {

    }

    getDonors(): void {
        this.donorService.getDonors().then(donors => this.donors = donors);
    }

    ngOnInit(): void {
        this.getDonors();
    }
}