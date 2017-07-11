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
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
require("rxjs/add/operator/toPromise");
var data_service_1 = require("../../shared/services/data.service");
var ProjectService = (function () {
    function ProjectService(dataService) {
        this.dataService = dataService;
    }
    ProjectService.prototype.getProjects = function () {
        return this.dataService.get('projects')
            .toPromise()
            .then(function (response) { return response.json(); })
            .catch(function (reason) { return console.error(reason); });
    };
    ProjectService.prototype.getProject = function (id) {
        return this.dataService.get('projects', '', id)
            .toPromise()
            .then(function (response) { return response.json(); });
    };
    ProjectService.prototype.updateProject = function (project) {
        return this.dataService.put('projects', '', project.id, JSON.stringify(project))
            .toPromise()
            .then(function (response) { return true; });
    };
    return ProjectService;
}());
ProjectService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [data_service_1.DataService])
], ProjectService);
exports.ProjectService = ProjectService;
//# sourceMappingURL=project.service.js.map