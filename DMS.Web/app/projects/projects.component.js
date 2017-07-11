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
var router_1 = require("@angular/router");
var project_service_1 = require("./services/project.service");
var ProjectsComponent = (function () {
    function ProjectsComponent(projectService, router) {
        this.projectService = projectService;
        this.router = router;
        this.subtitle = "Projects";
    }
    ProjectsComponent.prototype.getProjects = function () {
        var _this = this;
        this.projectService.getProjects().then(function (projects) { return _this.projects = projects; });
    };
    ProjectsComponent.prototype.createNew = function () {
        var link = ['/project/new'];
        this.router.navigate(link);
    };
    ProjectsComponent.prototype.ngOnInit = function () {
        this.getProjects();
    };
    return ProjectsComponent;
}());
ProjectsComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'dms-projects',
        templateUrl: 'projects.component.html'
    }),
    __metadata("design:paramtypes", [project_service_1.ProjectService, router_1.Router])
], ProjectsComponent);
exports.ProjectsComponent = ProjectsComponent;
//# sourceMappingURL=projects.component.js.map