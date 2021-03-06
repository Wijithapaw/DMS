"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var donor_service_1 = require('./services/donor.service');
var DonorsComponent = (function () {
    function DonorsComponent(donorService) {
        this.donorService = donorService;
    }
    DonorsComponent.prototype.getDonors = function () {
        var _this = this;
        this.donorService.getDonors().then(function (donors) { return _this.donors = donors; });
    };
    DonorsComponent.prototype.ngOnInit = function () {
        this.getDonors();
    };
    DonorsComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'dms-donors',
            templateUrl: 'donors.component.html'
        }), 
        __metadata('design:paramtypes', [donor_service_1.DonorService])
    ], DonorsComponent);
    return DonorsComponent;
}());
exports.DonorsComponent = DonorsComponent;
//# sourceMappingURL=donors.component.js.map