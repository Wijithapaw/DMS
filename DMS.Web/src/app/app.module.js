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
require('./rxjs-extensions');
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
var ng_bootstrap_1 = require('@ng-bootstrap/ng-bootstrap');
var app_component_1 = require('./app.component');
var app_routing_1 = require('./app.routing');
var shared_module_1 = require('./shared/shared.module');
var donors_module_1 = require('./donors/donors.module');
var projects_module_1 = require('./projects/projects.module');
var dashboard_module_1 = require('./dashboard/dashboard.module');
var core_module_1 = require('./core/core.module');
var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                core_module_1.CoreModule,
                dashboard_module_1.DashboardModule,
                donors_module_1.DonorsModule,
                http_1.HttpModule,
                app_routing_1.routing,
                ng_bootstrap_1.NgbModule.forRoot(),
                shared_module_1.SharedModule,
                projects_module_1.ProjectsModule
            ],
            declarations: [
                app_component_1.AppComponent
            ],
            providers: [],
            bootstrap: [app_component_1.AppComponent]
        }), 
        __metadata('design:paramtypes', [])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map