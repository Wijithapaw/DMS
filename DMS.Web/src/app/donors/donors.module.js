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
var donors_component_1 = require('./donors.component');
var shared_module_1 = require('../shared/shared.module');
var donors_routing_1 = require('./donors.routing');
var donor_service_1 = require('./services/donor.service');
var DonorsModule = (function () {
    function DonorsModule() {
    }
    DonorsModule = __decorate([
        core_1.NgModule({
            imports: [
                shared_module_1.SharedModule,
                donors_routing_1.donorsRouting
            ],
            declarations: [
                donors_component_1.DonorsComponent
            ],
            providers: [
                donor_service_1.DonorService
            ],
            exports: [
                donors_component_1.DonorsComponent
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], DonorsModule);
    return DonorsModule;
}());
exports.DonorsModule = DonorsModule;
//# sourceMappingURL=donors.module.js.map