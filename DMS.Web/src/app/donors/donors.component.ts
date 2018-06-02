import { Component, OnInit } from '@angular/core';

import { Donor } from './models/donor';
import { DonorService } from './services/donor.service'

@Component({
    moduleId: module.id,
    selector: 'dms-donors',
    templateUrl: 'donors.component.html'
})

export class DonorsComponent implements OnInit {

    donors: Donor[];

    constructor(private donorService: DonorService) {

    }
   
    ngOnInit(): void {
        this.getDonors();
    }

    getDonors(): void {
        this.donorService.getDonors()
            .subscribe(
                donors => this.donors = donors
            );
    }

}